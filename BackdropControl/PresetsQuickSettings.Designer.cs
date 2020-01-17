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
            this.SelectedPresetPicturesListBox = new System.Windows.Forms.ListBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BGPreview = new System.Windows.Forms.PictureBox();
            this.AddPreset = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPresetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddEditDeletePresetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RightClickAddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickRenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RightClickDeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureName = new System.Windows.Forms.Label();
            this.timeStr = new System.Windows.Forms.Label();
            this.AddNewPresetTextBox = new System.Windows.Forms.TextBox();
            this.EditPresetMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddWallpaperMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditWallpaperMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditDateTimeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteWallpaperMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenamePresetBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BGPreview)).BeginInit();
            this.AddPreset.SuspendLayout();
            this.AddEditDeletePresetMenu.SuspendLayout();
            this.EditPresetMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // PresetListBox
            // 
            this.PresetListBox.DisplayMember = "((BackgroundPreset)this).PresetName";
            this.PresetListBox.FormattingEnabled = true;
            this.PresetListBox.Location = new System.Drawing.Point(107, 306);
            this.PresetListBox.Margin = new System.Windows.Forms.Padding(2);
            this.PresetListBox.Name = "PresetListBox";
            this.PresetListBox.Size = new System.Drawing.Size(124, 108);
            this.PresetListBox.TabIndex = 0;
            this.PresetListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PresetBox1Click);
            // 
            // SelectedPresetPicturesListBox
            // 
            this.SelectedPresetPicturesListBox.FormattingEnabled = true;
            this.SelectedPresetPicturesListBox.Location = new System.Drawing.Point(235, 306);
            this.SelectedPresetPicturesListBox.Margin = new System.Windows.Forms.Padding(2);
            this.SelectedPresetPicturesListBox.Name = "SelectedPresetPicturesListBox";
            this.SelectedPresetPicturesListBox.Size = new System.Drawing.Size(342, 108);
            this.SelectedPresetPicturesListBox.TabIndex = 1;
            this.SelectedPresetPicturesListBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SelectedPresetEntryEvent);
            this.SelectedPresetPicturesListBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PresetBox2RightClick);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(11, 351);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(2);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(68, 31);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(11, 315);
            this.ApplyButton.Margin = new System.Windows.Forms.Padding(2);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(68, 31);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Selected:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // BGPreview
            // 
            this.BGPreview.Location = new System.Drawing.Point(107, 10);
            this.BGPreview.Margin = new System.Windows.Forms.Padding(2);
            this.BGPreview.Name = "BGPreview";
            this.BGPreview.Size = new System.Drawing.Size(472, 291);
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
            this.AddPreset.Size = new System.Drawing.Size(68, 26);
            // 
            // addPresetToolStripMenuItem
            // 
            this.addPresetToolStripMenuItem.Name = "addPresetToolStripMenuItem";
            this.addPresetToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // AddEditDeletePresetMenu
            // 
            this.AddEditDeletePresetMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.AddEditDeletePresetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RightClickAddMenuItem,
            this.RightClickRenameMenuItem,
            this.RightClickDeleteMenuItem});
            this.AddEditDeletePresetMenu.Name = "PresetEditMenu";
            this.AddEditDeletePresetMenu.Size = new System.Drawing.Size(132, 70);
            // 
            // RightClickAddMenuItem
            // 
            this.RightClickAddMenuItem.Name = "RightClickAddMenuItem";
            this.RightClickAddMenuItem.Size = new System.Drawing.Size(131, 22);
            this.RightClickAddMenuItem.Text = "Add Preset";
            this.RightClickAddMenuItem.Click += new System.EventHandler(this.RightClick1AddPreset);
            // 
            // RightClickRenameMenuItem
            // 
            this.RightClickRenameMenuItem.Enabled = false;
            this.RightClickRenameMenuItem.Name = "RightClickRenameMenuItem";
            this.RightClickRenameMenuItem.Size = new System.Drawing.Size(131, 22);
            this.RightClickRenameMenuItem.Text = "Rename...";
            this.RightClickRenameMenuItem.Click += new System.EventHandler(this.RightClick1RenamePreset);
            // 
            // RightClickDeleteMenuItem
            // 
            this.RightClickDeleteMenuItem.Enabled = false;
            this.RightClickDeleteMenuItem.Name = "RightClickDeleteMenuItem";
            this.RightClickDeleteMenuItem.Size = new System.Drawing.Size(131, 22);
            this.RightClickDeleteMenuItem.Text = "Delete...";
            this.RightClickDeleteMenuItem.Click += new System.EventHandler(this.RightClick1DeletePreset);
            // 
            // pictureName
            // 
            this.pictureName.AutoSize = true;
            this.pictureName.Location = new System.Drawing.Point(9, 30);
            this.pictureName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pictureName.Name = "pictureName";
            this.pictureName.Size = new System.Drawing.Size(0, 13);
            this.pictureName.TabIndex = 8;
            // 
            // timeStr
            // 
            this.timeStr.AutoSize = true;
            this.timeStr.Location = new System.Drawing.Point(9, 69);
            this.timeStr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeStr.Name = "timeStr";
            this.timeStr.Size = new System.Drawing.Size(0, 13);
            this.timeStr.TabIndex = 9;
            // 
            // AddNewPresetTextBox
            // 
            this.AddNewPresetTextBox.Location = new System.Drawing.Point(107, 306);
            this.AddNewPresetTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.AddNewPresetTextBox.Name = "AddNewPresetTextBox";
            this.AddNewPresetTextBox.Size = new System.Drawing.Size(124, 20);
            this.AddNewPresetTextBox.TabIndex = 11;
            this.AddNewPresetTextBox.Visible = false;
            this.AddNewPresetTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddNewPresetName);
            // 
            // EditPresetMenu
            // 
            this.EditPresetMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddWallpaperMenuItem,
            this.EditWallpaperMenuItem,
            this.EditDateTimeMenuItem,
            this.DeleteWallpaperMenuItem});
            this.EditPresetMenu.Name = "EditPresetMenu";
            this.EditPresetMenu.Size = new System.Drawing.Size(164, 92);
            this.EditPresetMenu.LostFocus += new System.EventHandler(this.EditPresetLostFocusEvent);
            // 
            // AddWallpaperMenuItem
            // 
            this.AddWallpaperMenuItem.Name = "AddWallpaperMenuItem";
            this.AddWallpaperMenuItem.Size = new System.Drawing.Size(163, 22);
            this.AddWallpaperMenuItem.Text = "Add Wallpaper";
            this.AddWallpaperMenuItem.Click += new System.EventHandler(this.RightClick2AddWallpaper);
            // 
            // EditWallpaperMenuItem
            // 
            this.EditWallpaperMenuItem.Enabled = false;
            this.EditWallpaperMenuItem.Name = "EditWallpaperMenuItem";
            this.EditWallpaperMenuItem.Size = new System.Drawing.Size(163, 22);
            this.EditWallpaperMenuItem.Text = "Edit Wallpaper";
            this.EditWallpaperMenuItem.Click += new System.EventHandler(this.RightClick2EditWallpaper);
            // 
            // EditDateTimeMenuItem
            // 
            this.EditDateTimeMenuItem.Enabled = false;
            this.EditDateTimeMenuItem.Name = "EditDateTimeMenuItem";
            this.EditDateTimeMenuItem.Size = new System.Drawing.Size(163, 22);
            this.EditDateTimeMenuItem.Text = "Edit Date/Time";
            this.EditDateTimeMenuItem.Click += new System.EventHandler(this.RightClick2EditDateTime);
            // 
            // DeleteWallpaperMenuItem
            // 
            this.DeleteWallpaperMenuItem.Enabled = false;
            this.DeleteWallpaperMenuItem.Name = "DeleteWallpaperMenuItem";
            this.DeleteWallpaperMenuItem.Size = new System.Drawing.Size(163, 22);
            this.DeleteWallpaperMenuItem.Text = "Delete Wallpaper";
            this.DeleteWallpaperMenuItem.Click += new System.EventHandler(this.RightClick2DeleteWallpaper);
            // 
            // RenamePresetBox
            // 
            this.RenamePresetBox.Location = new System.Drawing.Point(107, 306);
            this.RenamePresetBox.Margin = new System.Windows.Forms.Padding(2);
            this.RenamePresetBox.Name = "RenamePresetBox";
            this.RenamePresetBox.Size = new System.Drawing.Size(124, 20);
            this.RenamePresetBox.TabIndex = 12;
            this.RenamePresetBox.Visible = false;
            this.RenamePresetBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RenamePresetName);
            // 
            // PresetsQuickSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 417);
            this.Controls.Add(this.RenamePresetBox);
            this.Controls.Add(this.AddNewPresetTextBox);
            this.Controls.Add(this.timeStr);
            this.Controls.Add(this.pictureName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SelectedPresetPicturesListBox);
            this.Controls.Add(this.PresetListBox);
            this.Controls.Add(this.BGPreview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PresetsQuickSettings";
            this.Text = "Presets Settings";
            ((System.ComponentModel.ISupportInitialize)(this.BGPreview)).EndInit();
            this.AddPreset.ResumeLayout(false);
            this.AddEditDeletePresetMenu.ResumeLayout(false);
            this.EditPresetMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PresetListBox;
        private System.Windows.Forms.ListBox SelectedPresetPicturesListBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox BGPreview;
        private System.Windows.Forms.ContextMenuStrip AddPreset;
        private System.Windows.Forms.ToolStripMenuItem addPresetToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip AddEditDeletePresetMenu;
        private System.Windows.Forms.ToolStripMenuItem RightClickRenameMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RightClickDeleteMenuItem;
        private Label pictureName;
        private Label timeStr;
        private ToolStripMenuItem RightClickAddMenuItem;
        private TextBox AddNewPresetTextBox;
        private TextBox RenamePresetBox;
        private ContextMenuStrip EditPresetMenu;
        private ToolStripMenuItem AddWallpaperMenuItem;
        private ToolStripMenuItem EditWallpaperMenuItem;
        private ToolStripMenuItem EditDateTimeMenuItem;
        private ToolStripMenuItem DeleteWallpaperMenuItem;
    }
}