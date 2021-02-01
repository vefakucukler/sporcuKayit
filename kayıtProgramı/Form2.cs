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
    public partial class Form2 : Form
    {
        public Form2()
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
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form5 frm = new Form5();
            frm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
            this.Hide();
        }

        private void pROGRAMHAKKINDAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmhakkinda hakkinda = new frmhakkinda();
            hakkinda.ShowDialog();
        }

        private void iLETİŞİMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            iletişim ilet = new iletişim();
            ilet.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblEkle.Hide();
            lblSil.Hide();
            lblAra.Hide();
            lblListe.Hide();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }
        int tiklama = 0;
        private void button5_Click(object sender, EventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            lblEkle.Hide(); ;
        }

        private void lblListe_Click(object sender, EventArgs e)
        {
            lblSil.Hide();
        }

        private void lblAra_Click(object sender, EventArgs e)
        {
            lblAra.Hide();
        }

        private void lblListe_Click_1(object sender, EventArgs e)
        {
            lblListe.Hide();
        }

        private void btnEkle_MouseMove(object sender, MouseEventArgs e)
        {
            lblEkle.Show();
        }

        private void btnEkle_MouseLeave(object sender, EventArgs e)
        {
            lblEkle.Hide();
        }

        private void btnSil_MouseMove(object sender, MouseEventArgs e)
        {
            lblSil.Show();
        }

        private void btnSil_MouseLeave(object sender, EventArgs e)
        {
            lblSil.Hide();
        }

        private void btnAra_MouseMove(object sender, MouseEventArgs e)
        {
            lblAra.Show();
        }

        private void btnAra_MouseLeave(object sender, EventArgs e)
        {
            lblAra.Hide();
        }

        private void btnListe_MouseMove(object sender, MouseEventArgs e)
        {
            lblListe.Show();
        }

        private void btnListe_MouseLeave(object sender, EventArgs e)
        {
            lblListe.Hide();
        }

        private void Form2_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
