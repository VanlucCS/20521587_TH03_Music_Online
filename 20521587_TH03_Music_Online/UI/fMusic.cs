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
        public string Playing = "BH01";
        public bool stage = false;
        public int volumn = 1;
        //public double heso = 0
        public fMusic()
        {
            InitializeComponent();
            load_ListSong();
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.play();
            timer1.Start();
            //tabControl1.
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
                ListSong[i].maBh = songData.Rows[i][0].ToString();
                ListSong[i].tenBh = songData.Rows[i][1].ToString();
                ListSong[i].caSi = songData.Rows[i][3].ToString();
                ListSong[i].image = (Image)rm.GetObject(songData.Rows[i][0].ToString());
                ListSong[i].theLoai = songData.Rows[i][4].ToString();
                ListSong[i].time = songData.Rows[i][6].ToString().Substring(3);
                ListSong[i].playButtonClick += play_Click;
                ListSong[i].Ucclick += play_Click2;
                flowLayoutPanel1.Controls.Add(ListSong[i]);
            }
            flowLayoutPanel1.Refresh();
        }
        private void play_Click(object sender, EventArgs e)
        {
        }
        private void play_Click2(object sender, EventArgs e)
        {

            media.Ctlcontrols.stop();
            ucSong song = (ucSong)sender;
            Playing = song.maBh;
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.play();
            timer1.Start();

            //TimeSpan Time = TimeSpan.FromMinutes(media.currentMedia.duration);
            //MessageBox.Show(Time.ToString());
            //lbmediaend.Text = Time.ToString().Substring(0, 5);
            //return null;
        }
        private void gunaGradient2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fMusic_Load(object sender, EventArgs e)
        {

        }

        //private void guna2Button1_CheckedChanged(object sender, EventArgs e)
        //{
        //    //MessageBox.Show("abc");
        //}

        //private void guna2Button1_Click(object sender, EventArgs e)
        //{

        //}

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            //media.Ctlcontrols.play();
            //double value = ;
            if (media.currentMedia.duration != 0)
                gunaTrackBar1.Value = (int)(100.0 * (media.Ctlcontrols.currentPosition / media.currentMedia.duration));
            TimeSpan Time = TimeSpan.FromMinutes(media.Ctlcontrols.currentPosition);
            //MessageBox.Show(Time.ToString().Substring);
            lbmediaplaying.Text = Time.ToString().Substring(0, 5);
            TimeSpan Time2 = TimeSpan.FromMinutes(media.currentMedia.duration);
            //MessageBox.Show(Time.ToString());
            lbmediaend.Text = Time2.ToString().Substring(0, 5);
        }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            if (stage == false)
            {
                stage = true;
                btplay.Image = _20521587_TH03_Music_Online.Properties.Resources.play_button;

                media.Ctlcontrols.pause();

            }
            else
            {
                btplay.Image = _20521587_TH03_Music_Online.Properties.Resources.pause;
                stage = false;
                media.Ctlcontrols.play();

            }
            pictureBox6.Visible =!stage;
        }

        private void gunaTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            media.Ctlcontrols.currentPosition = (double)gunaTrackBar1.Value * media.currentMedia.duration / 100.0;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 0;
            mome_Image(sender);

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
            mome_Image(sender);
        }

        private void fMusic_FormClosing(object sender, FormClosingEventArgs e)
        {
            media.Ctlcontrols.stop();
        }
    }
}
