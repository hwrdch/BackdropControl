using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace BackdropControl
{
    public partial class PresetEditForm : Form
    {
        private string setTime;
        private string setPath;

        private string oldTime;
        private string oldPath;

        private List<string> list;
        public string TimeValue
        {
            get { return this.setTime; }
            set { setTime = value; }
        }
        public string NewPath
        {
            get { return this.setPath; }
            set { setPath = value; }
        }
        public PresetEditForm(string name, string time, List<string> l)
        {
            InitializeComponent();
            list = new List<string>(l);

            DateTime dt = new DateTime(2018, 1, 1, Convert.ToInt32(time.Substring(0, 2)), Convert.ToInt32(time.Substring(3, 2)), Convert.ToInt32(time.Substring(6, 2)));
            ClockPicker.Value = dt;
            PathTextBox.Text = name;

            oldTime = time;
            oldPath = name;
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            setTime = oldTime;
            setPath = oldPath;
            this.Close();
        }
        private string ConvertTime()
        {
            string hr, min, sec;
            if (Convert.ToInt32(ClockPicker.Value.Hour) < 10)
                hr = "0" + ClockPicker.Value.Hour.ToString();
            else
                hr = ClockPicker.Value.Hour.ToString();
            if (Convert.ToInt32(ClockPicker.Value.Minute) < 10)
                min = "0" + ClockPicker.Value.Minute.ToString();
            else
                min = ClockPicker.Value.Minute.ToString();
            if (Convert.ToInt32(ClockPicker.Value.Second) < 10)
                sec = "0" + ClockPicker.Value.Second.ToString();
            else
                sec = ClockPicker.Value.Second.ToString();

            return hr + ":" + min + ":" + sec;
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DirButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            string browserPath = setPath;
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            ofd.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                browserPath = Path.GetDirectoryName(ofd.FileName) + ofd.FileName;
            }
            PathTextBox.Text = browserPath;
        }
    }
}
