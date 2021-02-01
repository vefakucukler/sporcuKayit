using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace kayıtProgramı
{
    public partial class iletişim : Form
    {
        public iletişim()
        {
            InitializeComponent();
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        int tiklama = 0;
        private void button2_Click(object sender, EventArgs e)
        {

            tiklama++;

            for (int i = 0; i < 10000; i++)
            {
                if (tiklama % 2 == 1)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (tiklama % 2 == 0)
                {
                    this.WindowState = FormWindowState.Normal;
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.facebook.com/vefakucukler");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.instagram.com/vefakucukler");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("www.twitter.com/vefakucukler");
        }

        private void iletişim_Load(object sender, EventArgs e)
        {
            linklblFacebook.Hide();
            linklblInstagram.Hide();
            linklblTwitter.Hide();
            lblHotmail.Hide();
            lblGsm.Hide();

        }

       

        private void pictureBox1_MouseUp_1(object sender, MouseEventArgs e)
        {
            linklblFacebook.Show();
        }

       

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            linklblInstagram.Show();
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            linklblTwitter.Show(); 
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            lblHotmail.Show();
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            lblGsm.Show();
        }

        private void iletişim_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }
    }
}
