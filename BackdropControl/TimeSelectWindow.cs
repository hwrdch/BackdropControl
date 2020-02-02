using BackdropControl.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackdropControl
{
    public partial class TimeSelectWindow : Form
    {
        public TimeSpan TimeOfChange;
        private BindingList<BackgroundPresetEntry> CurrentPresetEntries;
        public BackgroundPresetEntry EditedPresetEntry;
        public int EditedPresetEntryIndex;
        
        public TimeSelectWindow(BindingList<BackgroundPresetEntry> list)
        {
            InitializeComponent();
            TimeOfChange = TimeSpan.MinValue;
            CurrentPresetEntries = list;
            TimeSelectConfirmButton.Visible = true;
        }

        public TimeSelectWindow(string hr, string min, string sec, ref BindingList<BackgroundPresetEntry> list)
        {
            InitializeComponent();
            TimeOfChange = new TimeSpan();
            TimeSpan.TryParse(hr + ":" + min + ":" + sec, out TimeOfChange);
            HRUpDown.Value = Convert.ToDecimal(hr); MINUpDown.Value = Convert.ToDecimal(min); SECUpDown.Value = Convert.ToDecimal(sec);
            CurrentPresetEntries = list;
            ChangeTimeButton.Visible = true;
        }

        private void ConfirmNewSelectedTimeEvent(object sender, EventArgs e)    //edit existing time preset
        {
            TimeSpan ts = TimeSpan.Parse(HRUpDown.Value.ToString() + ":" + MINUpDown.Value.ToString() + ":" + SECUpDown.Value.ToString());
            BackgroundPresetEntry bp = CurrentPresetEntries.First(s => s.TimeOfChange == TimeOfChange);
            int index = CurrentPresetEntries.IndexOf(CurrentPresetEntries.First(s => s.TimeOfChange == TimeOfChange));

            if (CheckTimeConflict(ts, bp.TimeOfChange))
                return;

            CurrentPresetEntries[index].TimeOfChange = ts;

            TimeSelectConfirmButton.Visible = false;
            ChangeTimeButton.Visible = false;

            EditedPresetEntry = CurrentPresetEntries[index];
            EditedPresetEntryIndex = index;

            this.Close();
        }

        private void ConfirmSelectedTimeEvent(object sender, EventArgs e)   //new preset entry
        {
            TimeSpan ts = TimeSpan.Parse(HRUpDown.Value.ToString() + ":" + MINUpDown.Value.ToString() + ":" + SECUpDown.Value.ToString());

            if (CheckTimeConflict(ts, TimeSpan.MinValue))
                return;

            TimeSelectConfirmButton.Visible = false;
            ChangeTimeButton.Visible = false;
            this.Close();
        }

        private bool CheckTimeConflict(TimeSpan NewTS, TimeSpan ChangedTS)
        {
            foreach (BackgroundPresetEntry bpentry in CurrentPresetEntries)
            {
                if (bpentry.TimeOfChange == ChangedTS)
                    continue;
                if (Math.Abs(NewTS.TotalSeconds - bpentry.TimeOfChange.TotalSeconds) < 10)
                {
                    this.ConflictMessageLabel.Visible = true;
                    this.TimeOfConflictLabel.Text = bpentry.GetTimeOfChangeString();
                    this.TimeOfConflictLabel.Visible = true;
                    return true ;
                }
            }
            return false;
        }

        private void ValidPresetTimeSelected(object sender, FormClosedEventArgs e)
        {
            TimeOfChange = TimeSpan.Parse(HRUpDown.Value.ToString() + ":" + MINUpDown.Value.ToString() + ":" + SECUpDown.Value.ToString());
        }
    }
}
