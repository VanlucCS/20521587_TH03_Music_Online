using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _20521587_TH03_Music_Online.BLL;
using _20521587_TH03_Music_Online.DAL;


namespace _20521587_TH03_Music_Online.UI
{
    public partial class ucAddReview : UserControl
    {
        public ucAddReview()
        {
            InitializeComponent();
        }
        private string _maBh;

        public string maBh
        {
            get { return _maBh; }
            set { _maBh = value; }
        }
        private int _soDg;

        public int soDg
        {
            get { return _soDg; }
            set { _soDg = value; }
        }
        private string _ten;

        public string ten
        {
            get { return _ten; }
            set { _ten = value; lbName.Text = value; }
        }
        private Image _userImage;

        public Image userImage
        {
            get { return _userImage; }
            set { _userImage = value; guna2CirclePictureBox1.Image = value; }
        }
        private string _danhGia;

        public string danhGia
        {
            get { return _danhGia; }
            set { _danhGia = value;tbCommand.Text = value; }
        }
        //private int _rate;

        //public int rate
        //{
        //    get { return _rate; }
        //    set { _rate = value;
        //        if (value == 1)
        //            setRate(1, 0, 0, 0, 0);
        //        else if (value == 2)
        //            setRate(1, 1, 0, 0, 0);
        //        else if (value == 3)
        //            setRate(1, 1, 1, 0, 0);
        //        else if (value == 4)
        //            setRate(1, 1, 1, 1, 0);
        //        else
        //            setRate(1, 1, 1, 1, 1);
        //    }
        //}
        private DateTime _thoiGian;

        public DateTime thoiGian
        {
            get { return _thoiGian; }
            set { _thoiGian = value; }
        }
        private int _like;

        public int like
        {
            get { return _like; }
            set { _like = value; }
        }
        private int _unLike;

        public int unLike
        {
            get { return _unLike; }
            set { _unLike = value; }
        }

        public event EventHandler insertClick
        {
            add { guna2GradientButton1.Click += value; }
            remove { guna2GradientButton1.Click -= value; }
        }

        //private void setRate(int a, int b, int c, int d, int e)
        //{
        //    pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__2_;
        //    if (a == 0)
        //        pbstart1.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (b == 0)
        //        pbstart2.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (c == 0)
        //        pbstart3.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (d == 0)
        //        pbstart4.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //    if (e == 0)
        //        pbstart5.Image = _20521587_TH03_Music_Online.Properties.Resources.star__4_;
        //}
       
        private void ucAddReview_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ReviewsDAL rdal = new ReviewsDAL();
            ReviewBLL rbll = new ReviewBLL();
            rbll.MABH = this.maBh;
            rbll.SODG = this.soDg;
            rbll.TEN = this.ten;
            rbll.DANHGIA = this.danhGia;
            rbll.rate = guna2RatingStar1.Value;
            rbll.THOIGIAN = DateTime.Now;
            rbll.THICH = 0;
            rbll.KOTHICH = 0;
            rdal.Insert(rbll);
            MessageBox.Show("Đánh giá thành công");
            this.Enabled = false;
            //guna2Button1.Visible = false;
        }

        private void tbCommand_TextChanged(object sender, EventArgs e)
        {
            danhGia = tbCommand.Text;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ReviewsDAL rdal = new ReviewsDAL();
            ReviewBLL rbll = new ReviewBLL();
            rbll.MABH = this.maBh;
            rbll.SODG = this.soDg;
            rbll.TEN = this.ten;
            rbll.DANHGIA = this.danhGia;
            rbll.rate = guna2RatingStar1.Value;
            rbll.THOIGIAN = DateTime.Now;
            rbll.THICH = 0;
            rbll.KOTHICH = 0;
            rdal.Insert(rbll);
            fMessShow d = new fMessShow("Đánh Giá Thành công");
            d.Show();
            //MessageBox.Show("Đánh giá thành công");
            this.tbCommand.Enabled = false;
            guna2GradientButton1.Visible = false;
        }
    }
}
