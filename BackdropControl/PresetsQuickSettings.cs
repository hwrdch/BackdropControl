using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BackdropControl.Resources;

namespace BackdropControl
{
    public partial class PresetsQuickSettings : Form
    {
        public PresetsQuickSettings()
        {
            InitializeComponent();
            PresetInit();
        }
        public void PresetInit()
        {
            ListOfLoadedPresets = new List<BackgroundPreset>();
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
                    BackgroundPreset LoadedPreset = new BackgroundPreset(Path.GetFileName(DEFAULT_PRESET_PATH));

                    for (int i = 0; i < nodes.Count; i++)
                    {
                        LoadedPreset.AddPresetEntry(new BackgroundPresetEntry(nodes[i]["Path"].InnerText, DateTime.Parse(nodes[i]["Time"].InnerText))); //load preset name
                    }
                    ListOfLoadedPresets.Add(LoadedPreset);
                    PresetListBox.Items.Add(LoadedPreset);
                }
            }
            LastUsedPictureFolderDirectory = DEFAULT_PRESET_PATH;
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

            SelectedPresetPicturesListBox.Items.Clear();
            if (ListOfLoadedPresets.Count > 0)
            {
                foreach (BackgroundPresetEntry entry in ListOfLoadedPresets.First
                        (match => match.PresetName == ((BackgroundPreset)PresetListBox.SelectedItem).PresetName).PresetEntries)
                    SelectedPresetPicturesListBox.Items.Add(entry); 
            }

            //else
            //{
            //    if (e.Y <= PresetListBox.Items.Count * PresetListBox.ItemHeight)
            //    {
            //        listBox2.Items.Clear();
            //        listBox3.Items.Clear();
            //        if (PresetListBox.SelectedIndex != -1)
            //        {
            //            for (int i = 1; i<presets[PresetListBox.SelectedIndex].Count(); i += 2)
            //            {
            //                listBox2.Items.Add(presets[PresetListBox.SelectedIndex][i]);
            //                listBox3.Items.Add(presets[PresetListBox.SelectedIndex][i + 1]);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        PresetListBox.ClearSelected();
            //    }
            //}
        }
        private void SelectedPresetEntryEvent(object sender, MouseEventArgs e)
        {
            
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
            PresetListBox.Items.Insert(0, AddNewPresetTextBox);
            AddNewPresetTextBox.Enabled = true;
            AddNewPresetTextBox.Visible = true;
            this.ActiveControl = AddNewPresetTextBox;

            AddNewPresetTextBox.Text = string.Empty;
        }

        private void AddNewPresetName(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (!string.IsNullOrWhiteSpace(AddNewPresetTextBox.Text) || !string.IsNullOrEmpty(AddNewPresetTextBox.Text))
                { 
                    string PresetName = AddNewPresetTextBox.Text;

                    AddNewPresetTextBox.Visible = false;
                    PresetListBox.Items.Insert(1, new BackgroundPreset(PresetName));

                    AddNewPresetTextBox.Text = string.Empty;
                    PresetListBox.Items.RemoveAt(0);
                    PresetListBox.SetSelected(0, true);
                }
                else
                {
                    AddNewPresetTextBox.Visible = false;
                    PresetListBox.Items.RemoveAt(0); 
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

        public string DEFAULT_PRESET_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl Presets");
        public List<BackgroundPreset> ListOfLoadedPresets;
        public string LastUsedPictureFolderDirectory;

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
                SelectedPresetPicturesListBox.Items.Add((Path.GetFileName(f.FileName)));
                //ListOfLoadedPresets.Add
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

        }
    }
}
