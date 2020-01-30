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
            this.TimeSelectConfirmButton = new System.Windows.Forms.Button();
            this.ConflictMessageLabel = new System.Windows.Forms.Label();
            this.TimeOfConflict = new System.Windows.Forms.Label();
            this.TimeOfConflictLabel = new System.Windows.Forms.Label();
            this.ChangeTimeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SECUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MINUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SECUpDown
            // 
            this.SECUpDown.Location = new System.Drawing.Point(148, 58);
            this.SECUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.SECUpDown.Name = "SECUpDown";
            this.SECUpDown.Size = new System.Drawing.Size(38, 20);
            this.SECUpDown.TabIndex = 0;
            // 
            // MINUpDown
            // 
            this.MINUpDown.Location = new System.Drawing.Point(86, 58);
            this.MINUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.MINUpDown.Name = "MINUpDown";
            this.MINUpDown.Size = new System.Drawing.Size(38, 20);
            this.MINUpDown.TabIndex = 1;
            // 
            // HRUpDown
            // 
            this.HRUpDown.Location = new System.Drawing.Point(27, 58);
            this.HRUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.HRUpDown.Name = "HRUpDown";
            this.HRUpDown.Size = new System.Drawing.Size(38, 20);
            this.HRUpDown.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "HR";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "MIN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "SEC";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 21);
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
            this.label5.Location = new System.Drawing.Point(40, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "wallpaper becomes active.";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.UseMnemonic = false;
            // 
            // TimeSelectConfirmButton
            // 
            this.TimeSelectConfirmButton.FlatAppearance.BorderSize = 2;
            this.TimeSelectConfirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeSelectConfirmButton.Location = new System.Drawing.Point(74, 140);
            this.TimeSelectConfirmButton.Name = "TimeSelectConfirmButton";
            this.TimeSelectConfirmButton.Size = new System.Drawing.Size(61, 36);
            this.TimeSelectConfirmButton.TabIndex = 8;
            this.TimeSelectConfirmButton.Text = "OK";
            this.TimeSelectConfirmButton.UseVisualStyleBackColor = true;
            this.TimeSelectConfirmButton.Click += new System.EventHandler(this.ConfirmSelectedTimeEvent);
            this.TimeSelectConfirmButton.Visible = false;
            // 
            // ConflictMessageLabel
            // 
            this.ConflictMessageLabel.AutoSize = true;
            this.ConflictMessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConflictMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.ConflictMessageLabel.Location = new System.Drawing.Point(15, 94);
            this.ConflictMessageLabel.Name = "ConflictMessageLabel";
            this.ConflictMessageLabel.Size = new System.Drawing.Size(181, 13);
            this.ConflictMessageLabel.TabIndex = 9;
            this.ConflictMessageLabel.Text = "Selected time has conflict with";
            this.ConflictMessageLabel.Visible = false;
            // 
            // TimeOfConflict
            // 
            this.TimeOfConflict.Location = new System.Drawing.Point(0, 0);
            this.TimeOfConflict.Name = "TimeOfConflict";
            this.TimeOfConflict.Size = new System.Drawing.Size(100, 23);
            this.TimeOfConflict.TabIndex = 12;
            // 
            // TimeOfConflictLabel
            // 
            this.TimeOfConflictLabel.AutoSize = true;
            this.TimeOfConflictLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeOfConflictLabel.ForeColor = System.Drawing.Color.Red;
            this.TimeOfConflictLabel.Location = new System.Drawing.Point(104, 115);
            this.TimeOfConflictLabel.Name = "TimeOfConflictLabel";
            this.TimeOfConflictLabel.Size = new System.Drawing.Size(0, 13);
            this.TimeOfConflictLabel.TabIndex = 11;
            this.TimeOfConflictLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TimeOfConflictLabel.Visible = false;
            // 
            // ChangeTimeButton
            // 
            this.ChangeTimeButton.FlatAppearance.BorderSize = 2;
            this.ChangeTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangeTimeButton.Location = new System.Drawing.Point(74, 140);
            this.ChangeTimeButton.Name = "ChangeTimeButton";
            this.ChangeTimeButton.Size = new System.Drawing.Size(61, 36);
            this.ChangeTimeButton.TabIndex = 13;
            this.ChangeTimeButton.Text = "OK";
            this.ChangeTimeButton.UseVisualStyleBackColor = true;
            this.ChangeTimeButton.Visible = false;
            this.ChangeTimeButton.Click += new EventHandler(this.ConfirmNewSelectedTimeEvent);
            // 
            // TimeSelectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 194);
            this.Controls.Add(this.ChangeTimeButton);
            this.Controls.Add(this.TimeOfConflictLabel);
            this.Controls.Add(this.TimeOfConflict);
            this.Controls.Add(this.ConflictMessageLabel);
            this.Controls.Add(this.TimeSelectConfirmButton);
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ValidPresetTimeSelected);
            ((System.ComponentModel.ISupportInitialize)(this.SECUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MINUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HRUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button TimeSelectConfirmButton;
        private Label ConflictMessageLabel;
        private Label TimeOfConflict;
        private Label TimeOfConflictLabel;
        private Button ChangeTimeButton;
    }
}