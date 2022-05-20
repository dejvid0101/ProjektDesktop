
namespace ProjektDesktop
{
    partial class PlayerCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.photo = new System.Windows.Forms.PictureBox();
            this.labelShirt = new System.Windows.Forms.Label();
            this.labelPosition = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.photo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelName.Location = new System.Drawing.Point(100, 23);
            this.labelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(76, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Ivan Ivanić";
            this.labelName.Click += new System.EventHandler(this.labelName_Click);
            // 
            // photo
            // 
            this.photo.Location = new System.Drawing.Point(2, 2);
            this.photo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.photo.Name = "photo";
            this.photo.Size = new System.Drawing.Size(94, 103);
            this.photo.TabIndex = 1;
            this.photo.TabStop = false;
            this.photo.Click += new System.EventHandler(this.photo_Click);
            // 
            // labelShirt
            // 
            this.labelShirt.AutoSize = true;
            this.labelShirt.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelShirt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelShirt.Location = new System.Drawing.Point(100, 50);
            this.labelShirt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelShirt.Name = "labelShirt";
            this.labelShirt.Size = new System.Drawing.Size(23, 20);
            this.labelShirt.TabIndex = 2;
            this.labelShirt.Text = "23";
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPosition.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.labelPosition.Location = new System.Drawing.Point(100, 79);
            this.labelPosition.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(127, 18);
            this.labelPosition.TabIndex = 3;
            this.labelPosition.Text = "central midfielder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 2);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // PlayerCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelPosition);
            this.Controls.Add(this.labelShirt);
            this.Controls.Add(this.photo);
            this.Controls.Add(this.labelName);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "PlayerCtrl";
            this.Size = new System.Drawing.Size(290, 108);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.UserControl1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.PictureBox photo;
        private System.Windows.Forms.Label labelShirt;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.Label label4;
    }
}
