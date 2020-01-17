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
        
        public TimeSelectWindow()
        {
            InitializeComponent();
            TimeOfChange = TimeSpan.MinValue;
        }

        public TimeSelectWindow(string hr, string min, string sec)
        {
            TimeOfChange = new TimeSpan();
            TimeSpan.TryParse(hr + ":" + min + ":" + sec, out TimeOfChange);
        }

        private void CheckTimeConflictButtonEvent(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ValidPresetTimeSelected(object sender, FormClosedEventArgs e)
        {
            TimeOfChange = TimeSpan.Parse(HRUpDown.Value.ToString() + ":" + MINUpDown.Value.ToString() + ":" + SECUpDown.Value.ToString());
        }
    }
}
