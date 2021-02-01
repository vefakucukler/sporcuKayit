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
    public partial class Form7 : Form
    {
        public Form7()
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

        private void Form7_Load(object sender, EventArgs e)
        {
            lblAna.Hide();
            lblGuncelle.Hide();
            textBox9.Text = DateTime.Now.ToShortDateString();
            listele();
            dataGridView1.Columns["id"].DisplayIndex = 0;
            dataGridView1.Columns["tc"].DisplayIndex = 1;
            dataGridView1.Columns["adi"].DisplayIndex = 2;
            dataGridView1.Columns["soyadi"].DisplayIndex = 3;
            dataGridView1.Columns["tarih"].DisplayIndex = 4;
            dataGridView1.Columns["fiyati"].DisplayIndex = 5;
            dataGridView1.Columns["cep"].DisplayIndex = 6;
            dataGridView1.Columns["yasi"].DisplayIndex = 7;
            dataGridView1.Columns["kilosu"].DisplayIndex = 8;
            dataGridView1.Columns["boyu"].DisplayIndex = 9;

            
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

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update sporcukayit set adi='" + textBox2.Text + "',soyadi='" + textBox3.Text + "',fiyati='" + textBox4.Text + "',yasi='" + textBox5.Text + "',kilosu='" + textBox6.Text + "',boyu='" + textBox7.Text + "',cep='" + textBox8.Text + "',tarih='" + textBox9.Text + "' where id=" + textBox1.Text + "";
            komut.ExecuteNonQuery();      
            komut.Dispose();
            baglanti.Close();            
            MessageBox.Show("Kayıt Başarıyla Güncellendi.", "KAYIT GÜNCELLENDİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ds.Tables["sporcukayit"].Clear();
            listele();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        private void btnGuncelle_MouseMove(object sender, MouseEventArgs e)
        {
            lblGuncelle.Show();
        }

        private void btnGuncelle_MouseLeave(object sender, EventArgs e)
        {
            lblGuncelle.Hide();
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            lblAna.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            lblAna.Hide();
        }
    }
}
