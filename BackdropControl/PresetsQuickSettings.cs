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
        public BindingList<BackgroundPresetEntry> CurrentListViewPresetEntries = new BindingList<BackgroundPresetEntry>();
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
            SetupListView();
        }

        private void SetupListView()
        {
            SelectedPresetListView.View = View.Details;

            SelectedPresetListView.Columns.Add("Picture Name");
            SelectedPresetListView.Columns.Add("Time");
            SelectedPresetListView.GridLines = true;

            SelectedPresetListView.Columns[0].Width = SelectedPresetListView.Width / 2;
            SelectedPresetListView.Columns[1].Width = SelectedPresetListView.Width / 2;
        }

        void SelectViewWidthChange(object sender, ColumnWidthChangingEventArgs e)
        {
            e.NewWidth = this.SelectedPresetListView.Columns[e.ColumnIndex].Width;
            e.Cancel = true;
        }

        private void ClearSelectPresetListView()
        {
            int SameWidth = this.SelectedPresetListView.Columns[0].Width;

            SelectedPresetListView.Clear();
            CurrentListViewPresetEntries.Clear();
            SelectedPresetListView.View = View.Details;

            List<string> Columns = new List<string>() { "Picture Name", "Time" };
            Columns.ForEach(name => SelectedPresetListView.Columns.Add(name));
            SelectedPresetListView.Columns[0].Width = SameWidth;
            SelectedPresetListView.Columns[1].Width = SameWidth;
        }

        private void SelectedPresetChangedEvent(object sender, EventArgs e)
        {
            if (((BackgroundPreset)(PresetListBox.SelectedItem)).PresetName != HighlightedPresetName)
            {
                ClearSelectPresetListView();
                HighlightedPresetName = ((BackgroundPreset)(PresetListBox.SelectedItem)).PresetName;
                BackgroundPreset preset = ListOfLoadedPresets.FirstOrDefault<BackgroundPreset>(
                    s => s.PresetName == ((BackgroundPreset)PresetListBox.SelectedItem).PresetName);

                foreach (BackgroundPresetEntry entry in preset.GetPresetEntries())
                {
                    CurrentListViewPresetEntries.Add(entry);
                }
            }

            if (SelectedPresetListView.SelectedItems.Count > 0)
                BGPreview.ImageLocation = CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].DirectoryPath;
            else
                BGPreview.Image = null;
        }


        private void PresetListChangedEvent(object sender, EventArgs e)
        {
            PresetListBox.Items.Clear();
            foreach (BackgroundPreset bp in ListOfLoadedPresets)
                PresetListBox.Items.Add(bp);
        }

        private void RightClick1PresetBox(object sender, MouseEventArgs e)
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
            //PresetBox1SelectionChangedEvent()
        }

        private void PresetBox1SelectionChangedEvent(object sender, EventArgs e)
        {
            if (PresetListBox.SelectedItem != null) //selecting different preset
            {
                HighlightedPresetName = ListOfLoadedPresets[PresetListBox.SelectedIndex].PresetName;
                ClearSelectPresetListView();
                if (ListOfLoadedPresets.Count > 0)
                {
                    foreach (BackgroundPresetEntry bpentry in ListOfLoadedPresets[PresetListBox.SelectedIndex].GetPresetEntries())
                    {
                        CurrentListViewPresetEntries.Add(bpentry);

                        ListViewItem item = new ListViewItem(bpentry.PictureFileName);
                        item.SubItems.Add(bpentry.GetTimeOfChangeString());
                        SelectedPresetListView.Items.Add(item);
                    }
                }
            }
        }

        private void RightClick1AddPreset(object sender, EventArgs e)
        {
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

                    BackgroundPreset bp = new BackgroundPreset(PresetName);

                    ListOfLoadedPresets.Add(bp);
                    HighlightedPresetName = AddNewPresetTextBox.Text;
                    PresetListBox.Items.Add(bp);

                    AddNewPresetTextBox.Text = string.Empty;
                    PresetListBox.SetSelected(PresetListBox.Items.Count - 1, true);
                    CurrentListViewPresetEntries.Clear();
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

        private void SelectedPresetListViewRightClick(object sender, MouseEventArgs e)
        {
            if (PresetListBox.SelectedItem != null)
            {
                if (SelectedPresetListView.Items.Count > 0 && SelectedPresetListView.SelectedItems.Count > 0)
                {
                    BGPreview.ImageLocation = CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].DirectoryPath;
                }

                if (e.Button == MouseButtons.Right)
                {
                    if (SelectedPresetListView.SelectedItems.Count > 0)
                    {
                        EditWallpaperMenuItem.Enabled = true;
                        EditDateTimeMenuItem.Enabled = true;
                        DeleteWallpaperMenuItem.Enabled = true;
                    }
                    EditPresetMenu.Show(Cursor.Position);
                }
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
                TimeSelectWindow tsw = new TimeSelectWindow(CurrentListViewPresetEntries);
                tsw.ShowDialog();

                BackgroundPresetEntry bpentry = new BackgroundPresetEntry(Path.GetFullPath(f.FileName), tsw.TimeOfChange);
                ListViewItem item = new ListViewItem(bpentry.PictureFileName);
                item.SubItems.Add(bpentry.GetTimeOfChangeString());

                int AddedPresetIndex = ListOfLoadedPresets.First(s => s.PresetName == ((BackgroundPreset) PresetListBox.SelectedItem).PresetName).InsertPresetEntry(bpentry);
                SelectedPresetListView.Items.Insert(AddedPresetIndex, item);
                CurrentListViewPresetEntries.Insert(AddedPresetIndex, bpentry);

                BGPreview.ImageLocation = bpentry.DirectoryPath;
            }
        }

        private void RightClick2EditWallpaper(object sender, EventArgs e)
        {
            string lastDir = Path.GetDirectoryName(CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].PictureFileName);

            OpenFileDialog f = new OpenFileDialog();
            f.InitialDirectory = lastDir;
            f.Filter = "Image Files(*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";

            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                BackgroundPresetEntry bpentry = new BackgroundPresetEntry(Path.GetFullPath(f.FileName), CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].TimeOfChange);
                ListOfLoadedPresets.First(s => s.PresetName == ((BackgroundPreset)PresetListBox.SelectedItem).PresetName).EditPresetEntry(bpentry, SelectedPresetListView.SelectedIndices[0]);

                SelectedPresetListView.SelectedItems[0].SubItems[0].Text = bpentry.PictureFileName;

                CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]] = bpentry;
                BGPreview.ImageLocation = bpentry.DirectoryPath;
            }
        }

        private void RightClick2EditDateTime(object sender, EventArgs e)
        {
            BackgroundPresetEntry bp = CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]];
            TimeSelectWindow tsw = new TimeSelectWindow(bp.TimeOfChange.Hours.ToString(),
                                                            bp.TimeOfChange.Minutes.ToString(),
                                                                bp.TimeOfChange.Seconds.ToString(), ref CurrentListViewPresetEntries);
            tsw.ShowDialog();

            int index = ListOfLoadedPresets[PresetListBox.SelectedIndex].EditPresetEntry(CurrentListViewPresetEntries[tsw.EditedPresetEntryIndex], tsw.EditedPresetEntryIndex);
            SelectedPresetListView.Items[index].SubItems[0].Text = tsw.EditedPresetEntry.PictureFileName;
            SelectedPresetListView.Items[index].SubItems[1].Text = tsw.EditedPresetEntry.GetTimeOfChangeString();
        }

        private void RightClick2DeleteWallpaper(object sender, EventArgs e)
        {
            int index = SelectedPresetListView.SelectedIndices[0];
            BackgroundPresetEntry SelectedPreset = new BackgroundPresetEntry(CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].DirectoryPath,
                                                                                CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].TimeOfChange);
            SelectedPresetListView.Items[index].Selected = false;

            CurrentListViewPresetEntries.RemoveAt(index);
            ListOfLoadedPresets.First<BackgroundPreset>(bp => bp.PresetName == HighlightedPresetName).RemovePreset(SelectedPreset.TimeOfChange);
            SelectedPresetListView.Items[index].Remove();

            BGPreview.ImageLocation = null;
        }
    }
}
