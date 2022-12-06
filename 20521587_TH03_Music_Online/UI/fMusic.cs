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
using WMPLib;
using System.IO;

namespace _20521587_TH03_Music_Online
{
    public partial class fMusic : Form
    {
        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        ListSongDAL ldal = new ListSongDAL();
        ReviewsDAL rdal = new ReviewsDAL();
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
            try
            {
                pictureBox1.Location = new Point(b.Location.X + 145, b.Location.Y - 44);

            }
            catch (Exception)
            {
            }
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
            flowLayoutPanel1.Height = listSongData.Rows.Count * 125;
            ucSong[] ListSong = new ucSong[listSongData.Rows.Count];
            for (int i = 0; i < listSongData.Rows.Count; i++)
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
            load_SongIn4(preSong.maBh);
            preSong.isPlaying = true;
            preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.pause_button__1_;
            Playing = preSong.maBh;
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.play();
            timer1.Start();
            preSong.BackColor = Color.FromArgb(192, 255, 255);
            flowLayoutPanel2.Controls.Clear();
            load_reivew();
            flowLayoutPanel2.Controls.Add(addReviewButton());

            guna2Button1_Click_1(guna2Button1,null);



            //TimeSpan Time = TimeSpan.FromMinutes(media.currentMedia.duration);
            //MessageBox.Show(Time.ToString());
            //lbmediaend.Text = Time.ToString().Substring(0, 5);
            //return null;
        }
        private void load_reivew()
        {
            ReviewsDAL rdal = new ReviewsDAL();

            DataTable dt = new DataTable();
            dt = rdal.Select();
            flowLayoutPanel2.Size = new Size(735,130*(dt.Rows.Count+2));
            foreach(DataRow dr in dt.Rows)
            {
                if(dr[0].ToString()==Playing)
                {
                    ucReviews rv = new ucReviews();
                    rv.ten = dr[2].ToString();
                    rv.danhGia = dr[3].ToString();
                    rv.rate = int.Parse(dr[4].ToString());
                    rv.like = int.Parse(dr[6].ToString());
                    rv.unLike = int.Parse(dr[7].ToString());
                    rv.thoiGian = DateTime.Parse(dr[5].ToString());
                    flowLayoutPanel2.Controls.Add(rv);
                }
            }
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
                if (tbVolumn.Value == 0)
                    pictureBox5.Image = _20521587_TH03_Music_Online.Properties.Resources.no_sound__1_;
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            IWMPPlaylist fullSong = media.newPlaylist("fullSongd", null);
            //WMPLib.IWMPMedia m1 = media.newMedia("./" + "BH01" + ".mp3");
            foreach(ucSong i in flowLayoutPanel1.Controls)
            {
                WMPLib.IWMPMedia m = media.newMedia("./" + i.maBh + ".mp3");
                fullSong.appendItem(m);
            }
            //fullSong.appendItem(m2);
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
            DataRow dr = listSongData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == mabh);
            richTextBox1.Clear();
            pbSongPic.Image=  (Image)rm.GetObject(mabh);
            lbSongTitleMain.Text = dr[1].ToString();
            lbAuthorMain.Text = dr[2].ToString();
            lbSingerMain.Text = dr[3].ToString();
            string lyricUrl = @".\"+mabh+".txt";
            string[] lines = System.IO.File.ReadAllLines(lyricUrl);
            //MessageBox.Show(lines.Length.ToString());
            richTextBox1.Size = new Size(500, lines.Length * 24);
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t" + line);
                richTextBox1.AppendText(line+"\n");
            }
            //lbAuthorMain.Text = dr[2].ToString();
            guna2HtmlLabel1.Top = richTextBox1.Top + richTextBox1.Height;
            panel2.Top = richTextBox1.Top + richTextBox1.Height;
            guna2HtmlLabel2.Top = guna2HtmlLabel1.Top + 40;
            pictureBox14.Top = guna2HtmlLabel2.Top + 40;
            flowLayoutPanel2.Top = pictureBox14.Top + 40;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 2;
            mome_Image(sender);
            guna2ComboBox1.Items.Clear();
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");
            foreach (string item in plLines)
            {
                guna2ComboBox1.Items.Add(item);
            }
            guna2ComboBox1.SelectedIndex = 0;
            load_PlayList(guna2ComboBox1.Text);

        }
        private void load_PlayList(string tenpl)
        {
            PlaylistDAL pdal = new PlaylistDAL();
            DataTable dt = new DataTable();
            dt = pdal.Select();
            flowLayoutPanel3.Controls.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                if(dr[1].ToString() == tenpl && dr[2].ToString()!= "FFFF")
                {
                    DataRow datasong = listSongData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == dr[2].ToString());
                    ucSong s = new ucSong();
                    s = new ucSong();
                    s.maBh = datasong[0].ToString();
                    s.tenBh = datasong[1].ToString();
                    s.caSi = datasong[3].ToString();
                    s.image = (Image)rm.GetObject(datasong[0].ToString());
                    s.theLoai = datasong[4].ToString();
                    s.time = datasong[6].ToString().Substring(3);
                    s.playButtonClick += play_Click;
                    s.Ucclick += play_Click2;
                    flowLayoutPanel3.Controls.Add(s);
                }

            }




        }
        private Button addReviewButton()
        {
            Button bt = new Button() { Width = 730, Height = 25, Text = "Thêm Đánh Giá" };
            bt.Click += new EventHandler(addReview);

            return bt;
        }
        private void update_review(object sender, EventArgs e)
        {
                // bấm thêm review tự gọi hàm này 
        }
        private void addReview(object sender, EventArgs e)
        {
            DataTable dt = rdal.Select();
            ucAddReview f = new ucAddReview();
            f.maBh = Playing;
            f.soDg = dt.Rows.Count + 1;
            f.ten = "Văn Lực";
            f.insertClick += update_review;
            foreach (Control i in flowLayoutPanel2.Controls)
            {
                if (i.GetType() == typeof(Button))
                {
                    flowLayoutPanel2.Controls.Remove(i);
                    break;
                }
            }
            flowLayoutPanel2.Controls.Add(f);
            flowLayoutPanel2.Controls.Add(addReviewButton());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            fAddPlayList f = new fAddPlayList();
            f.ShowDialog();
            // thêm tên play list
            string line = f.tenPlayList;
            string[] lines =
            {
                    line
                };
            string saveurl = "./PlayListName.txt";
            File.AppendAllLines(saveurl, lines);
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");
            PlaylistDAL pdal = new PlaylistDAL(); 
            pdal.Insert(plLines.Length, f.tenPlayList,"FFFF");

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_PlayList(guna2ComboBox1.Text);

        }
    }
}
