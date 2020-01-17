using System;
using System.Windows.Forms;

namespace BackdropControl
{
    partial class TimeSelectWindow
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
            this.SECUpDown = new System.Windows.Forms.NumericUpDown();
            this.MINUpDown = new System.Windows.Forms.NumericUpDown();
            this.HRUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SECUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MINUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SECUpDown
            // 
            this.SECUpDown.Location = new System.Drawing.Point(73, 59);
            this.SECUpDown.Name = "SECUpDown";
            this.SECUpDown.Size = new System.Drawing.Size(38, 20);
            this.SECUpDown.TabIndex = 0;
            // 
            // MINUpDown
            // 
            this.MINUpDown.Location = new System.Drawing.Point(133, 59);
            this.MINUpDown.Name = "MINUpDown";
            this.MINUpDown.Size = new System.Drawing.Size(38, 20);
            this.MINUpDown.TabIndex = 1;
            // 
            // HRUpDown
            // 
            this.HRUpDown.Location = new System.Drawing.Point(12, 59);
            this.HRUpDown.Name = "HRUpDown";
            this.HRUpDown.Size = new System.Drawing.Size(38, 20);
            this.HRUpDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "HR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(137, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SEC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Choose the time for when the";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.UseMnemonic = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "wallpaper becomes active.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.UseMnemonic = false;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 2;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(60, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(61, 36);
            this.button1.TabIndex = 8;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.CheckTimeConflictButtonEvent);
            // 
            // TimeSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 159);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HRUpDown);
            this.Controls.Add(this.MINUpDown);
            this.Controls.Add(this.SECUpDown);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "TimeSelectWindow";
            this.Text = "Select Time";
            ((System.ComponentModel.ISupportInitialize)(this.SECUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MINUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ValidPresetTimeSelected);
        }

        #endregion

        private System.Windows.Forms.NumericUpDown SECUpDown;
        private System.Windows.Forms.NumericUpDown MINUpDown;
        private System.Windows.Forms.NumericUpDown HRUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
    }
}