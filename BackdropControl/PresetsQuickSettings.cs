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
            ListOfPresets = new List<BackgroundPreset>();
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
                    ListOfPresets.Add(LoadedPreset);
                    PresetListBox.Items.Add(LoadedPreset);
                }
            }
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

                PresetEditMenu.Show(Cursor.Position);
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
        private void List2_Click(object sender, MouseEventArgs e)
        {/*
            if (e.Button == MouseButtons.Right)
            {
                if (e.Y > listBox2.Items.Count * listBox2.ItemHeight)
                {
                    listBox2.ClearSelected();
                    listBox3.ClearSelected();
                    addMenu.Show(Cursor.Position);
                }
                else
                {
                    listBox2.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    listBox3.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);

                    string selectedPicturePath = presets[PresetListBox.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[PresetListBox.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;

                    editMenu.Show(Cursor.Position);
                }
            }
            else
            {
                if (e.Y > listBox2.Items.Count * listBox2.ItemHeight)
                {
                    listBox2.ClearSelected();
                    listBox3.ClearSelected();
                }
                else
                {
                    listBox2.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    listBox3.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    string selectedPicturePath = presets[PresetListBox.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[PresetListBox.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;
                }
            }*/
        }
        private void List3_Click(object sender, MouseEventArgs e)
        {/*
            if (e.Button == MouseButtons.Right)
            {
                if (e.Y > listBox2.Items.Count * listBox2.ItemHeight)
                {
                    listBox2.ClearSelected();
                    listBox3.ClearSelected();
                    addMenu.Show(Cursor.Position);
                }
                else
                {
                    listBox2.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    listBox3.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);

                    string selectedPicturePath = presets[PresetListBox.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[PresetListBox.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;

                    editMenu.Show(Cursor.Position);
                }
            }
            else
            {
                if (e.Y > listBox2.Items.Count * listBox2.ItemHeight)
                {
                    listBox2.ClearSelected();
                    listBox3.ClearSelected();
                }
                else
                {
                    listBox2.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    listBox3.SelectedIndex = listBox2.IndexFromPoint(e.X, e.Y);
                    string selectedPicturePath = presets[PresetListBox.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[PresetListBox.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;
                }
            }*/
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

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {/*
            List<string> check = new List<string>();    //pass into form to check if time already exists
            for (int i = 2; i < presets[PresetListBox.SelectedIndex].Count; i += 2)
            {
                check.Add(presets[PresetListBox.SelectedIndex][i]);
                System.Diagnostics.Debug.WriteLine(check[check.Count - 1]);
            }
            PresetEditForm PresetForm = new PresetEditForm(presets[PresetListBox.SelectedIndex][2 * (listBox2.SelectedIndex) + 1], presets[PresetListBox.SelectedIndex][2 * (listBox2.SelectedIndex) + 2], check);
            PresetForm.ShowDialog();

            string newTime = PresetForm.TimeValue;  //get new data, close form and clean resources
            string newPath = PresetForm.NewPath;

            PresetForm.Dispose();

            presets[PresetListBox.SelectedIndex].Add(newPath);
            presets[PresetListBox.SelectedIndex].Add(newTime);

            for (int i = 0; i < presets[PresetListBox.SelectedIndex].Count; i++)
                System.Diagnostics.Debug.WriteLine(presets[PresetListBox.SelectedIndex][i]);*/
        }


        public string DEFAULT_PRESET_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "BackdropControl Presets");
        public List<BackgroundPreset> ListOfPresets;

        private void RightClickAddPreset(object sender, EventArgs e)
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
                    PresetListBox.Items.Insert(0, new BackgroundPreset(PresetName));

                    AddNewPresetTextBox.Text = string.Empty;
                }
                PresetListBox.Items.RemoveAt(0);
            }
        }

        private void RightClickRenamePreset(object sender, EventArgs e)
        {
            AddNewPresetTextBox.Text = ((BackgroundPreset)PresetListBox.SelectedItem).PresetName;
            PresetListBox.SelectedItem = AddNewPresetTextBox;
        }

        private void RightClickDeletePreset(object sender, EventArgs e)
        {

        }
    }
}
