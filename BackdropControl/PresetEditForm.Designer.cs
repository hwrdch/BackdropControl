namespace BackdropControl
{
    partial class PresetEditForm
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
            this.ApplyButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DirButton = new System.Windows.Forms.Button();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.ClockPicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(51, 207);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(85, 34);
            this.ApplyButton.TabIndex = 16;
            this.ApplyButton.Text = "OK";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(142, 207);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(85, 34);
            this.CancelButton.TabIndex = 17;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // DirButton
            // 
            this.DirButton.Location = new System.Drawing.Point(227, 96);
            this.DirButton.Name = "DirButton";
            this.DirButton.Size = new System.Drawing.Size(30, 24);
            this.DirButton.TabIndex = 19;
            this.DirButton.Text = "...";
            this.DirButton.UseVisualStyleBackColor = true;
            this.DirButton.Click += new System.EventHandler(this.DirButton_Click);
            // 
            // PathTextBox
            // 
            this.PathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathTextBox.Location = new System.Drawing.Point(41, 96);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(180, 24);
            this.PathTextBox.TabIndex = 20;
            // 
            // ClockPicker
            // 
            this.ClockPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClockPicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.ClockPicker.Location = new System.Drawing.Point(41, 143);
            this.ClockPicker.Name = "ClockPicker";
            this.ClockPicker.ShowUpDown = true;
            this.ClockPicker.Size = new System.Drawing.Size(216, 24);
            this.ClockPicker.TabIndex = 21;
            // 
            // PresetEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.ClockPicker);
            this.Controls.Add(this.PathTextBox);
            this.Controls.Add(this.DirButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ApplyButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "PresetEditForm";
            this.Text = "PresetEditForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button DirButton;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.DateTimePicker ClockPicker;
    }
}