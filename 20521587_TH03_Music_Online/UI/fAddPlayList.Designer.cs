
namespace _20521587_TH03_Music_Online.UI
{
    partial class fAddPlayList
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
            this.tbNamePlaylist = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // tbNamePlaylist
            // 
            this.tbNamePlaylist.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbNamePlaylist.DefaultText = "";
            this.tbNamePlaylist.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.tbNamePlaylist.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.tbNamePlaylist.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.DisabledState.Parent = this.tbNamePlaylist;
            this.tbNamePlaylist.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.tbNamePlaylist.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.FocusedState.Parent = this.tbNamePlaylist;
            this.tbNamePlaylist.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.tbNamePlaylist.HoverState.Parent = this.tbNamePlaylist;
            this.tbNamePlaylist.Location = new System.Drawing.Point(94, 52);
            this.tbNamePlaylist.Name = "tbNamePlaylist";
            this.tbNamePlaylist.PasswordChar = '\0';
            this.tbNamePlaylist.PlaceholderText = "Nhập tên playlist";
            this.tbNamePlaylist.SelectedText = "";
            this.tbNamePlaylist.ShadowDecoration.Parent = this.tbNamePlaylist;
            this.tbNamePlaylist.Size = new System.Drawing.Size(602, 36);
            this.tbNamePlaylist.TabIndex = 0;
            // 
            // guna2Button1
            // 
            this.guna2Button1.CheckedState.Parent = this.guna2Button1;
            this.guna2Button1.CustomImages.Parent = this.guna2Button1;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.HoverState.Parent = this.guna2Button1;
            this.guna2Button1.Location = new System.Drawing.Point(312, 109);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.ShadowDecoration.Parent = this.guna2Button1;
            this.guna2Button1.Size = new System.Drawing.Size(150, 34);
            this.guna2Button1.TabIndex = 2;
            this.guna2Button1.Text = "Thêm PlayList";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // fAddPlayList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 176);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.tbNamePlaylist);
            this.Name = "fAddPlayList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm PlayList";
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox tbNamePlaylist;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
    }
}