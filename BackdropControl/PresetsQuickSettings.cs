using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackdropControl.Resources;
using System.ComponentModel;

namespace BackdropControl
{
    public partial class PresetsQuickSettings : Form
    {
        public string DEFAULT_PRESET_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl Presets");
        public BindingList<BackgroundPreset> ListOfLoadedPresets = new BindingList<BackgroundPreset>();
        public string LastUsedPictureFolderDirectory;
        public BindingList<BackgroundPresetEntry> DisplayedPresetEntries = new BindingList<BackgroundPresetEntry>();
        public string HighlightedPresetName = string.Empty;

        public PresetsQuickSettings()
        {
            InitializeComponent();
            PresetInit();
        }
        public void PresetInit()
        {
            if (!Directory.Exists(DEFAULT_PRESET_PATH))
            {
                Directory.CreateDirectory(DEFAULT_PRESET_PATH);
                //XmlTextWriter writer = new XmlTextWriter("BackdropControlPresets.xml", Encoding.UTF8);
                //writer.Formatting = Formatting.Indented;
                //writer.WriteStartElement("BCPresets");
                //writer.WriteEndElement();
                //writer.Close();
            }

            else
            {
                foreach(string path in Directory.GetFiles(DEFAULT_PRESET_PATH, "*.xml"))
                { 
                    XmlDocument doc = new XmlDocument();        //collect and locally store presets from file
                    doc.Load(path);     //presets each have their own files
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList nodes = doc.DocumentElement.SelectNodes("PresetEntry");
                    BackgroundPreset LoadedPreset = new BackgroundPreset(Path.GetFileNameWithoutExtension(DEFAULT_PRESET_PATH));

                    for (int i = 0; i < nodes.Count; i++)
                    {
                        LoadedPreset.AddPresetEntry(new BackgroundPresetEntry(nodes[i]["Path"].InnerText, TimeSpan.Parse(nodes[i]["Time"].InnerText))); //load preset name
                    }
                    ListOfLoadedPresets.Add(LoadedPreset);
                }
            }
            LastUsedPictureFolderDirectory = DEFAULT_PRESET_PATH;
            PresetListBox.DataSource = ListOfLoadedPresets;
            PresetListBox.DisplayMember = "PresetName";
            SelectedPresetPicturesListBox.DataSource = DisplayedPresetEntries;
            SelectedPresetPicturesListBox.DisplayMember = "PictureFileName";

            //this.DisplayedPresetEntries.ListChanged += new ListChangedEventHandler(this.SelectedPresetPicturesChangedEvent);
        }

        private void SelectedPresetChangedEvent(object sender, EventArgs e)
        {
            if (((BackgroundPreset)(PresetListBox.SelectedItem)).PresetName != HighlightedPresetName)
            {
                DisplayedPresetEntries.Clear();
                HighlightedPresetName = ((BackgroundPreset)(PresetListBox.SelectedItem)).PresetName;
                BackgroundPreset preset = ListOfLoadedPresets.FirstOrDefault<BackgroundPreset>(
                    s => s.PresetName == ((BackgroundPreset)PresetListBox.SelectedItem).PresetName);

                foreach (BackgroundPresetEntry entry in preset.GetPresetEntries())
                {
                    DisplayedPresetEntries.Add(entry);
                }
            }

            BGPreview.Image = null;
            SelectedPresetPicturesListBox.SelectedItem = null;
        }


        private void PresetListChangedEvent(object sender, EventArgs e)
        {
            PresetListBox.Items.Clear();
            foreach (BackgroundPreset bp in ListOfLoadedPresets)
                PresetListBox.Items.Add(bp);
        }

        private void PresetBox1Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (PresetListBox.SelectedItem != null)
                {
                    RightClickRenameMenuItem.Enabled = true;
                    RightClickDeleteMenuItem.Enabled = true;
                }

                AddEditDeletePresetMenu.Show(Cursor.Position);
            }

            if (PresetListBox.IndexFromPoint(Cursor.Position) != ListBox.NoMatches)
            {
                HighlightedPresetName = ListOfLoadedPresets[PresetListBox.SelectedIndex].PresetName;
                SelectedPresetPicturesListBox.Items.Clear();
                if (ListOfLoadedPresets.Count > 0)
                {
                    foreach (BackgroundPresetEntry entry in ListOfLoadedPresets[PresetListBox.SelectedIndex].GetPresetEntries())
                        SelectedPresetPicturesListBox.Items.Add(entry);
                } 
            }
        }
        private void SelectedPresetEntryEvent(object sender, MouseEventArgs e)
        {
            //save for later
            if (SelectedPresetPicturesListBox.SelectedItem != null)
            {
                BGPreview.ImageLocation = ((BackgroundPresetEntry) SelectedPresetPicturesListBox.SelectedItem).DirectoryPath;
            }
        }
        private string TimeConvert(string v)
        {
            string hr;
            string timeOfday;
            int hour = Convert.ToInt32(v.Substring(0, 2));
            if (hour > 11)
                timeOfday = "PM";
            else
                timeOfday = "AM";
            if (hour == 12)
                hr = "12";
            else if (hour%12 < 10)
                hr = "0" + (hour % 12).ToString();
            else
                hr = (hour % 12).ToString();
            return hr + v.Substring(2) + " " + timeOfday;
        }

        private string checkEllipses(string s)
        {
            if (s.Length > 10)
                return s.Substring(0, 7) + "...";
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < 10-s.Length; i++)
                {
                    sb.Append(" ");
                }
                return s + sb.ToString() ;
            }
        }

        private void RightClick1AddPreset(object sender, EventArgs e)
        {
            AddNewPresetTextBox.Enabled = true;
            AddNewPresetTextBox.Visible = true;
            this.ActiveControl = AddNewPresetTextBox;

            AddNewPresetTextBox.Text = string.Empty;
        }

        private void SelectedPresetPicturesChangedEvent(object sender, EventArgs e)
        {


            //if (ListOfLoadedPresets.Count > 0)
            //{
            //    SelectedPresetPicturesListBox.Items.Clear();
            //    foreach (BackgroundPreset bp in ListOfLoadedPresets)
            //        SelectedPresetPicturesListBox.Items.Add(bp); 
            //}
        }

        private void AddNewPresetName(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrWhiteSpace(AddNewPresetTextBox.Text) || !string.IsNullOrEmpty(AddNewPresetTextBox.Text))
                { 
                    string PresetName = AddNewPresetTextBox.Text;

                    AddNewPresetTextBox.Visible = false;
                    ListOfLoadedPresets.Add(new BackgroundPreset(PresetName));
                    HighlightedPresetName = AddNewPresetTextBox.Text;

                    AddNewPresetTextBox.Text = string.Empty;
                    PresetListBox.SetSelected(PresetListBox.Items.Count - 1, true);
                    DisplayedPresetEntries.Clear();
                }
                else
                {
                    AddNewPresetTextBox.Visible = false;
                }
            }
        }
        private void RenamePresetName(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrWhiteSpace(RenamePresetBox.Text) || !string.IsNullOrEmpty(RenamePresetBox.Text))
                {
                    BackgroundPreset preset = (BackgroundPreset)PresetListBox.SelectedItem;
                    string PresetName = RenamePresetBox.Text;
                    int SelectedPresetIndex = PresetListBox.SelectedIndex;
                    RenamePresetBox.Visible = false;

                    preset.PresetName = PresetName;
                    PresetListBox.Items.RemoveAt(SelectedPresetIndex);
                    PresetListBox.Items.Insert(SelectedPresetIndex, preset);
                    RenamePresetBox.Text = string.Empty;
                }
                else
                {
                    RenamePresetBox.Visible = false;
                }
            }
        }

        private void RightClick1RenamePreset(object sender, EventArgs e)
        {
            RenamePresetBox.Text = ((BackgroundPreset)PresetListBox.SelectedItem).PresetName;
            PresetListBox.SelectedItem = RenamePresetBox;

            this.RenamePresetBox.SelectionStart = 0;
            this.RenamePresetBox.SelectionLength = RenamePresetBox.Text.Length;
            RenamePresetBox.Visible = true;

            this.ActiveControl = RenamePresetBox;
        }

        private void RightClick1DeletePreset(object sender, EventArgs e)
        {
            PresetListBox.Items.RemoveAt(PresetListBox.SelectedIndex);
        }

        private void PresetBox2RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (SelectedPresetPicturesListBox.SelectedItem != null)
                {
                    EditWallpaperMenuItem.Enabled = true;
                    EditDateTimeMenuItem.Enabled = true;
                    DeleteWallpaperMenuItem.Enabled = true;
                }
                EditPresetMenu.Show(Cursor.Position);
            }
        }

        private void EditPresetLostFocusEvent(object sender, EventArgs e)
        {
            EditWallpaperMenuItem.Enabled = false;
            EditDateTimeMenuItem.Enabled = false;
            DeleteWallpaperMenuItem.Enabled = false;
        }

        private void RightClick2AddWallpaper(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = LastUsedPictureFolderDirectory;
            f.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //SelectedPresetPicturesListBox.Items.Add((Path.GetFileName(f.FileName)));
                TimeSelectWindow tsw = new TimeSelectWindow();
                tsw.ShowDialog();

                BackgroundPresetEntry bpentry = new BackgroundPresetEntry(Path.GetFullPath(f.FileName), tsw.TimeOfChange);
                ListOfLoadedPresets.First(s => s.PresetName == ((BackgroundPreset) PresetListBox.SelectedItem).PresetName).AddPresetEntry(bpentry);
                DisplayedPresetEntries.Add(bpentry);
                BGPreview.ImageLocation = bpentry.DirectoryPath;
                SelectedPresetPicturesListBox.SelectedItem = bpentry;
            }
        }

        private void RightClick2EditWallpaper(object sender, EventArgs e)
        {

        }

        private void RightClick2EditDateTime(object sender, EventArgs e)
        {

        }

        private void RightClick2DeleteWallpaper(object sender, EventArgs e)
        {
            BackgroundPresetEntry SelectedPreset = (BackgroundPresetEntry)SelectedPresetPicturesListBox.SelectedItem;
            DisplayedPresetEntries.Remove(SelectedPreset);
            ListOfLoadedPresets.First<BackgroundPreset>(bp => bp.PresetName == HighlightedPresetName).RemovePreset(SelectedPreset.PictureFileName);

            HighlightedPresetName = null;
            BGPreview.ImageLocation = null;
            SelectedPresetPicturesListBox.SelectedItem = null;
        }
    }
}
