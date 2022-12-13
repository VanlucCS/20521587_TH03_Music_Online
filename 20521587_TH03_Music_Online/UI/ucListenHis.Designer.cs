
namespace _20521587_TH03_Music_Online.UI
{
    partial class ucListenHis
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
            this.lbLuotNghe = new System.Windows.Forms.Label();
            this.lbthoidiem = new System.Windows.Forms.Label();
            this.lbgio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbLuotNghe
            // 
            this.lbLuotNghe.AutoSize = true;
            this.lbLuotNghe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLuotNghe.Location = new System.Drawing.Point(9, 49);
            this.lbLuotNghe.Name = "lbLuotNghe";
            this.lbLuotNghe.Size = new System.Drawing.Size(18, 19);
            this.lbLuotNghe.TabIndex = 5;
            this.lbLuotNghe.Text = "9";
            // 
            // lbthoidiem
            // 
            this.lbthoidiem.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbthoidiem.Location = new System.Drawing.Point(41, 39);
            this.lbthoidiem.Name = "lbthoidiem";
            this.lbthoidiem.Size = new System.Drawing.Size(93, 19);
            this.lbthoidiem.TabIndex = 6;
            this.lbthoidiem.Text = "11/11/2022";
            this.lbthoidiem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbgio
            // 
            this.lbgio.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgio.Location = new System.Drawing.Point(41, 58);
            this.lbgio.Name = "lbgio";
            this.lbgio.Size = new System.Drawing.Size(93, 19);
            this.lbgio.TabIndex = 7;
            this.lbgio.Text = "11:11";
            this.lbgio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucListenHis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbgio);
            this.Controls.Add(this.lbthoidiem);
            this.Controls.Add(this.lbLuotNghe);
            this.Name = "ucListenHis";
            this.Size = new System.Drawing.Size(150, 118);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbLuotNghe;
        private System.Windows.Forms.Label lbthoidiem;
        private System.Windows.Forms.Label lbgio;
    }
}
