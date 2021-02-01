using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.InteropServices;

namespace kayıtProgramı
{
    public partial class Form6 : Form
    {
        public Form6()
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


        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=sporcukayit.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            lblGuncelle.Hide();
            lblAna.Hide();
            listele();
            dataGridView1.Columns["tc"].DisplayIndex = 0;
            dataGridView1.Columns["adi"].DisplayIndex = 1;
            dataGridView1.Columns["soyadi"].DisplayIndex = 2;
            dataGridView1.Columns["tarih"].DisplayIndex = 3;
            dataGridView1.Columns["fiyati"].DisplayIndex = 4;
            dataGridView1.Columns["cep"].DisplayIndex = 5;
            dataGridView1.Columns["yasi"].DisplayIndex = 6;
            dataGridView1.Columns["kilosu"].DisplayIndex = 7;
            dataGridView1.Columns["boyu"].DisplayIndex = 8;
            dataGridView1.Columns["id"].DisplayIndex = 9;

        }

        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select * from sporcukayit", baglanti);
            adtr.Fill(ds, "sporcukayit");
            dataGridView1.DataSource = ds.Tables["sporcukayit"];
            adtr.Dispose();
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int tiklama = 0;
        private void button3_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            lblAna.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            lblAna.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            this.Hide();
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            lblGuncelle.Show();
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            lblGuncelle.Hide();
        }

        private void Form6_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }
    }
}
