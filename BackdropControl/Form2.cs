using System;
using System.Xml;
using System.IO;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BackdropControl
{
    public partial class Form2 : Form
    {
        List<List<string>> presets = new List<List<string>>();
        public Form2()
        {
            InitializeComponent();
            PresetInit();
        }
        public void PresetInit()
        {
            if (!File.Exists("presetNames.xml"))
            {
                XmlTextWriter writer = new XmlTextWriter("presetNames.xml", Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartElement("root");
                writer.WriteEndElement();
                writer.Close();
            }

            else
            {
                XmlDocument doc = new XmlDocument();        //collect and locally store presets from file
                doc.Load("presetNames.xml");
                XmlElement root = doc.DocumentElement;
                XmlNodeList nodes = doc.DocumentElement.SelectNodes("Preset");
                for (int i = 0; i < nodes.Count; i++)
                {
                    presets.Add(new List<string>());
                    presets[i].Add(nodes[i]["Name"].InnerText); //load preset name

                    XmlNodeList paths = nodes[i].SelectNodes("Path");   //load preset's picture paths
                    XmlNodeList times = nodes[i].SelectNodes("Time");
                    for (int j = 0; j < paths.Count; j++)
                    {
                        presets[i].Add(paths[j].InnerText);
                        presets[i].Add(times[j].InnerText);
                    }
                }
                //no need to alphabetize list when loading XML because it should already be sorted
                for (int i = 0; i < presets.Count(); i++)
                {
                    listBox1.Items.Add(presets[i][0]);
                }
            }
        }
        private void List1_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.Y > listBox1.Items.Count * listBox1.ItemHeight)
                {
                    listBox1.ClearSelected();
                    AddPreset.Show(Cursor.Position);
                }
                else
                {
                    listBox1.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);
                    PresetEditMenu.Show(Cursor.Position);
                }
            }
            else
            {
                if (e.Y <= listBox1.Items.Count * listBox1.ItemHeight)
                {
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    if (listBox1.SelectedIndex != -1)
                        for (int i = 1; i < presets[listBox1.SelectedIndex].Count(); i += 2)
                        {
                            listBox2.Items.Add(
                                                presets[listBox1.SelectedIndex][i]
                                              );
                            listBox3.Items.Add(
                                                presets[listBox1.SelectedIndex][i+1]
                                              );
                        }
                }
                else
                {
                    listBox1.ClearSelected();
                }
            }
        }
        private void List2_Click(object sender, MouseEventArgs e)
        {
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

                    string selectedPicturePath = presets[listBox1.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[listBox1.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
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
                    string selectedPicturePath = presets[listBox1.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[listBox1.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;
                }
            }
        }
        private void List3_Click(object sender, MouseEventArgs e)
        {
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

                    string selectedPicturePath = presets[listBox1.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[listBox1.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
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
                    string selectedPicturePath = presets[listBox1.SelectedIndex][1 + listBox2.SelectedIndex * 2];
                    string selectedPicture = selectedPicturePath.Substring(selectedPicturePath.LastIndexOf("\\") + 1);
                    Directory.SetCurrentDirectory(selectedPicturePath.Substring(0, selectedPicturePath.Length - selectedPicture.Length - 1));
                    BGPreview.Image = Image.FromFile(selectedPicture);
                    timeStr.Text = TimeConvert(presets[listBox1.SelectedIndex][2 + listBox2.SelectedIndex * 2]);
                    pictureName.Text = selectedPicture;
                }
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

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PresetName f3 = new PresetName();
            f3.ShowDialog();
            string result = f3.textname;
            listBox1.Items.Add(result);

            if (f3.presetCreated)
            { 
                presets.Add(new List<string>());
                presets[presets.Count - 1].Add(result);
            }

            f3.Dispose();
        }
        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> check = new List<string>();    //pass into form to check if time already exists
            for (int i = 2; i < presets[listBox1.SelectedIndex].Count; i += 2)
            {
                check.Add(presets[listBox1.SelectedIndex][i]);
                System.Diagnostics.Debug.WriteLine(check[check.Count - 1]);
            }
            PresetEditForm PresetForm = new PresetEditForm(presets[listBox1.SelectedIndex][2 * (listBox2.SelectedIndex) + 1], presets[listBox1.SelectedIndex][2 * (listBox2.SelectedIndex) + 2], check);
            PresetForm.ShowDialog();

            string newTime = PresetForm.TimeValue;  //get new data, close form and clean resources
            string newPath = PresetForm.NewPath;
            PresetForm.Dispose();

            presets[listBox1.SelectedIndex].Add(newPath);
            presets[listBox1.SelectedIndex].Add(newTime);

            for (int i = 0; i < presets[listBox1.SelectedIndex].Count; i++)
                System.Diagnostics.Debug.WriteLine(presets[listBox1.SelectedIndex][i]);
        }
    }
}
