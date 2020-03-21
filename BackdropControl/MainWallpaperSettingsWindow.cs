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
using System.Threading.Tasks;

namespace BackdropControl
{
    public partial class MainWallpaperSettingsWindow : Form
    {
        private string SelectedBackgroundPicturesFolder;
        PresetsQuickSettings PresetSettingsWindow;
        private string LastUsedWallpaperDirectory;

        private List<string> ImagePool;
        private int ImagePoolIndex;
        private BackgroundPreset SelectedPreset;
        private BackgroundPresetEntry QueuedEntry;

        private Dictionary<TimeSpan, string> PresetPool;
        private EventHandler DirectoryOptionEvent;
        private EventHandler PresetOptionEvent;

        public MainWallpaperSettingsWindow()
        {
            InitializeComponent();
            ImagePool = new List<string>(); ImagePoolIndex = 0;
            LoadMainWallpaperSettings();

            SharedObjects.DEFAULT_PRESET_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl", "BackdropControl Presets");
            if (SelectedBackgroundPicturesFolder == "" || SelectedBackgroundPicturesFolder == null)
                BackgroundChangeTimer.Enabled = false;
            else
                BackgroundChangeTimer.Enabled = true;

            PresetPool = new Dictionary<TimeSpan, string>();
            LoadPresetsFromPath();

            DirectoryOptionEvent = new EventHandler(this.DirectoryOptionMoveToNextImage);
            PresetOptionEvent = new EventHandler(this.PresetOptionMoveToNextImage);

            PresetSettingsWindow = new PresetsQuickSettings();
            PresetSettingsWindow.FormClosed += new FormClosedEventHandler(this.PresetSettingsWindowClosed);
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
                    LastSerializedData.MainWallpaperSettingsDirectory = SelectedBackgroundPicturesFolder;
                    #endregion

                    string[] arr = MainSettingsDocument["BackdropControlMainSettings"].ChildNodes[1].InnerText.Split(':');
                    this.numHour.Value = new decimal(new int[] { Convert.ToInt32(arr[0]), 0, 0, 0 });
                    this.numMin.Value = new decimal(new int[] { Convert.ToInt32(arr[1]), 0, 0, 0 });
                    this.numSec.Value = new decimal(new int[] { Convert.ToInt32(arr[2]), 0, 0, 0 });

                    this.BackgroundChangeTimer.Interval = (3600000 * Convert.ToInt32(numHour.Value)) + (60000 * Convert.ToInt32(numMin.Value)) + (1000 * Convert.ToInt32(numSec.Value));
                    LastSerializedData.MainWallpaperSettingsTimeOfChange = TimeSpan.FromSeconds
                        ((Convert.ToDouble(this.numHour.Value) * 3600) +
                            (Convert.ToDouble(this.numMin.Value) * 60) +
                                (Convert.ToDouble(this.numSec.Value)));

                    DirectoryOptionFileWatcher.Path = SelectedBackgroundPicturesFolder;
                    this.SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
                }

                this.MainSettingsApplyButton.Enabled = false;
                LoadToImagePool();
                LastUsedWallpaperDirectory = SelectedBackgroundPicturesFolder;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void LoadToImagePool()
        {
            ImagePool.Clear();
            if (DirectorySelectOption.Checked == true)
            {
                var filepaths = Directory.GetFiles(SelectedBackgroundPicturesFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                foreach (string elem in filepaths)
                {
                    ImagePool.Add(elem);
                } 
            }

            else if (PresetSettingSelectOption.Checked == true)
            {
                foreach (BackgroundPresetEntry elem in SelectedPreset.GetPresetEntries())
                {
                    PresetPool.Add(elem.TimeOfChange, elem.DirectoryPath);
                }
            }
        }

        private void LoadPresetsFromPath()
        {
            if (!Directory.Exists(SharedObjects.DEFAULT_PRESET_PATH))
            {
                Directory.CreateDirectory(SharedObjects.DEFAULT_PRESET_PATH);
            }

            else
            {
                foreach (string path in Directory.GetFiles(SharedObjects.DEFAULT_PRESET_PATH, "*.xml"))
                {
                    XmlDocument doc = new XmlDocument();        //collect and locally store presets from file
                    doc.Load(path);     //presets each have their own files

                    string presetName = Path.GetFileNameWithoutExtension(path);
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList nodes = root.ChildNodes;
                    BackgroundPreset LoadedPreset = new BackgroundPreset(Path.GetFileNameWithoutExtension(presetName), root.GetAttribute("PresetID"));
                    BackgroundPreset LastSavedPreset = new BackgroundPreset(Path.GetFileNameWithoutExtension(presetName), root.GetAttribute("PresetID"));

                    for (int i = 0; i < nodes.Count; i++)
                    {
                        BackgroundPresetEntry PresetEntry = new BackgroundPresetEntry(nodes[i]["FilePath"].InnerText, TimeSpan.Parse(nodes[i]["TimeInterval"].InnerText), nodes[i]["EntryID"].InnerText);
                        LoadedPreset.AddPresetEntry(PresetEntry);
                        LastSavedPreset.AddPresetEntry(PresetEntry);
                    }

                    LastSerializedData.LoadedSerializedPresets.Add(LastSavedPreset);
                    SharedObjects.ListOfLoadedPresets.Add(LoadedPreset);
                    MainSettingsPagePresetComboBox.Items.Add(LoadedPreset.PresetName);
                }
            }
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

            SharedObjects.SELECTED_MAIN_SETTINGS_PATH = SelectedBackgroundPicturesFolder;
        }
        private async Task SetBackgroundPicture(string file)
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

        private void DirectoryOptionMoveToNextImage(object sender, EventArgs e)
        {
            if (DirectorySelectOption.Checked == true || (!DirectorySelectOption.Checked && MainSettingsPagePresetComboBox.SelectedItem == null))
            {
                if (!Directory.Exists(SelectedBackgroundPicturesFolder))
                {
                    ImagePool.Clear();
                    LoadMainWallpaperSettings();
                }
                else
                {
                    if (ImagePool.Count() != 0)
                    {
                        if (ImagePoolIndex == 0)
                        {
                            Task.Run(() => SetBackgroundPicture(ImagePool[0]));
                            ImagePoolIndex++;
                        }
                        else if (ImagePoolIndex < ImagePool.Count())
                        {
                            Task.Run(() => SetBackgroundPicture(ImagePool[ImagePoolIndex]));
                            ImagePoolIndex++;
                        }
                        else
                        {
                            ImagePoolIndex = 0;
                            Task.Run(() => SetBackgroundPicture(ImagePool[ImagePoolIndex]));
                        }
                    }
                }
            }
        }

        private void PresetOptionMoveToNextImage(object sender, EventArgs e)
        {
            double dt = QueuedEntry.TimeOfChange.TotalSeconds;
            int currentindex = SelectedPreset.PresetEntries.IndexOf(QueuedEntry);

            Task.Run(() => SetBackgroundPicture(QueuedEntry.DirectoryPath));
            if (currentindex == SelectedPreset.PresetEntries.Count - 1)
            {
                QueuedEntry = SelectedPreset.PresetEntries[0];
            }
            else
            {
                QueuedEntry = SelectedPreset.GetPresetEntries()[currentindex + 1];
            }
            
            Task.Run(() => SetPresetTimerEvent(QueuedEntry.TimeOfChange.TotalSeconds, dt));
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
                ImagePool.Add(filepath);
            }
        }

        private void DirectoryFilesCreated(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File: " + e.FullPath);
            string ext = Path.GetExtension(e.FullPath);
            if (ext == "png" || ext == "jpg" || ext == "jpeg")
                ImagePool.Add(e.FullPath);
        }

        private void DirectoryFilesChanged(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE CHANGE: ", e.FullPath);
        }

        private void DirectoryFilesDeleted(object sender, FileSystemEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File deleted: {0}", e.Name);
            ImagePool.RemoveAt(ImagePool.IndexOf(e.FullPath));
            foreach (string s in ImagePool)
                System.Diagnostics.Debug.WriteLine(s);
        }

        private void DirectoryFilesRenamed(object sender, RenamedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("FILE RENAME: {0} -> {1}", e.OldFullPath, e.FullPath);
            ImagePool[ImagePool.IndexOf(e.OldFullPath)] = e.FullPath;
            foreach (string s in ImagePool)
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
            if (DirectorySelectOption.Checked)
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
                    BackgroundChangeTimer.Enabled = true;
                    DirectoryOptionFileWatcher.Path = SelectedBackgroundPicturesFolder;
                    ImagePool.Clear();
                    var filepaths = Directory.GetFiles(SelectedBackgroundPicturesFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".jpeg") || s.EndsWith(".jpg") || s.EndsWith(".png"));
                    foreach (string elem in filepaths)
                    {
                        ImagePool.Add(elem);
                    }
                    LastUsedWallpaperDirectory = SelectedBackgroundPicturesFolder;
                    SelectedFolderLabel.Text = SelectedBackgroundPicturesFolder;
                }
                BackgroundChangeTimer.Tick -= PresetOptionEvent;
                BackgroundChangeTimer.Tick += DirectoryOptionEvent;
            }

            else
            {
                double DateTimeNow = DateTime.Now.TimeOfDay.TotalSeconds;
                if (MainSettingsPagePresetComboBox.SelectedItem != null)
                {
                    SelectedPreset = LastSerializedData.LoadedSerializedPresets.FirstOrDefault(p => p.PresetName == MainSettingsPagePresetComboBox.SelectedItem.ToString());
                    QueuedEntry = SelectedPreset.GetPresetEntries().FirstOrDefault(n => n.TimeOfChange.TotalSeconds > DateTime.Now.TimeOfDay.TotalSeconds);
                    if (QueuedEntry == null)
                    {
                        QueuedEntry = SelectedPreset.GetPresetEntries()[0];
                    }
                    SetPresetTimerEvent(QueuedEntry.TimeOfChange.TotalSeconds, DateTimeNow);

                    BackgroundChangeTimer.Tick -= DirectoryOptionEvent;
                    BackgroundChangeTimer.Tick += PresetOptionEvent;
                }
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
            Application.Exit();
        }

        private void closeForm(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
                this.Hide();

                Application.Exit();
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
            DirectorySelectOption.Checked = false;
            SelectedFolderLabel.Enabled = false;
            BGchange.Enabled = false;
            label2.Enabled = false;
            numHour.Enabled = false;
            numMin.Enabled = false;
            numSec.Enabled = false;
            label1.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;

            PresetSettingSelectOption.Checked = true;
            SelectedPresetLabel.Enabled = true;
            MainSettingsPagePresetComboBox.Enabled = true;
            OpenPresetsSettingsButton.Enabled = true;
        }

        private void greyOutMode2()
        {
            DirectorySelectOption.Checked = true;
            SelectedFolderLabel.Enabled = true;
            BGchange.Enabled = true;
            label2.Enabled = true;
            numHour.Enabled = true;
            numMin.Enabled = true;
            numSec.Enabled = true;
            label1.Enabled = true;
            label3.Enabled = true;
            label4.Enabled = true;

            PresetSettingSelectOption.Checked = false;
            SelectedPresetLabel.Enabled = false;
            MainSettingsPagePresetComboBox.Enabled = false;
            OpenPresetsSettingsButton.Enabled = false;
        }

        private void DirectoryUserSelectEvent(object sender, EventArgs e)
        {
            if (DirectorySelectOption.Checked == true)
                greyOutMode2();
            else if (DirectorySelectOption.Checked == false)
                greyOutMode1();
            MainSettingsApplyButton.Enabled = true;
        }

        private void PresetUserSelectEvent(object sender, EventArgs e)
        {
            if (PresetSettingSelectOption.Checked == true)
                greyOutMode1();
            else if (PresetSettingSelectOption.Checked == false)
                greyOutMode2();
            MainSettingsApplyButton.Enabled = true;
        }

        private void OpenPresetsSettingsEvent(object sender, EventArgs e)
        {
            PresetSettingsWindow.ShowDialog();
        }

        private void PresetSettingsWindowClosed(object sender, EventArgs e)
        {
            string s = "";

            if (MainSettingsPagePresetComboBox.SelectedItem != null)
            {
                s = MainSettingsPagePresetComboBox.SelectedItem.ToString();
            }
            MainSettingsPagePresetComboBox.Items.Clear();

            foreach (BackgroundPreset preset in LastSerializedData.LoadedSerializedPresets)
                MainSettingsPagePresetComboBox.Items.Add(preset.PresetName);

            MainSettingsPagePresetComboBox.SelectedItem = s;
        }

        private async Task SetPresetTimerEvent(double PresetEntryTime, double DateTimeNow)
        {
            BackgroundChangeTimer.Stop();
            if (PresetEntryTime < DateTimeNow)
            {
                BackgroundChangeTimer.Interval = ((Convert.ToInt32(PresetEntryTime) + (24 * 60 * 60)) - Convert.ToInt32(DateTimeNow)) * 1000;
            }
            else
            {
                BackgroundChangeTimer.Interval = Convert.ToInt32(PresetEntryTime - DateTimeNow) * 1000;
            }

            BackgroundChangeTimer.Start();
        }

        private void PresetComboBoxValueChangedEvent(object sender, EventArgs e)
        {
            MainSettingsApplyButton.Enabled = true;
        }
    }
}
