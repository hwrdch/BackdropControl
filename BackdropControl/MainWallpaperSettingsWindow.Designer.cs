using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BackdropControl
{
    partial class MainWallpaperSettingsWindow
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
        /// 

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWallpaperSettingsWindow));
            this.BGchange = new System.Windows.Forms.Button();
            this.BackgroundChangeTimer = new System.Windows.Forms.Timer(this.components);
            this.SelectedFolderLabel = new System.Windows.Forms.Label();
            this.watcher = new System.IO.FileSystemWatcher();
            this.label2 = new System.Windows.Forms.Label();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.numSec = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MainSettingsApplyButton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.timeLim = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.DirectorySelectOption = new System.Windows.Forms.RadioButton();
            this.PresetSettingSelectOption = new System.Windows.Forms.RadioButton();
            this.SelectedPresetLabel = new System.Windows.Forms.Label();
            this.MainSettingsPagePresetComboBox = new System.Windows.Forms.ComboBox();
            this.OpenPresetsSettingsButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGchange
            // 
            this.BGchange.Location = new System.Drawing.Point(349, 71);
            this.BGchange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BGchange.Name = "BGchange";
            this.BGchange.Size = new System.Drawing.Size(29, 23);
            this.BGchange.TabIndex = 0;
            this.BGchange.Text = "...";
            this.BGchange.UseVisualStyleBackColor = true;
            this.BGchange.Click += new System.EventHandler(this.BackgroundDirectoryChangeEvent);
            // 
            // BackgroundChangeTimer
            // 
            this.BackgroundChangeTimer.Tick += new System.EventHandler(this.DirectoryOptionMoveToNextImage);
            // 
            // SelectedFolderLabel
            // 
            this.SelectedFolderLabel.AutoEllipsis = true;
            this.SelectedFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolderLabel.Location = new System.Drawing.Point(88, 71);
            this.SelectedFolderLabel.Name = "SelectedFolderLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(256, 23);
            this.SelectedFolderLabel.TabIndex = 1;
            this.SelectedFolderLabel.Text = "Path Directory";
            // 
            // watcher
            // 
            this.watcher.EnableRaisingEvents = true;
            this.watcher.NotifyFilter = ((System.IO.NotifyFilters)((((System.IO.NotifyFilters.FileName | System.IO.NotifyFilters.DirectoryName) 
            | System.IO.NotifyFilters.LastWrite) 
            | System.IO.NotifyFilters.LastAccess)));
            this.watcher.SynchronizingObject = this;
            this.watcher.Changed += new System.IO.FileSystemEventHandler(this.watcher_Changed);
            this.watcher.Created += new System.IO.FileSystemEventHandler(this.watcher_Created);
            this.watcher.Deleted += new System.IO.FileSystemEventHandler(this.watcher_Deleted);
            this.watcher.Renamed += new System.IO.RenamedEventHandler(this.watcher_Renamed);
            // 
            // label2
            // 
            this.label2.AutoEllipsis = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time Interval of Change";
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(425, 105);
            this.numMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(43, 22);
            this.numMin.TabIndex = 5;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(349, 105);
            this.numHour.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(43, 22);
            this.numHour.TabIndex = 6;
            this.numHour.ValueChanged += new System.EventHandler(this.numHour_ValueChanged);
            // 
            // numSec
            // 
            this.numSec.Location = new System.Drawing.Point(513, 105);
            this.numSec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSec.Name = "numSec";
            this.numSec.Size = new System.Drawing.Size(43, 22);
            this.numSec.TabIndex = 7;
            this.numSec.ValueChanged += new System.EventHandler(this.numSec_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(395, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 22);
            this.label1.TabIndex = 8;
            this.label1.Text = "hr";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(472, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(563, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 22);
            this.label4.TabIndex = 10;
            this.label4.Text = "sec";
            // 
            // MainSettingsApplyButton
            // 
            this.MainSettingsApplyButton.Location = new System.Drawing.Point(441, 287);
            this.MainSettingsApplyButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainSettingsApplyButton.Name = "MainSettingsApplyButton";
            this.MainSettingsApplyButton.Size = new System.Drawing.Size(81, 30);
            this.MainSettingsApplyButton.TabIndex = 12;
            this.MainSettingsApplyButton.Text = "Apply";
            this.MainSettingsApplyButton.UseVisualStyleBackColor = true;
            this.MainSettingsApplyButton.Click += new System.EventHandler(this.SerializeMainSettings);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsStrip,
            this.exitStrip});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(132, 52);
            // 
            // settingsStrip
            // 
            this.settingsStrip.Name = "settingsStrip";
            this.settingsStrip.Size = new System.Drawing.Size(131, 24);
            this.settingsStrip.Text = "Settings";
            this.settingsStrip.Click += new System.EventHandler(this.settingsStrip_Click);
            // 
            // exitStrip
            // 
            this.exitStrip.Name = "exitStrip";
            this.exitStrip.Size = new System.Drawing.Size(131, 24);
            this.exitStrip.Text = "Exit";
            this.exitStrip.Click += new System.EventHandler(this.exitStrip_Click);
            // 
            // timeLim
            // 
            this.timeLim.AutoPopDelay = 2000;
            this.timeLim.InitialDelay = 200;
            this.timeLim.IsBalloon = true;
            this.timeLim.ReshowDelay = 100;
            this.timeLim.ToolTipTitle = "Value not set";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(528, 287);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 30);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MainSettingsCancel);
            // 
            // DirectorySelectOption
            // 
            this.DirectorySelectOption.AutoSize = true;
            this.DirectorySelectOption.Checked = true;
            this.DirectorySelectOption.Location = new System.Drawing.Point(47, 34);
            this.DirectorySelectOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DirectorySelectOption.Name = "DirectorySelectOption";
            this.DirectorySelectOption.Size = new System.Drawing.Size(129, 21);
            this.DirectorySelectOption.TabIndex = 14;
            this.DirectorySelectOption.TabStop = true;
            this.DirectorySelectOption.Text = "Single Directory";
            this.DirectorySelectOption.UseVisualStyleBackColor = true;
            this.DirectorySelectOption.CheckedChanged += new System.EventHandler(this.DirectoryUserSelectEvent);
            // 
            // PresetSettingSelectOption
            // 
            this.PresetSettingSelectOption.AutoSize = true;
            this.PresetSettingSelectOption.Location = new System.Drawing.Point(47, 146);
            this.PresetSettingSelectOption.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PresetSettingSelectOption.Name = "PresetSettingSelectOption";
            this.PresetSettingSelectOption.Size = new System.Drawing.Size(139, 21);
            this.PresetSettingSelectOption.TabIndex = 15;
            this.PresetSettingSelectOption.TabStop = true;
            this.PresetSettingSelectOption.Text = "Custom Schedule";
            this.PresetSettingSelectOption.UseVisualStyleBackColor = true;
            this.PresetSettingSelectOption.CheckedChanged += new EventHandler(this.PresetUserSelectEvent);
            // 
            // SelectedPresetLabel
            // 
            this.SelectedPresetLabel.AutoSize = true;
            this.SelectedPresetLabel.Enabled = false;
            this.SelectedPresetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedPresetLabel.Location = new System.Drawing.Point(88, 188);
            this.SelectedPresetLabel.Name = "SelectedPresetLabel";
            this.SelectedPresetLabel.Size = new System.Drawing.Size(112, 18);
            this.SelectedPresetLabel.TabIndex = 16;
            this.SelectedPresetLabel.Text = "Selected Preset";
            // 
            // MainSettingsPagePresetComboBox
            // 
            this.MainSettingsPagePresetComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MainSettingsPagePresetComboBox.Enabled = false;
            this.MainSettingsPagePresetComboBox.Location = new System.Drawing.Point(349, 188);
            this.MainSettingsPagePresetComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainSettingsPagePresetComboBox.Name = "MainSettingsPagePresetComboBox";
            this.MainSettingsPagePresetComboBox.Size = new System.Drawing.Size(207, 24);
            this.MainSettingsPagePresetComboBox.TabIndex = 17;
            this.MainSettingsPagePresetComboBox.SelectedValueChanged += new System.EventHandler(this.PresetComboBoxValueChangedEvent);
            // 
            // OpenPresetsSettingsButton
            // 
            this.OpenPresetsSettingsButton.Enabled = false;
            this.OpenPresetsSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPresetsSettingsButton.Location = new System.Drawing.Point(441, 218);
            this.OpenPresetsSettingsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OpenPresetsSettingsButton.Name = "OpenPresetsSettingsButton";
            this.OpenPresetsSettingsButton.Size = new System.Drawing.Size(115, 28);
            this.OpenPresetsSettingsButton.TabIndex = 18;
            this.OpenPresetsSettingsButton.Text = "Edit Presets";
            this.OpenPresetsSettingsButton.UseVisualStyleBackColor = true;
            this.OpenPresetsSettingsButton.Click += new System.EventHandler(this.OpenPresetsSettingsEvent);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "label6";
            this.label6.Visible = false;
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(16, 319);
            this.StatusLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(46, 17);
            this.StatusLabel.TabIndex = 20;
            this.StatusLabel.Text = "label7";
            this.StatusLabel.Visible = false;
            // 
            // MainWallpaperSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 346);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.OpenPresetsSettingsButton);
            this.Controls.Add(this.MainSettingsPagePresetComboBox);
            this.Controls.Add(this.SelectedPresetLabel);
            this.Controls.Add(this.PresetSettingSelectOption);
            this.Controls.Add(this.DirectorySelectOption);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MainSettingsApplyButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSec);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectedFolderLabel);
            this.Controls.Add(this.BGchange);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWallpaperSettingsWindow";
            this.Text = "Wallpaper Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closeForm);
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BGchange;
        private System.Windows.Forms.Timer BackgroundChangeTimer;
        private System.Windows.Forms.Label SelectedFolderLabel;
        private System.IO.FileSystemWatcher watcher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSec;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.Button MainSettingsApplyButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsStrip;
        private System.Windows.Forms.ToolStripMenuItem exitStrip;
        private ToolTip timeLim;
        private Button button1;
        private RadioButton PresetSettingSelectOption;
        private RadioButton DirectorySelectOption;
        private ComboBox MainSettingsPagePresetComboBox;
        private Label SelectedPresetLabel;
        private Button OpenPresetsSettingsButton;
        private Label StatusLabel;
        private Label label6;
    }
}

