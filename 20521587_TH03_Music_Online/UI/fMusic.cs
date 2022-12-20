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
using System.Configuration;
using System.Diagnostics;
using System.Threading;

namespace _20521587_TH03_Music_Online
{
    public partial class fMusic : Form
    {
        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        ListSongDAL ldal = new ListSongDAL();
        ReviewsDAL rdal = new ReviewsDAL();
        UserDAL udal = new UserDAL();
        FvorSongDAL fvordal = new FvorSongDAL();
        ListenHisDAL lhisdal = new ListenHisDAL();

        DataTable listenHisData = new DataTable();

        DataTable listSongData = new DataTable();
        DataTable userdata = new DataTable();
        DataTable favorData = new DataTable();

        public string Playing = "BH01";
        public bool stage = true;
        //public bool soundo
        public bool soundOn = true;
        public int volumn = 1;
        public ucSong preSong;
        public string userName = "Văn Lực";
        public string userID = "US05";
        public float rating = 5;
        //public double heso = 0
        public fMusic()
        {
            InitializeComponent();
            //this.IsMdiContainer = true;
            load_ListSong();
            userdata = udal.Select();
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.stop();
            pictureBox6.Visible = false;
            timer1.Start();
            tabControl1.SelectedIndex = 1;
            guna2ShadowForm1.SetShadowForm(this);
        }

        private void mome_Image(object sender)
        {

            Guna2Button b = (Guna2Button)sender;
            try
            {
                pictureBox1.Location = new Point(b.Location.X + 157, b.Location.Y - 44);
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
            flowLayoutPanel1.Controls.Clear();
            listSongData = ldal.Select();
            favorData = fvordal.Select();

            flowLayoutPanel1.Height = listSongData.Rows.Count * 125;
            ucSong[] ListSong = new ucSong[listSongData.Rows.Count];
            for (int i = 0; i < listSongData.Rows.Count; i++)
            {
                ListSong[i] = new ucSong();
                ListSong[i].maBh = listSongData.Rows[i][0].ToString();
                ListSong[i].tenBh = listSongData.Rows[i][1].ToString();
                ListSong[i].tacGia = listSongData.Rows[i][2].ToString();
                ListSong[i].caSi = listSongData.Rows[i][3].ToString();
                ListSong[i].image = (Image)rm.GetObject(listSongData.Rows[i][0].ToString());
                ListSong[i].theLoai = listSongData.Rows[i][4].ToString();
                ListSong[i].quocGia = listSongData.Rows[i][5].ToString();
                ListSong[i].time = listSongData.Rows[i][6].ToString().Substring(3);
                if ((favorData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == listSongData.Rows[i][0].ToString()) != null))
                    ListSong[i].isFavor = true;
                else
                    ListSong[i].isFavor = false;
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
                    pictureBox6.Visible = false;
                    timer1.Stop();
                    //lbsongtitle.Text = "";
                    btsongtitle.Text = "";

                    preSong.BackColor = Color.White;
                    preSong.isPlaying = false;
                    return;
                }
                else
                {
                    preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.pause_button__1_;
                    timer1.Start();
                    media.Ctlcontrols.play();
                    pictureBox6.Visible = true;
                    //lbsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;
                    btsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;

                    preSong.BackColor = Color.FromArgb(192, 255, 255);
                    preSong.isPlaying = true;
                    return;
                }
            }
            stage = true;
            btplay.Image = _20521587_TH03_Music_Online.Properties.Resources.pause;
            media.Ctlcontrols.stop();
            pictureBox6.Visible = false;
            //MessageBox.Show("bai moi");
            preSong = (ucSong)sender;

            //lbsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;
            btsongtitle.Text = preSong.tenBh + "  -  " + preSong.caSi;
            load_SongIn4(preSong.maBh);
            if (preSong.isFavor)
            {
                pictureBox21.Image = _20521587_TH03_Music_Online.Properties.Resources.tim4;
            }
            else
                pictureBox21.Image = _20521587_TH03_Music_Online.Properties.Resources.tim3;

            preSong.isPlaying = true;
            preSong.playButton = _20521587_TH03_Music_Online.Properties.Resources.pause_button__1_;
            Playing = preSong.maBh;
            media.URL = "./" + Playing + ".mp3";
            media.Ctlcontrols.play();
            pictureBox6.Visible = true;
            // thêm vào lịch sử nghe gần đây
            listenHisData = lhisdal.Select();
            DataRow dr = listenHisData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == Playing);
            if (dr != null)
                lhisdal.Update(Playing, (int.Parse(dr[1].ToString()) + 1));
            else
                lhisdal.Insert(Playing);
            guna2Button1.Visible = true;
            timer1.Start();
            preSong.BackColor = Color.FromArgb(192, 255, 255);
            flowLayoutPanel2.Controls.Clear();

            // load đánh giá của bài hát 
            load_reivew();

            // button thêm đánh giá mới cho bài hát
            flowLayoutPanel2.Controls.Add(addReviewButton());

            guna2Button1_Click_1(guna2Button1, null);



            //TimeSpan Time = TimeSpan.FromMinutes(media.currentMedia.duration);
            //MessageBox.Show(Time.ToString());
            //lbmediaend.Text = Time.ToString().Substring(0, 5);
            //return null;
        }
        private void load_reivew()
        {
            ReviewsDAL rdal = new ReviewsDAL();
            // prop

            DataTable dt = new DataTable();
            float everageRate = 0;
            int countSongRate = 0;
            dt = rdal.Select();
            flowLayoutPanel2.Size = new Size(735, 130 * (dt.Rows.Count + 2));
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[0].ToString() == Playing)
                {
                    ucReviews rv = new ucReviews();
                    rv.ten = dr[2].ToString();
                    rv.danhGia = dr[3].ToString();
                    rv.rateStart = float.Parse(dr[4].ToString());
                    everageRate += float.Parse(dr[4].ToString());
                    rv.like = int.Parse(dr[6].ToString());
                    rv.unLike = int.Parse(dr[7].ToString());
                    rv.thoiGian = DateTime.Parse(dr[5].ToString());
                    rv.reviewData = dr;
                    try
                    {
                        DataRow druser = userdata.AsEnumerable().SingleOrDefault(r => r.Field<string>("TEN") == rv.ten);
                        rv.userImage = (Image)rm.GetObject(druser[0].ToString());
                    }
                    catch (Exception)
                    {
                    }
                    flowLayoutPanel2.Controls.Add(rv);
                    countSongRate++;

                }
            }
            if (countSongRate != 0)
                everageRate = everageRate / countSongRate;
            rating = (float)(Math.Round(everageRate * 2, MidpointRounding.AwayFromZero) / 2);
            guna2RatingStar1.Value = (float)(Math.Round(everageRate * 2, MidpointRounding.AwayFromZero) / 2);

        //guna2RatingStar1.Enabled = false;
    }
    //private void rate(int value)
    //{
    //    if (value == 1)
    //        setRate(1, 0, 0, 0, 0);
    //    else if (value == 2)
    //        setRate(1, 1, 0, 0, 0);
    //    else if (value == 3)
    //        setRate(1, 1, 1, 0, 0);
    //    else if (value == 4)
    //        setRate(1, 1, 1, 1, 0);
    //    else
    //        setRate(1, 1, 1, 1, 1);
    //}
    //private void setRate(int a, int b, int c, int d, int e)
    //{
    //    s1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
    //    s2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
    //    s3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
    //    s4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
    //    s5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
    //    if (a == 0)
    //        s1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
    //    if (b == 0)
    //        s2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
    //    if (c == 0)
    //        s3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
    //    if (d == 0)
    //        s4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
    //    if (e == 0)
    //        s5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
    //}
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
            if (media.playState != WMPLib.WMPPlayState.wmppsPlaying)
                pictureBox6.Visible = false;
            
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
            if (stage == true)
            {
                stage = false;
                btplay.Image = _20521587_TH03_Music_Online.Properties.Resources.play_button;

                media.Ctlcontrols.pause();
                pictureBox6.Visible = false;
            }
            else
            {
                stage = true;
                btplay.Image = _20521587_TH03_Music_Online.Properties.Resources.pause;
                media.Ctlcontrols.play();
                pictureBox6.Visible = true;
            }
            pictureBox6.Visible = stage;
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
            pictureBox6.Visible = false;
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
            foreach (ucSong i in flowLayoutPanel1.Controls)
            {
                WMPLib.IWMPMedia m = media.newMedia("./" + i.maBh + ".mp3");
                fullSong.appendItem(m);
            }
            //fullSong.appendItem(m2);
            //media.playlistCollection.
            media.currentPlaylist = fullSong;
            media.Ctlcontrols.play();
            pictureBox6.Visible = true;
        }

        private void guna2CirclePictureBox4_Click(object sender, EventArgs e)
        {
            media.Ctlcontrols.next();
            pictureBox6.Visible = true;
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
        // load bài hát
        private void load_SongIn4(string mabh)
        {
            DataRow dr = listSongData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == mabh);
            richTextBox1.Clear();
            pbSongPic.Image = (Image)rm.GetObject(mabh);
            lbSongTitleMain.Text = dr[1].ToString();
            lbAuthorMain.Text = dr[2].ToString();
            lbSingerMain.Text = dr[3].ToString();
            string lyricUrl = @".\" + mabh + ".txt";
            string[] lines = System.IO.File.ReadAllLines(lyricUrl);
            //MessageBox.Show(lines.Length.ToString());
            richTextBox1.Size = new Size(500, lines.Length * 22);
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                //Console.WriteLine("\t" + line);
                richTextBox1.AppendText(line + "\n");
            }
            //lbAuthorMain.Text = dr[2].ToString();
            guna2HtmlLabel1.Top = richTextBox1.Top + richTextBox1.Height;
            panel2.Top = richTextBox1.Top + richTextBox1.Height - 5;
            guna2RatingStar1.Top = richTextBox1.Top + richTextBox1.Height - 5;
            guna2HtmlLabel2.Top = guna2HtmlLabel1.Top + 40;
            pictureBox14.Top = guna2HtmlLabel2.Top + 40;
            flowLayoutPanel2.Top = pictureBox14.Top + 40;

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
            mome_Image(sender);
            loadListenHis();
        }

        private void loadListenHis()
        {
            flowLayoutPanel5.Controls.Clear();

            listSongData = ldal.Select();
            favorData = fvordal.Select();
            listenHisData = lhisdal.Select();
            //ucSong[] ListSong = new ucSong[listSongData.Rows.Count];
            for (int i = 0; i < listSongData.Rows.Count; i++)
            {
                ucSong c = new ucSong();
                ucListenHis d = new ucListenHis();
                DataRow hisdr = listenHisData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == listSongData.Rows[i][0].ToString());
                if (hisdr == null)
                    continue;
                if ((favorData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == listSongData.Rows[i][0].ToString()) != null))
                    c.isFavor = true;
                else
                    c.isFavor = false;
                d.thoiDiem = hisdr[2].ToString();
                d.luotNghe = hisdr[1].ToString();
                c.maBh = listSongData.Rows[i][0].ToString();
                c.tenBh = listSongData.Rows[i][1].ToString();
                c.tacGia = listSongData.Rows[i][2].ToString();
                c.caSi = listSongData.Rows[i][3].ToString();
                c.image = (Image)rm.GetObject(listSongData.Rows[i][0].ToString());
                c.theLoai = listSongData.Rows[i][4].ToString();
                c.quocGia = listSongData.Rows[i][5].ToString();
                c.setXPositionTimeSong = 30;
                c.time = listSongData.Rows[i][6].ToString().Substring(3);
                c.playButtonClick += play_Click;
                c.Ucclick += play_Click2;
                flowLayoutPanel5.Controls.Add(c);
                flowLayoutPanel6.Controls.Add(d);
            }
            flowLayoutPanel5.Height = listenHisData.Rows.Count * 130;
            flowLayoutPanel6.Height = listenHisData.Rows.Count * 130;
            flowLayoutPanel5.Refresh();
            flowLayoutPanel6.Refresh();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
            loadFavorSong();
            mome_Image(sender);
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

            int songCounter = 0;
            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString() == tenpl && dr[2].ToString() != "FFFF")
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
                    songCounter++;
                }

            }

            flowLayoutPanel3.Height = songCounter * 125;


        }
        private Guna2GradientButton addReviewButton()
        {
            //Button bt = new Button() { Width = 730, Height = 25, Text = "Thêm Đánh Giá" };
            //bt.Click += new EventHandler(addReview);
            Guna2GradientButton b = new Guna2GradientButton();
            b.Animated = true;
            b.BorderRadius = 10;
            b.CheckedState.Parent = b;
            b.CustomImages.Parent = b;
            b.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            b.ForeColor = System.Drawing.Color.White;
            b.HoverState.Parent = b;
            b.Location = new System.Drawing.Point(491, 335);
            b.Name = "guna2GradientButton1";
            b.ShadowDecoration.Parent = b;
            b.Size = new System.Drawing.Size(730, 35);
            b.TabIndex = 79;
            b.Text = "Thêm đánh giá mới";
            b.Click += new EventHandler(addReview);

            return b;
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
            f.ten = userName;
            f.userImage = (Image)rm.GetObject(userID);
            f.insertClick += update_review;
            foreach (Control i in flowLayoutPanel2.Controls)
            {
                if (i.GetType() == typeof(Guna2GradientButton))
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

            if (!f.cancel)
            {

                string line = f.tenPlayList;
                string[] lines =
                {
                    line
                };
                string saveurl = "./PlayListName.txt";
                File.AppendAllLines(saveurl, lines);
                string[] p = System.IO.File.ReadAllLines("./PlayListName.txt");
                PlaylistDAL pdal = new PlaylistDAL();
                pdal.Insert(p.Length, f.tenPlayList, "FFFF");
            }
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");

            guna2ComboBox1.Items.Clear();
            foreach (string item in plLines)
            {
                guna2ComboBox1.Items.Add(item);
            }
            guna2ComboBox1.SelectedIndex = 0;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_PlayList(guna2ComboBox1.Text);

        }

        private void pbAddToPlayList_Click(object sender, EventArgs e)
        {
            //fAddToPlayList d = new fAddToPlayList();
            //d.Location = new Point(e.);
            //d.Show();
            //fAddToPlayList d = new fAddToPlayList();
            //d.Location = new Point(pbAddToPlayList.Location.X+220, pbAddToPlayList.Location.Y+110);
            //d.ShowDialog();
            ContextMenuStrip toolStrip = new ContextMenuStrip();
            toolStrip.ItemClicked += ClickItem;
            toolStrip.Items.Clear();
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");

            foreach (string item in plLines)
            {
                toolStrip.Items.Add(item);
            }
            //toolStrip.Items.Add("Now playing");
            //foreach (PlayListInfo item in Playlist.Instance.GetAllPlayListMusic())
            //{
            //    toolStrip.Items.Add(item.Name_PL);
            //    Y -= 22;
            //}
            toolStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip.Items.Add("-");
            toolStrip.Items.Add("New playlist");
            int Y = 400;

            toolStrip.Location = new Point(pbAddToPlayList.Location.X + 70, pbAddToPlayList.Location.Y + Y);
            toolStrip.Show(MousePosition);
            toolStrip.BringToFront();
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Dock = DockStyle.None;
        }
        //public class AutoClosingMessageBox
        //{
        //    System.Threading.Timer _timeoutTimer;
        //    string _caption;
        //    //fMessShow f = new fMessShow();

        //    AutoClosingMessageBox(string text, string caption, int timeout)
        //    {
        //        _caption = caption;
        //        _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
        //            null, timeout, System.Threading.Timeout.Infinite);
        //        using (_timeoutTimer)
        //            //f.Show();
        //            /*MessageBox.Show(text, caption)*/;
        //    }
        //    public static void Show(string text, string caption, int timeout)
        //    {
        //        new AutoClosingMessageBox(text, caption, timeout);
        //    }
        //    void OnTimerElapsed(object state)
        //    {
        //        IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
        //        if (mbWnd != IntPtr.Zero)
        //            SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        //        _timeoutTimer.Dispose();
        //    }
        //    const int WM_CLOSE = 0x0010;
        //    [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        //    static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //    [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        //    static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
        //}
        private void ClickItem(object sender, ToolStripItemClickedEventArgs e)
        {

            // them vao play list
            if (e.ClickedItem.Text == "New playlist")
            {
                guna2Button6_Click(sender, null);
            }
            else
            {
                PlaylistDAL pdal = new PlaylistDAL();
                pdal.Insert(1, e.ClickedItem.Text, Playing);
                fMessShow d = new fMessShow("Thêm Thành công");
                d.Show();
            }


            
            // ? 
            //toolStrip = null;
        }
        private void pbAddToPlayList_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            IWMPPlaylist playlist = media.newPlaylist("Playlist", null);
            //WMPLib.IWMPMedia m1 = media.newMedia("./" + "BH01" + ".mp3");
            foreach (ucSong i in flowLayoutPanel3.Controls)
            {
                WMPLib.IWMPMedia m = media.newMedia("./" + i.maBh + ".mp3");
                playlist.appendItem(m);
            }
            //fullSong.appendItem(m2);
            //media.playlistCollection.
            media.currentPlaylist = playlist;
            media.Ctlcontrols.play();
            pictureBox6.Visible = true;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            ContextMenuStrip toolStrip = new ContextMenuStrip();
            toolStrip.ItemClicked += ClickUserOption;
            toolStrip.Items.Clear();
            toolStrip.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            toolStrip.Items.Add("Đổi tải khoản");
            toolStrip.Items.Add("-");
            toolStrip.Items.Add("Đổi ảnh nền");
            toolStrip.Items.Add("-");
            toolStrip.Items.Add("Thông tin người dùng", _20521587_TH03_Music_Online.Properties.Resources.info);
            int Y = 400;
            toolStrip.Location = new Point(pbAddToPlayList.Location.X + 70, pbAddToPlayList.Location.Y + Y);
            toolStrip.Show(MousePosition);
            toolStrip.BringToFront();
            toolStrip.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip.Dock = DockStyle.None;
        }
        private void ClickUserOption(object sender, ToolStripItemClickedEventArgs e)
        {

            // them vao play list
            if (e.ClickedItem.Text == "Đổi tải khoản")
            {
                fSwichUser fswuer = new fSwichUser();
                fswuer.ShowDialog();
                pbuserimage.Image = fswuer.userImage;
                lbUserName.Text = fswuer.userName;
                userName = fswuer.userName;
                userID = fswuer.userID;
                fMessShow d = new fMessShow("Đổi TK Thành công");
                d.Show();
            }


            
            // ? 
            //toolStrip = null;
        }
        private void LoadTopicSong(string topic, string country)
        {
            //load_ListSong();
            foreach (ucSong song in flowLayoutPanel1.Controls)
            {
                song.Visible = true;
            }
            //listSongData = ldal.Select();
            //ucSong[] ListSong = new ucSong[listSongData.Rows.Count];
            //for (int i = 0; i < listSongData.Rows.Count; i++)
            //{
            //    ListSong[i] = new ucSong();
            //    ListSong[i].maBh = listSongData.Rows[i][0].ToString();
            //    ListSong[i].tenBh = listSongData.Rows[i][1].ToString();
            //    ListSong[i].caSi = listSongData.Rows[i][3].ToString();
            //    ListSong[i].image = (Image)rm.GetObject(listSongData.Rows[i][0].ToString());
            //    ListSong[i].theLoai = listSongData.Rows[i][4].ToString();
            //    ListSong[i].time = listSongData.Rows[i][6].ToString().Substring(3);
            //    ListSong[i].playButtonClick += play_Click;
            //    ListSong[i].Ucclick += play_Click2;
            //    flowLayoutPanel1.Controls.Add(ListSong[i]);
            //}
            int count = 0;
            foreach (ucSong song in flowLayoutPanel1.Controls)
            {
                if (song.theLoai != topic || song.quocGia != country)
                {
                    song.Visible = false;
                }
                else
                    count++;
            }
            flowLayoutPanel1.Height = count * 125;
            flowLayoutPanel1.Refresh();
        }
        private void guna2Button8_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Nhạc Trẻ", "Việt Nam");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Nhạc Trẻ";
        }
        private void guna2Button9_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Trữ Tình", "Việt Nam");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Trữ Tình";

        }
        private void guna2Button10_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Remix Việt", "Việt Nam");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Remix Việt";

        }
        private void guna2Button13_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Pop", "Âu Mỹ");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Pop";

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Electronica/Dance", "Âu Mỹ");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Electronica/Dance";

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            LoadTopicSong("Rock", "Âu Mỹ");
            gunaLabel1.Visible = true;
            gunaLabel1.Text = "Rock";

        }
        private void findSong()
        {
            foreach (ucSong song in flowLayoutPanel1.Controls)
            {
                song.Visible = true;
            }
            if (guna2ComboBox2.Text == "Tên Bài Hát")
            {
                int count = 0;
                foreach (ucSong song in flowLayoutPanel1.Controls)
                {
                    if (!song.tenBh.ToLower().Contains(guna2TextBox1.Text.ToString().ToLower()))
                    {
                        song.Visible = false;
                    }
                    else
                        count++;
                }
                flowLayoutPanel1.Height = count * 125;
                flowLayoutPanel1.Refresh();
            }
            if (guna2ComboBox2.Text == "Thể Loại")
            {
                int count = 0;
                foreach (ucSong song in flowLayoutPanel1.Controls)
                {
                    if (!song.theLoai.ToLower().Contains(guna2TextBox1.Text.ToString().ToLower()))
                    {
                        song.Visible = false;
                    }
                    else
                        count++;
                }
                flowLayoutPanel1.Height = count * 125;
                flowLayoutPanel1.Refresh();
            }


            if (guna2ComboBox2.SelectedIndex == 2)
            {
                int count = 0;
                foreach (ucSong song in flowLayoutPanel1.Controls)
                {
                    if (!song.tacGia.ToLower().Contains(guna2TextBox1.Text.ToString().ToLower()))
                    {
                        song.Visible = false;
                    }
                    else
                        count++;
                }
                flowLayoutPanel1.Height = count * 125;
                flowLayoutPanel1.Refresh();
            }
            if (guna2ComboBox2.SelectedIndex == 3)
            {
                int count = 0;
                foreach (ucSong song in flowLayoutPanel1.Controls)
                {
                    if (!song.caSi.ToLower().Contains(guna2TextBox1.Text.ToString().ToLower()))
                    {
                        song.Visible = false;
                    }
                    else
                        count++;
                }
                flowLayoutPanel1.Height = count * 125;
                flowLayoutPanel1.Refresh();
            }

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                findSong();
            }
        }
        private void loadFavorSong()
        {
            flowLayoutPanel4.Controls.Clear();

            listSongData = ldal.Select();
            favorData = fvordal.Select();

            //ucSong[] ListSong = new ucSong[listSongData.Rows.Count];
            for (int i = 0; i < listSongData.Rows.Count; i++)
            {
                ucSong c = new ucSong();
                if ((favorData.AsEnumerable().SingleOrDefault(r => r.Field<string>("MABH") == listSongData.Rows[i][0].ToString()) != null))
                    c.isFavor = true;
                else
                {
                    c.isFavor = false;
                    continue;
                }
                c.maBh = listSongData.Rows[i][0].ToString();
                c.tenBh = listSongData.Rows[i][1].ToString();
                c.tacGia = listSongData.Rows[i][2].ToString();
                c.caSi = listSongData.Rows[i][3].ToString();
                c.image = (Image)rm.GetObject(listSongData.Rows[i][0].ToString());
                c.theLoai = listSongData.Rows[i][4].ToString();
                c.quocGia = listSongData.Rows[i][5].ToString();
                c.time = listSongData.Rows[i][6].ToString().Substring(3);
                c.playButtonClick += play_Click;
                c.Ucclick += play_Click2;
                flowLayoutPanel4.Controls.Add(c);
            }
            flowLayoutPanel4.Height = favorData.Rows.Count * 130;
            flowLayoutPanel4.Refresh();
        }

        private void pictureBox23_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(System.IO.Path.GetDirectoryName(Application.ExecutablePath));
            //"./" + i.maBh + ".mp3";


            SaveFileDialog savedlg = new SaveFileDialog();
            savedlg.DefaultExt = "mp3";
            savedlg.Filter = "Audio file .mp3 |*.mp3";
            savedlg.AddExtension = true;
            savedlg.RestoreDirectory = true;
            savedlg.Title = "Where do you want to save the song dowloaded?";
            savedlg.InitialDirectory = @"C:/";
            if (savedlg.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/" + Playing + ".mp3");
                //MessageBox.Show(savedlg.FileName);
                guna2ProgressBar1.Visible = true;
                guna2HtmlLabel7.Visible = true;
                Thread myThread = new Thread(new ThreadStart(thread1));
                myThread.Start();
                System.IO.File.Copy(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\" + Playing + ".mp3", savedlg.FileName, true);

            }
            savedlg.Dispose();
            
            //timer2.Start();
           
        }
        private void thread2()
        {
            guna2HtmlLabel7.Visible = false;
            guna2ProgressBar1.Visible = false;
        }

        private void thread1()
        {
            guna2ProgressBar1.Value = 0;
            guna2ProgressBar1.Update();
            for (int i = 0; i <= 100; i++)
            {
                guna2ProgressBar1.Value = i;
                guna2ProgressBar1.Update();
                //guna2ProgressBar1.PerformLayout();
                Thread.Sleep(20);
            }
            guna2HtmlLabel7.Text = "Tải thành công";
            Thread.Sleep(1000);
            thread2();
            guna2HtmlLabel7.Text = "Đang tải xuống ....";
        }
        private void pictureBox24_Click(object sender, EventArgs e)
        {
            #region Test Download 
            //Process process = new Process();
            //string FILE_SHARE = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/" + Playing + ".mp3";
            //var PATH_SPECIAL_PROGRAMS = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData, Environment.SpecialFolderOption.None) + @"Programs";
            //string AGRUMENTS = $@"{PATH_SPECIAL_PROGRAMS}\Zalo\sl.exe "" % 1"" ""{PATH_SPECIAL_PROGRAMS}\Zalo\Zalo.exe"" {FILE_SHARE} --si-timeout 1000";
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //MessageBox.Show(AGRUMENTS);
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.FileName = "cmd.exe";
            //startInfo.Arguments = $"/C {AGRUMENTS}";
            //process.StartInfo = startInfo;
            //process.Start(); 
            #endregion
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            IWMPPlaylist fvor = media.newPlaylist("fvor", null);
            //WMPLib.IWMPMedia m1 = media.newMedia("./" + "BH01" + ".mp3");
            foreach (ucSong i in flowLayoutPanel4.Controls)
            {
                WMPLib.IWMPMedia m = media.newMedia("./" + i.maBh + ".mp3");
                fvor.appendItem(m);
            }
            //fullSong.appendItem(m2);
            //media.playlistCollection.
            media.currentPlaylist = fvor;
            media.Ctlcontrols.play();
            pictureBox6.Visible = true;
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            IWMPPlaylist listenhis = media.newPlaylist("listenhis", null);
            //WMPLib.IWMPMedia m1 = media.newMedia("./" + "BH01" + ".mp3");
            foreach (ucSong i in flowLayoutPanel5.Controls)
            {
                WMPLib.IWMPMedia m = media.newMedia("./" + i.maBh + ".mp3");
                listenhis.appendItem(m);
            }
            //fullSong.appendItem(m2);
            //media.playlistCollection.
            media.currentPlaylist = listenhis;
            media.Ctlcontrols.play();
            pictureBox6.Visible = true;
        }

        private void Media_EndOfStream(object sender, AxWMPLib._WMPOCXEvents_EndOfStreamEvent e)
        {
            //pictureBox6.Visible = false;
            //throw new NotImplementedException();
        }

        private void guna2RatingStar1_ValueChanged(object sender, EventArgs e)
        {
            guna2RatingStar1.Value = rating;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }
    }
}