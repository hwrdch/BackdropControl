using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace BackdropControl
{
    partial class PresetsQuickSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PresetListBox = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BGPreview = new System.Windows.Forms.PictureBox();
            this.AddPreset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PresetEditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureName = new System.Windows.Forms.Label();
            this.timeStr = new System.Windows.Forms.Label();
            this.listBox3 = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.BGPreview)).BeginInit();
            this.AddPreset.SuspendLayout();
            this.PresetEditMenu.SuspendLayout();
            this.addMenu.SuspendLayout();
            this.editMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.ItemHeight = 16;
            this.PresetListBox.Location = new System.Drawing.Point(143, 376);
            this.PresetListBox.Name = "listBox1";
            this.PresetListBox.Size = new System.Drawing.Size(164, 132);
            this.PresetListBox.TabIndex = 0;
            this.PresetListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PresetBox1Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(313, 376);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(343, 132);
            this.listBox2.TabIndex = 1;
            this.listBox2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List2_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(15, 432);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(91, 38);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(15, 388);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(91, 38);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // BGPreview
            // 
            this.BGPreview.Location = new System.Drawing.Point(143, 12);
            this.BGPreview.Name = "BGPreview";
            this.BGPreview.Size = new System.Drawing.Size(629, 358);
            this.BGPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BGPreview.TabIndex = 7;
            this.BGPreview.TabStop = false;
            // 
            // AddPreset
            // 
            this.AddPreset.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AddPreset.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPresetToolStripMenuItem});
            this.AddPreset.Name = "AddPreset";
            this.AddPreset.Size = new System.Drawing.Size(151, 28);
            // 
            // addPresetToolStripMenuItem
            // 
            this.addPresetToolStripMenuItem.Name = "addPresetToolStripMenuItem";
            this.addPresetToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.addPresetToolStripMenuItem.Text = "Add Preset";
            this.addPresetToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // PresetEditMenu
            // 
            this.PresetEditMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.PresetEditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.PresetEditMenu.Name = "PresetEditMenu";
            this.PresetEditMenu.Size = new System.Drawing.Size(123, 52);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.renameToolStripMenuItem.Text = "Edit";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(122, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // addMenu
            // 
            this.addMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.addMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.addMenu.Name = "AddPreset";
            this.addMenu.Size = new System.Drawing.Size(107, 28);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 24);
            this.toolStripMenuItem1.Text = "Add";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.addToolStripMenuItem1_Click);
            // 
            // editMenu
            // 
            this.editMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.editMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.editMenu.Name = "AddPreset";
            this.editMenu.Size = new System.Drawing.Size(123, 28);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(122, 24);
            this.toolStripMenuItem2.Text = "Delete";
            // 
            // pictureName
            // 
            this.pictureName.AutoSize = true;
            this.pictureName.Location = new System.Drawing.Point(12, 37);
            this.pictureName.Name = "pictureName";
            this.pictureName.Size = new System.Drawing.Size(0, 17);
            this.pictureName.TabIndex = 8;
            // 
            // timeStr
            // 
            this.timeStr.AutoSize = true;
            this.timeStr.Location = new System.Drawing.Point(12, 85);
            this.timeStr.Name = "timeStr";
            this.timeStr.Size = new System.Drawing.Size(0, 17);
            this.timeStr.TabIndex = 9;
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.ItemHeight = 16;
            this.listBox3.Location = new System.Drawing.Point(662, 376);
            this.listBox3.MultiColumn = true;
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(110, 132);
            this.listBox3.TabIndex = 10;
            this.listBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.List3_Click);
            // 
            // PresetsQuickSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 513);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.timeStr);
            this.Controls.Add(this.pictureName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.PresetListBox);
            this.Controls.Add(this.BGPreview);
            this.Name = "PresetsQuickSettings";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.BGPreview)).EndInit();
            this.AddPreset.ResumeLayout(false);
            this.PresetEditMenu.ResumeLayout(false);
            this.addMenu.ResumeLayout(false);
            this.editMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BGPreview;
        private System.Windows.Forms.ContextMenuStrip AddPreset;
        private System.Windows.Forms.ToolStripMenuItem addPresetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip PresetEditMenu;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip addMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip editMenu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private Label pictureName;
        private Label timeStr;
        private ListBox listBox3;
    }
}