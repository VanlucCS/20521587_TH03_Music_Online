using _20521587_TH03_Music_Online.UI;
using _20521587_TH03_Music_Online.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;

namespace _20521587_TH03_Music_Online
{
    public partial class fMusic : Form
    {
        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        ListSongDAL ldal = new ListSongDAL();
        DataTable songData = new DataTable();
        public int volumn =1;
        public fMusic()
        {
            InitializeComponent();
            load_ListSong();

        }

        private void mome_Image(object sender)
        {

            Guna2Button b = (Guna2Button)sender;
            pictureBox1.Location = new Point(b.Location.X + 145, b.Location.Y - 44);
            pictureBox1.BringToFront();
            guna2Button1.BringToFront();
            guna2Button2.BringToFront();
            guna2Button3.BringToFront();
            guna2Button4.BringToFront();
            guna2Button5.BringToFront();
            b.SendToBack();
            //pictureBox1.Location = new Point(1,1);
        }
        private void load_ListSong()
        {
            songData = ldal.Select();

            ucSong[] ListSong = new ucSong[2];
            for (int i = 0; i < 2; i++)
            {
                ListSong[i] = new ucSong();
                ListSong[i].tenBh = songData.Rows[i][1].ToString();
                ListSong[i].caSi = songData.Rows[i][3].ToString();
                ListSong[i].image = (Image)rm.GetObject(songData.Rows[i][0].ToString());
                flowLayoutPanel1.Controls.Add(ListSong[i]);
            }
            flowLayoutPanel1.Refresh();
        }
        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fMusic_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("abc");
            mome_Image(sender);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            mome_Image(sender);

        }

        private void gunaWinSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            if (volumn == 1)
            {
                pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.mute;
                volumn = 0;
            }
            else
            {
                pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.volume;
                volumn = 1;
            }
        }

    }
}
