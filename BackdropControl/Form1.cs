using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace BackdropControl
{
    public partial class Form1 : Form
    {
        private string folderPath;
        private string oldFolderPath;
        private List<string> pictures;
        private int iter;

        public Form1()
        {
            pictures = new List<string>();
            iter = 0;
            XMLInit();
            InitializeComponent();
            loadXML();  //load XML data
            if (folderPath == "" || folderPath == null)
                BGTimer.Enabled = false;
            else
                BGTimer.Enabled = true;
        }

        private void BGchange_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.RootFolder = Environment.SpecialFolder.Desktop;
            if (!Directory.Exists(folderPath))
            {
                f.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                XDocument.Load("normalSettings.xml").Element("Interval").Value = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures).ToString();
            }
            else
                f.SelectedPath = folderPath;    //sets beginning folder to last used folder
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK && f.SelectedPath != oldFolderPath)
            {
                folderPath = f.SelectedPath;
                filepathLabel.Text = folderPath;
                applybutton.Enabled = true;
            }
        }
        private void setBackground(string file)
        {
            const int SET_DESKTOP_BACKGROUND = 20;
            const int UPDATE_INI_FILE = 1;
            const int SEND_WINDOWS_INI_CHANGE = 2;

            //--< set desktop.background >--
            win32.SystemParametersInfo(SET_DESKTOP_BACKGROUND, 0, file, UPDATE_INI_FILE | SEND_WINDOWS_INI_CHANGE);
        }

        internal sealed class win32
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            internal static extern int SystemParametersInfo(int uAction, int uParam, String lpvParam, int fuWinIni);
        }

        private void BGTimer_Tick(object sender, EventArgs e)
        {
            if (!Directory.Exists(folderPath))
            {
                pictures.Clear();
                loadXML();
            }
            else
            {
                TimelyWallpaperChange();
            }
        }

        private void TimelyWallpaperChange()
        {
            if (pictures.Count() != 0)
            {
                if (iter < pictures.Count())
                {
                    setBackground(pictures[iter]);
                    iter++;
                }
                else
                {
                    iter = 0;
                    setBackground(pictures[iter]);
                }
            }
        }

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File: " + e.FullPath);
            string ext = Path.GetExtension(e.FullPath);
            if (ext == "png" || ext == "jpg" || ext == "jpeg")
                pictures.Add(e.FullPath);
        }

        private void PictureCheck(string filepath)
        {
            //Check if picture file by reading header bytes
            FileStream stream = File.OpenRead(filepath);
            byte[] fileBytes = new byte[stream.Length];
            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();
            if (CheckPicture(fileBytes))
            {
                pictures.Add(filepath);
            }
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE CHANGE: ", e.FullPath);
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File deleted: {0}", e.Name);
            pictures.RemoveAt(pictures.IndexOf(e.FullPath));
            foreach (string s in pictures)
                System.Diagnostics.Debug.WriteLine(s);
        }

        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE RENAME: {0} -> {1}", e.OldFullPath, e.FullPath);
            pictures[pictures.IndexOf(e.OldFullPath)] = e.FullPath;
            foreach (string s in pictures)
                System.Diagnostics.Debug.WriteLine(s);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.contextMenuStrip1.Show(Cursor.Position);
        }

        private void exitStrip_Click(object sender, EventArgs e)
        {
            this.notifyIcon1 = null;
            System.Windows.Forms.Application.Exit();
        }

        private void settingsStrip_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void applybutton_Click(object sender, EventArgs e)
        {
            var doc = XElement.Load("normalSettings.xml");
            int intervalSum = (3600000 * Convert.ToInt32(numHour.Value)) + (60000 * Convert.ToInt32(numMin.Value)) + (1000 * Convert.ToInt32(numSec.Value));
            if (intervalSum < 10000)
            {
                MessageBox.Show("Time Interval cannot be less than 10 seconds");
                numSec.Value = 10;
            }
            else
            {
                doc.Element("Interval").Value = numHour.Value.ToString() + ":" + numMin.Value.ToString() + ":" + numSec.Value.ToString();
                doc.Element("Folder").Value = folderPath;
                doc.Save("normalSettings.xml");
                this.BGTimer.Interval = intervalSum;
            }
            if (folderPath != oldFolderPath)
            {
                BGTimer.Enabled = true;     //change data only AFTER apply button is clicked
                watcher.Path = folderPath;
                pictures.Clear();
                var filepaths = Directory.GetFiles(folderPath, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                foreach (string elem in filepaths)
                {
                    pictures.Add(elem);
                }
                oldFolderPath = folderPath;
                filepathLabel.Text = folderPath;
            }
            applybutton.Enabled = false;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            loadXML();
            applybutton.Enabled = false;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void closeForm(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                this.Hide();
            }
        }

        private void numSec_ValueChanged(object sender, EventArgs e)
        {
            applybutton.Enabled = true;
        }

        private void numHour_ValueChanged(object sender, EventArgs e)
        {
            applybutton.Enabled = true;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            applybutton.Enabled = true;
        }


        public static bool CheckPicture(byte[] bytes)
        {
            var bmp = Encoding.ASCII.GetBytes("BM");     // BMP
            var gif = Encoding.ASCII.GetBytes("GIF");    // GIF
            var png = new byte[] { 137, 80, 78, 71 };    // PNG
            var tiff = new byte[] { 73, 73, 42 };         // TIFF
            var tiff2 = new byte[] { 77, 77, 42 };         // TIFF
            var jpeg = new byte[] { 255, 216, 255, 224 }; // jpeg
            var jpeg2 = new byte[] { 255, 216, 255, 225 }; // jpeg canon

            if (bmp.SequenceEqual(bytes.Take(bmp.Length)))
                return true;

            if (gif.SequenceEqual(bytes.Take(gif.Length)))
                return true;

            if (png.SequenceEqual(bytes.Take(png.Length)))
                return true;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length)))
                return true;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length)))
                return true;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length)))
                return true;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length)))
                return true;

            return false;
        }

        private void greyOutMode1()
        {
            radioButton1.Checked = false;
            filepathLabel.Enabled = false;
            BGchange.Enabled = false;
            label2.Enabled = false;
            numHour.Enabled = false;
            numMin.Enabled = false;
            numSec.Enabled = false;
            label1.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;

            radioButton2.Checked = true;
            label5.Enabled = true;
            comboBox1.Enabled = true;
            presetButton.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                greyOutMode2();
            else if (radioButton1.Checked == false)
                greyOutMode1();
            applybutton.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                greyOutMode1();
            else if (radioButton2.Checked == false)
                greyOutMode2();
            applybutton.Enabled = true;
        }

        private void greyOutMode2()
        {
            radioButton1.Checked = true;
            filepathLabel.Enabled = true;
            BGchange.Enabled = true;
            label2.Enabled = true;
            numHour.Enabled = true;
            numMin.Enabled = true;
            numSec.Enabled = true;
            label1.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;

            radioButton2.Checked = false;
            label5.Enabled = false;
            comboBox1.Enabled = false;
            presetButton.Enabled = false;
        }

        private void presetButton_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }
    }
}
