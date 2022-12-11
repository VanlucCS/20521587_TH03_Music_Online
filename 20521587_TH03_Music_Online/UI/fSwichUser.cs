using _20521587_TH03_Music_Online.DAL;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online.UI
{
    public partial class fSwichUser : Form
    {

        ResourceManager rm = new ResourceManager("_20521587_TH03_Music_Online.Properties.Resources",
            Assembly.GetExecutingAssembly());
        UserDAL udal = new UserDAL();
        DataTable userdata = new DataTable();
        public fSwichUser()
        {
            InitializeComponent();
            userdata = udal.Select();
        }
        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        private Image _userImage;

        public Image userImage
        {
            get { return _userImage; }
            set { _userImage = value; }
        }
        private string _userID;

        public string userID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        private void fSwichUser_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            Guna2Button d = (Guna2Button)sender;
            userName = d.Text;
            DataRow druser = userdata.AsEnumerable().SingleOrDefault(r => r.Field<string>("TEN") == userName);
            userID = druser[0].ToString();
            userImage = (Image)rm.GetObject(druser[0].ToString());
            this.Close();
        }
    }
}
