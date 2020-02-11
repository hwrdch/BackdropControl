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
            LastUsedPictureFolderDirectory = SharedObjects.DEFAULT_PRESET_PATH;
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

            for (int i = 0; i < SharedObjects.ListOfLoadedPresets.Count; i++)
            {
                BackgroundPreset backgroundPreset = SharedObjects.ListOfLoadedPresets[i];

                PresetListBox.Items.Add(backgroundPreset);
                List<BackgroundPresetEntry> EntryList = backgroundPreset.GetPresetEntries();
                for (int j = 0; j < backgroundPreset.PresetEntries.Count; j++) 
                {
                    ListViewItem item = new ListViewItem(EntryList[j].PictureFileName);
                    item.SubItems.Add(EntryList[j].GetTimeOfChangeString());

                    SelectedPresetListView.Items.Insert(j, item);
                    CurrentListViewPresetEntries.Insert(j, EntryList[j]);
                }
            }
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
                BackgroundPreset preset = SharedObjects.ListOfLoadedPresets.FirstOrDefault<BackgroundPreset>(
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
            foreach (BackgroundPreset bp in SharedObjects.ListOfLoadedPresets)
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
            if (PresetListBox.SelectedItem != null)
                HighlightedPresetName = ((BackgroundPreset) PresetListBox.SelectedItem).PresetName;
        }

        private void PresetBox1SelectionChangedEvent(object sender, EventArgs e)
        {
            if (PresetListBox.SelectedItem != null) //selecting different preset
            {
                ClearSelectPresetListView();
                if (SharedObjects.ListOfLoadedPresets.Count > 0)
                {
                    foreach (BackgroundPresetEntry bpentry in SharedObjects.ListOfLoadedPresets[PresetListBox.SelectedIndex].GetPresetEntries())
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

                    SharedObjects.ListOfLoadedPresets.Add(bp);
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

                int AddedPresetIndex = SharedObjects.ListOfLoadedPresets.First(s => s.PresetName == ((BackgroundPreset) PresetListBox.SelectedItem).PresetName).InsertPresetEntry(bpentry);
                SelectedPresetListView.Items.Insert(AddedPresetIndex, item);
                CurrentListViewPresetEntries.Insert(AddedPresetIndex, bpentry);

                BGPreview.ImageLocation = bpentry.DirectoryPath;
                ApplyButton.Enabled = true;
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
                SharedObjects.ListOfLoadedPresets.First(s => s.PresetName == ((BackgroundPreset)PresetListBox.SelectedItem).PresetName).EditPresetEntry(bpentry, SelectedPresetListView.SelectedIndices[0]);

                SelectedPresetListView.SelectedItems[0].SubItems[0].Text = bpentry.PictureFileName;

                CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]] = bpentry;
                BGPreview.ImageLocation = bpentry.DirectoryPath;

                int x = SharedObjects.ListOfLoadedPresets.First(b => b.PresetName == PresetListBox.SelectedItem.ToString()).EditPresetEntry(bpentry, SelectedPresetListView.SelectedIndices[0]);
            }
        }

        private void RightClick2EditDateTime(object sender, EventArgs e)
        {
            BackgroundPresetEntry bp = CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]];
            TimeSelectWindow tsw = new TimeSelectWindow(bp.TimeOfChange.Hours.ToString(),
                                                            bp.TimeOfChange.Minutes.ToString(),
                                                                bp.TimeOfChange.Seconds.ToString(), ref CurrentListViewPresetEntries);
            tsw.ShowDialog();

            int index = SharedObjects.ListOfLoadedPresets[PresetListBox.SelectedIndex].EditPresetEntry(CurrentListViewPresetEntries[tsw.EditedPresetEntryIndex], tsw.EditedPresetEntryIndex);
            SelectedPresetListView.Items[tsw.EditedPresetEntryIndex].SubItems[0].Text = tsw.EditedPresetEntry.PictureFileName;
            SelectedPresetListView.Items[tsw.EditedPresetEntryIndex].SubItems[1].Text = tsw.EditedPresetEntry.GetTimeOfChangeString();

            int x = SharedObjects.ListOfLoadedPresets.First(b => b.PresetName == PresetListBox.SelectedItem.ToString()).EditPresetEntry(CurrentListViewPresetEntries[tsw.EditedPresetEntryIndex], tsw.EditedPresetEntryIndex);
        }

        private void RightClick2DeleteWallpaper(object sender, EventArgs e)
        {
            int index = SelectedPresetListView.SelectedIndices[0];
            BackgroundPresetEntry SelectedPreset = new BackgroundPresetEntry(CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].DirectoryPath,
                                                                                CurrentListViewPresetEntries[SelectedPresetListView.SelectedIndices[0]].TimeOfChange);
            SelectedPresetListView.Items[index].Selected = false;

            CurrentListViewPresetEntries.RemoveAt(index);
            SharedObjects.ListOfLoadedPresets.First<BackgroundPreset>(bp => bp.PresetName == HighlightedPresetName).RemovePreset(SelectedPreset.TimeOfChange);
            SelectedPresetListView.Items[index].Remove();

            SharedObjects.ListOfLoadedPresets.First<BackgroundPreset>(bp => bp.PresetName == HighlightedPresetName).RemovePreset(SelectedPreset.TimeOfChange);
            BGPreview.ImageLocation = null;
        }

        private void SerializePresetSettings(object sender, EventArgs e)
        {
            SharedObjects.DEFAULT_APP_LOCATION_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl");
            if (!Directory.Exists(SharedObjects.DEFAULT_APP_LOCATION_PATH))
            {
                Directory.CreateDirectory(SharedObjects.DEFAULT_APP_LOCATION_PATH);
            }

            foreach (BackgroundPreset Preset in SharedObjects.ListOfLoadedPresets)
            {
                string XMLFilePath = Path.Combine(SharedObjects.DEFAULT_PRESET_PATH, Preset.PresetName + ".xml");

                if (!File.Exists(XMLFilePath))
                {
                    using (XmlTextWriter writer = new XmlTextWriter(XMLFilePath, null))
                    {
                        writer.Formatting = Formatting.Indented;
                        writer.WriteStartDocument();
                        writer.WriteStartElement(Preset.PresetName, "");
                        foreach (BackgroundPresetEntry item in Preset.PresetEntries)
                        {
                            writer.WriteStartElement("PresetEntry", "");
                            writer.WriteElementString("FilePath", item.DirectoryPath);
                            writer.WriteElementString("TimeInterval", item.GetTimeOfChangeString());
                            writer.WriteElementString("EntryID", item.EntryID);
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Flush();
                    }
                }

                else    //implement master class serialized object
                {
                    
                }
            }
        }

        private void PresetSettingsCancel(object sender, EventArgs e)
        {
            //Done after master class of serialized objects is done.
            throw new NotImplementedException();
        }
    }
}
