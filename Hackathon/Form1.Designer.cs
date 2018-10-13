namespace Hackathon
{
    partial class Form1
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
            this.image = new System.Windows.Forms.PictureBox();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.imageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.controlBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // image
            // 
            this.image.Dock = System.Windows.Forms.DockStyle.Top;
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(782, 482);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.image.TabIndex = 1;
            this.image.TabStop = false;
            // 
            // controlBox
            // 
            this.controlBox.Controls.Add(this.imageLabel);
            this.controlBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlBox.Location = new System.Drawing.Point(0, 488);
            this.controlBox.Name = "controlBox";
            this.controlBox.Size = new System.Drawing.Size(782, 65);
            this.controlBox.TabIndex = 2;
            this.controlBox.TabStop = false;
            // 
            // imageLabel
            // 
            this.imageLabel.AutoSize = true;
            this.imageLabel.Location = new System.Drawing.Point(12, 28);
            this.imageLabel.Name = "imageLabel";
            this.imageLabel.Size = new System.Drawing.Size(113, 17);
            this.imageLabel.TabIndex = 1;
            this.imageLabel.Text = "Loading Image...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.controlBox);
            this.Controls.Add(this.image);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.Label imageLabel;
    }
}

