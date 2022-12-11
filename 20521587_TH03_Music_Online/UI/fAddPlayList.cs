using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20521587_TH03_Music_Online.UI
{
    public partial class fAddPlayList : Form
    {
        public fAddPlayList()
        {
            InitializeComponent();

        }
        private bool _cacel = false;

        public bool cancel
        {
            get { return _cacel; }
            set { _cacel = value; }
        }

        private string  _tenPlayList;

        public string  tenPlayList
        {
            get { return _tenPlayList; }
            set { _tenPlayList = value; }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string[] plLines = System.IO.File.ReadAllLines("./PlayListName.txt");
            foreach (string  item in plLines)
            {
                if(item == tbNamePlaylist.Text)
                {
                    
                    MessageBox.Show("Tên Play List trùng");
                    return;
                }    

            }
            if (tbNamePlaylist.Text != "")
            {
                this.Close();
                _tenPlayList = tbNamePlaylist.Text;
            }
            else
            {
                MessageBox.Show("Chưa nhập tên play list");
                return;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            cancel = true;
            this.Close();
        }
    }
}
