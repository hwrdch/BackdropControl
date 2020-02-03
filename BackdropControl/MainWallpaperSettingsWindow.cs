using System;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using BackdropControl.Resources;
using System.Xml.Serialization;
using System.Xml;

namespace BackdropControl
{
    public partial class MainWallpaperSettingsWindow : Form
    {
        private string SelectedBackgroundPicturesFolder;
        private string LastUsedWallpaperDirectory;
        private List<string> PicturesPool;

        private int iter;

        public MainWallpaperSettingsWindow()
        {
            InitializeComponent();
            PicturesPool = new List<string>(); iter = 0;    //Load Main Wallpaper Settings
            LoadMainWallpaperSettings();

            //LoadPresetsFromPath();  //Load Presets Settings
            SharedObjects.DEFAULT_PRESET_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl", "BackdropControl Presets");
            if (SelectedBackgroundPicturesFolder == "" || SelectedBackgroundPicturesFolder == null)
                BackgroundChangeTimer.Enabled = false;
            else
                BackgroundChangeTimer.Enabled = true;

        }

        private void LoadMainWallpaperSettings()
        {
            try
            {
                SharedObjects.DEFAULT_APP_LOCATION_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl");
                if (!Directory.Exists(SharedObjects.DEFAULT_APP_LOCATION_PATH))
                {
                    Directory.CreateDirectory(SharedObjects.DEFAULT_APP_LOCATION_PATH);
                }

                string XMLFilePath = Path.Combine(SharedObjects.DEFAULT_APP_LOCATION_PATH, "MainWallpaperSettings.xml");

                if (!File.Exists(XMLFilePath))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(XMLFilePath, null))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement("BackdropControlMainSettings", "");
                        writer.WriteElementString("Directory", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                        writer.WriteElementString("TimeInterval", "00:00:10");
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                    }

                    this.numSec.Value = new decimal(new int[] { 10, 0, 0, 0 });
                    this.BackgroundChangeTimer.Interval = 10000;
                    SelectedBackgroundPicturesFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures));
                    this.SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
                }

                else
                {
                    #region Load directory
                    XmlDocument MainSettingsDocument = new XmlDocument();
                    MainSettingsDocument.Load(XMLFilePath);
                    SelectedBackgroundPicturesFolder = Path.GetFullPath(MainSettingsDocument["BackdropControlMainSettings"].ChildNodes[0].InnerText);
                    #endregion

                    #region Load time interval
                    string[] arr = MainSettingsDocument["BackdropControlMainSettings"].ChildNodes[1].InnerText.Split(':');
                    this.numHour.Value = new decimal(new int[] { Convert.ToInt32(arr[0]), 0, 0, 0 });
                    this.numMin.Value = new decimal(new int[] { Convert.ToInt32(arr[1]), 0, 0, 0 });
                    this.numSec.Value = new decimal(new int[] { Convert.ToInt32(arr[2]), 0, 0, 0 });
                    this.BackgroundChangeTimer.Interval = (3600000 * Convert.ToInt32(numHour.Value)) + (60000 * Convert.ToInt32(numMin.Value)) + (1000 * Convert.ToInt32(numSec.Value));
                    #endregion

                    watcher.Path = SelectedBackgroundPicturesFolder;
                    this.SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
                }

                this.MainSettingsApplyButton.Enabled = false;
                LoadToPicturesPool();
                LastUsedWallpaperDirectory = SelectedBackgroundPicturesFolder;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LoadToPicturesPool()
        {
            var filepaths = Directory.GetFiles(SelectedBackgroundPicturesFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
            foreach (string elem in filepaths)
            {
                PicturesPool.Add(elem);
            }
        }

        private void LoadPresetsFromPath()
        {
            if (!Directory.Exists(SelectedBackgroundPicturesFolder))
            {
                Directory.CreateDirectory(SelectedBackgroundPicturesFolder);
            }

            if (!File.Exists(SharedObjects.DEFAULT_APP_LOCATION_PATH + "\\DefaultSettings.xml"))
            {
                File.Create(SharedObjects.DEFAULT_APP_LOCATION_PATH + "\\DefaultSettings.xml");
                XmlSerializer XSerial = new XmlSerializer(typeof(XmlElement));

                #region Default Settings Unloaded
                XmlDocument DefaultSettingsDocument = new XmlDocument();
                XmlNode RootNode = DefaultSettingsDocument.CreateElement("BackdropControl");

                XmlNode DefaultDirectoryNode = DefaultSettingsDocument.CreateElement("Settings1Directory");
                DefaultDirectoryNode.InnerText = SharedObjects.DEFAULT_APP_LOCATION_PATH;
                RootNode.AppendChild(DefaultDirectoryNode);

                XmlNode PresetsDirectoryDocument = DefaultSettingsDocument.CreateElement("PresetsDirectory");
                DefaultDirectoryNode.InnerText = SharedObjects.DEFAULT_PRESET_PATH;
                RootNode.AppendChild(DefaultDirectoryNode);
                #endregion
            }

            #region Load Preset Files
            string[] PresetFiles = Directory.GetFiles(Path.Combine(SharedObjects.DEFAULT_APP_LOCATION_PATH, "BackdropControl Presets"));
            foreach (string FileName in PresetFiles)
            {
                string FileNameWithExt = FileName + ".xml";
                XmlDocument LoadedDocument = new XmlDocument();
                LoadedDocument.Load(Path.GetFullPath(FileNameWithExt));

                BackgroundPreset BGPreset = new BackgroundPreset(FileName);
                foreach (XmlNode PresetEntryNode in LoadedDocument.DocumentElement.ChildNodes)
                {
                    string XMLFileName = PresetEntryNode["FileName"].Value.ToString();
                    TimeSpan XMLTimeSpan = TimeSpan.Parse(PresetEntryNode["TimeSpan"].Value.ToString());
                    BGPreset.AddPresetEntry(new BackgroundPresetEntry(XMLFileName, XMLTimeSpan));
                }

                SharedObjects.LoadedPresetNames.Add(FileName);
                if (LoadedDocument["Active"].Value == "1")
                {
                    SharedObjects.LastUsedPreset = BGPreset;
                }
            }
            #endregion
        }

        private void BackgroundDirectoryChangeEvent(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();
            f.RootFolder = Environment.SpecialFolder.Desktop;
            if (!Directory.Exists(SelectedBackgroundPicturesFolder))
            {
                f.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else
                f.SelectedPath = SelectedBackgroundPicturesFolder;    //sets beginning folder to last used folder
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK && f.SelectedPath != LastUsedWallpaperDirectory)
            {
                SelectedBackgroundPicturesFolder = f.SelectedPath;
                SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
                MainSettingsApplyButton.Enabled = true;
            }
        }
        private void SetBackgroundPicture(string file)
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

        private void BackgroundTimerEvent(object sender, EventArgs e)
        {
            if (!Directory.Exists(SelectedBackgroundPicturesFolder))
            {
                PicturesPool.Clear();
                LoadMainWallpaperSettings();
            }
            else
            {
                TimelyWallpaperChange();
            }
        }

        private void TimelyWallpaperChange()
        {
            if (PicturesPool.Count() != 0)
            {
                if (iter == 0)
                {
                    SetBackgroundPicture(PicturesPool[0]);
                    iter++;
                }
                else if (iter < PicturesPool.Count())
                {
                    SetBackgroundPicture(PicturesPool[iter]);
                    iter++;
                }
                else
                {
                    iter = 0;
                    SetBackgroundPicture(PicturesPool[iter]);
                }
            }
        }

        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File: " + e.FullPath);
            string ext = Path.GetExtension(e.FullPath);
            if (ext == "png" || ext == "jpg" || ext == "jpeg")
                PicturesPool.Add(e.FullPath);
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
                PicturesPool.Add(filepath);
            }
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE CHANGE: ", e.FullPath);
        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File deleted: {0}", e.Name);
            PicturesPool.RemoveAt(PicturesPool.IndexOf(e.FullPath));
            foreach (string s in PicturesPool)
                System.Diagnostics.Debug.WriteLine(s);
        }

        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE RENAME: {0} -> {1}", e.OldFullPath, e.FullPath);
            PicturesPool[PicturesPool.IndexOf(e.OldFullPath)] = e.FullPath;
            foreach (string s in PicturesPool)
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

        private void SerializeMainSettings(object sender, EventArgs e)
        {
            var doc = XElement.Load(SharedObjects.DEFAULT_APP_LOCATION_PATH + "\\MainWallpaperSettings.xml");
            int intervalSum = (3600000 * Convert.ToInt32(numHour.Value)) + (60000 * Convert.ToInt32(numMin.Value)) + (1000 * Convert.ToInt32(numSec.Value));
            if (intervalSum < 10000)
            {
                MessageBox.Show("Time Interval cannot be less than 10 seconds");
                numSec.Value = 10;
            }
            else
            {
                StatusLabel.Visible = true;
                StatusLabel.Text = "Saving...";
                doc.Element("TimeInterval").Value = numHour.Value.ToString() + ":" + numMin.Value.ToString() + ":" + numSec.Value.ToString();
                doc.Element("Directory").Value = SelectedBackgroundPicturesFolder;
                doc.Save(SharedObjects.DEFAULT_APP_LOCATION_PATH + "\\MainWallpaperSettings.xml");
                this.BackgroundChangeTimer.Interval = intervalSum;
            }

            if (SelectedBackgroundPicturesFolder != LastUsedWallpaperDirectory)
            {
                BackgroundChangeTimer.Enabled = true;     //change data only AFTER apply button is clicked
                watcher.Path = SelectedBackgroundPicturesFolder;
                PicturesPool.Clear();
                var filepaths = Directory.GetFiles(SelectedBackgroundPicturesFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                foreach (string elem in filepaths)
                {
                    PicturesPool.Add(elem);
                }
                LastUsedWallpaperDirectory = SelectedBackgroundPicturesFolder;
                SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
            }
            MainSettingsApplyButton.Enabled = false;
            StatusLabel.Text = "Settings Saved.";
        }

        private void MainSettingsCancel(object sender, EventArgs e)
        {
            LoadMainWallpaperSettings();
            MainSettingsApplyButton.Enabled = false;
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
            MainSettingsApplyButton.Enabled = true;
        }

        private void numHour_ValueChanged(object sender, EventArgs e)
        {
            MainSettingsApplyButton.Enabled = true;
        }

        private void numMin_ValueChanged(object sender, EventArgs e)
        {
            MainSettingsApplyButton.Enabled = true;
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
            SelectedFolderLabel.Enabled = false;
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
            OpenPresetsSettingsButton.Enabled = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                greyOutMode2();
            else if (radioButton1.Checked == false)
                greyOutMode1();
            MainSettingsApplyButton.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
                greyOutMode1();
            else if (radioButton2.Checked == false)
                greyOutMode2();
            MainSettingsApplyButton.Enabled = true;
        }

        private void greyOutMode2()
        {
            radioButton1.Checked = true;
            SelectedFolderLabel.Enabled = true;
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
            OpenPresetsSettingsButton.Enabled = false;
        }

        private void OpenPresetsSettingsEvent(object sender, EventArgs e)
        {
            PresetsQuickSettings f2 = new PresetsQuickSettings();
            f2.ShowDialog();
        }
    }
}
