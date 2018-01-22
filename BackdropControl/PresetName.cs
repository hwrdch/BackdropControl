using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BackdropControl
{
    public partial class PresetName : Form
    {
        private bool OKOrCancel;
        public string textname
        {
            get { return textBox1.Text; }
        }
        public bool presetCreated
        {
            get { return this.OKOrCancel; }
            set { this.OKOrCancel = value; }
        }
        public PresetName()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            OKOrCancel = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            OKOrCancel = false;
            this.Close();
        }
    }
}
