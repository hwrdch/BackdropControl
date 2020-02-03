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
            this.applybutton = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.settingsStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.exitStrip = new System.Windows.Forms.ToolStripMenuItem();
            this.timeLim = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.OpenPresetsSettingsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.watcher)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGchange
            // 
            this.BGchange.Location = new System.Drawing.Point(262, 58);
            this.BGchange.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BGchange.Name = "BGchange";
            this.BGchange.Size = new System.Drawing.Size(22, 19);
            this.BGchange.TabIndex = 0;
            this.BGchange.Text = "...";
            this.BGchange.UseVisualStyleBackColor = true;
            this.BGchange.Click += new System.EventHandler(this.BackgroundDirectoryChangeEvent);
            // 
            // BGTimer
            // 
            this.BackgroundChangeTimer.Tick += new System.EventHandler(this.BGTimer_Tick);
            // 
            // filepathLabel
            // 
            this.SelectedFolderLabel.AutoEllipsis = true;
            this.SelectedFolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectedFolderLabel.Location = new System.Drawing.Point(66, 58);
            this.SelectedFolderLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.SelectedFolderLabel.Name = "filepathLabel";
            this.SelectedFolderLabel.Size = new System.Drawing.Size(192, 19);
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
            this.label2.Location = new System.Drawing.Point(66, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time Interval of Change";
            // 
            // numMin
            // 
            this.numMin.Location = new System.Drawing.Point(319, 85);
            this.numMin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMin.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(32, 20);
            this.numMin.TabIndex = 5;
            this.numMin.ValueChanged += new System.EventHandler(this.numMin_ValueChanged);
            // 
            // numHour
            // 
            this.numHour.Location = new System.Drawing.Point(262, 85);
            this.numHour.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numHour.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(32, 20);
            this.numHour.TabIndex = 6;
            this.numHour.ValueChanged += new System.EventHandler(this.numHour_ValueChanged);
            // 
            // numSec
            // 
            this.numSec.Location = new System.Drawing.Point(385, 85);
            this.numSec.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numSec.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numSec.Name = "numSec";
            this.numSec.Size = new System.Drawing.Size(32, 20);
            this.numSec.TabIndex = 7;
            this.numSec.ValueChanged += new System.EventHandler(this.numSec_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(296, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "hr";
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(354, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoEllipsis = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(422, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "sec";
            // 
            // applybutton
            // 
            this.applybutton.Location = new System.Drawing.Point(331, 233);
            this.applybutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.applybutton.Name = "applybutton";
            this.applybutton.Size = new System.Drawing.Size(61, 24);
            this.applybutton.TabIndex = 12;
            this.applybutton.Text = "Apply";
            this.applybutton.UseVisualStyleBackColor = true;
            this.applybutton.Click += new System.EventHandler(this.applybutton_Click);
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 48);
            // 
            // settingsStrip
            // 
            this.settingsStrip.Name = "settingsStrip";
            this.settingsStrip.Size = new System.Drawing.Size(116, 22);
            this.settingsStrip.Text = "Settings";
            this.settingsStrip.Click += new System.EventHandler(this.settingsStrip_Click);
            // 
            // exitStrip
            // 
            this.exitStrip.Name = "exitStrip";
            this.exitStrip.Size = new System.Drawing.Size(116, 22);
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
            this.button1.Location = new System.Drawing.Point(396, 233);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 24);
            this.button1.TabIndex = 13;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.cancel_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(35, 28);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(86, 17);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Single Folder";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(35, 119);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(108, 17);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Custom Schedule";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(66, 153);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selected Preset";
            // 
            // comboBox1
            // 
            this.comboBox1.Location = new System.Drawing.Point(262, 153);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBox1.MaxDropDownItems = 10;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(156, 21);
            this.comboBox1.TabIndex = 17;
            // 
            // OpenPresetsSettingsButton
            // 
            this.OpenPresetsSettingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenPresetsSettingsButton.Location = new System.Drawing.Point(331, 177);
            this.OpenPresetsSettingsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OpenPresetsSettingsButton.Name = "OpenPresetsSettingsButton";
            this.OpenPresetsSettingsButton.Size = new System.Drawing.Size(86, 23);
            this.OpenPresetsSettingsButton.TabIndex = 18;
            this.OpenPresetsSettingsButton.Text = "Edit Presets";
            this.OpenPresetsSettingsButton.UseVisualStyleBackColor = true;
            this.OpenPresetsSettingsButton.Click += new System.EventHandler(this.OpenPresetsSettingsEvent);
            // 
            // WallpaperSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 281);
            this.Controls.Add(this.OpenPresetsSettingsButton);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.applybutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numSec);
            this.Controls.Add(this.numHour);
            this.Controls.Add(this.numMin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SelectedFolderLabel);
            this.Controls.Add(this.BGchange);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WallpaperSettings";
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
        private System.Windows.Forms.Button applybutton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsStrip;
        private System.Windows.Forms.ToolStripMenuItem exitStrip;
        private ToolTip timeLim;
        private Button button1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private ComboBox comboBox1;
        private Label label5;
        private Button OpenPresetsSettingsButton;
    }
}

