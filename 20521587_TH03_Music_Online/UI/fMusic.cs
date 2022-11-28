﻿using _20521587_TH03_Music_Online.UI;
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
using WMPLib;

namespace _20521587_TH03_Music_Online
{
    public partial class fMusic : Form
    {
        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        ListSongDAL ldal = new ListSongDAL();
        DataTable listSongData = new DataTable();
        public string Playing = "BH01";
        public bool stage = false;
        //public bool soundo
        public bool soundOn = true;
        public int volumn = 1;
        public ucSong preSong;

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
        }

        private void load_ListSong()
        {
            listSongData = ldal.Select();

            ucSong[] ListSong = new ucSong[2];
            for (int i = 0; i < 2; i++)
            {
                ListSong[i] = new ucSong();
                ListSong[i].maBh = listSongData.Rows[i][0].ToString();
                ListSong[i].tenBh = listSongData.Rows[i][1].ToString();
                ListSong[i].caSi = listSongData.Rows[i][3].ToString();
                ListSong[i].image = (Image)rm.GetObject(listSongData.Rows[i][0].ToString());
                ListSong[i].theLoai = listSongData.Rows[i][4].ToString();
                ListSong[i].time = listSongData.Rows[i][6].ToString().Substring(3);
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
            if (preSong != null)
            {
                if (preSong != (ucSong)sender)
                {
                    //MessageBox.Show("khac");
                    preSong.BackColor = Color.White;
                    preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.play_button__1_;
                }
                else if (preSong == (ucSong)sender && preSong.isPlaying == true)
                {
                    preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.play_button__1_;
                    media.Ctlcontrols.pause();
                    timer1.Stop();
                    lbsongtitle.Text = "";

                    preSong.BackColor = Color.White;
                    preSong.isPlaying = false;
                    return;
                }
                else
                {
                    preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.pause_button__1_;
                    timer1.Start();
                    media.Ctlcontrols.play();
                    lbsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;

                    preSong.BackColor = Color.FromArgb(192, 255, 255);
                    preSong.isPlaying = true;
                    return;
                }
            }


            media.Ctlcontrols.stop();
            //MessageBox.Show("bai moi");
            preSong = (ucSong)sender;
            lbsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;
            preSong.isPlaying = true;
            preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.pause_button__1_;
            Playing = preSong.maBh;
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.play();
            timer1.Start();
            preSong.BackColor = Color.FromArgb(192, 255, 255);


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

        private void gunaWinSwitch1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox5_Click_1(object sender, EventArgs e)
        {
            if (soundOn)
            {
                pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.no_sound__1_;
                soundOn = false;
                media.settings.volume = 0;
                tbVolumn.Value = 0;
            }
            else
            {
                pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.medium_volume;
                soundOn = true;
                media.settings.volume = 50;
                tbVolumn.Value = 50;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            // update trackbar
            if (media.currentMedia.duration != 0)
                gunaTrackBar1.Value = (int)(100.0 * (media.Ctlcontrols.currentPosition / media.currentMedia.duration));
            TimeSpan Time = TimeSpan.FromMinutes(media.Ctlcontrols.currentPosition);

            // update time mediaplayer
            lbmediaplaying.Text = Time.ToString().Substring(0, 5);
            TimeSpan Time2 = TimeSpan.FromMinutes(media.currentMedia.duration);

            // Duration of song
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
            pictureBox6.Visible = !stage;
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

        private void tbVolumn_Scroll(object sender, ScrollEventArgs e)
        {
            media.settings.volume = tbVolumn.Value;
            if (!soundOn)
            {
                pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.medium_volume;
                soundOn = true;
            }
            if (soundOn)
            {
                if (tbVolumn.Value > 50)
                {
                    pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.high_volume;
                }
                else
                    pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.medium_volume;

            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            IWMPPlaylist fullSong = media.newPlaylist("fullSongd", null);
            WMPLib.IWMPMedia m1 = media.newMedia("./" + "BH01" + ".mp3");
            WMPLib.IWMPMedia m2 = media.newMedia("./" + "BH02" + ".mp3");
            fullSong.appendItem(m1);
            fullSong.appendItem(m2);
            //media.playlistCollection.
            media.currentPlaylist = fullSong;
            media.Ctlcontrols.play();
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            media.Ctlcontrols.next();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (cbtloop.Visible == false)
            {

                media.settings.setMode("loop", true);
                cbtloop.Visible = true;
            }
            else
            {
                media.settings.setMode("loop", false);
                cbtloop.Visible = false;
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if (cbtshuffer.Visible == false)
            {

                media.settings.setMode("shuffle", true);
                cbtshuffer.Visible = true;
            }
            else
            {
                media.settings.setMode("shuffle", false);
                cbtshuffer.Visible = false;
            }
        }
        private void load_SongIn4(string mabh)
        {
            DataRow dr = listSongData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MASP") == mabh);

            pbSongPic.Image=  (Image)rm.GetObject(mabh);
            lbSongTitleMain.Text = dr[1].ToString();
            lbAuthorMain.Text = dr[2].ToString();
            lbSingerMain.Text = dr[3].ToString();
            //lbAuthorMain.Text = dr[2].ToString();
        }
    }
}
