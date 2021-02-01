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
    public partial class Form4 : Form
    {
        public Form4()
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Hide();
            lblAna.Hide();
            lblSil.Hide();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Geçerli İD Giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                DialogResult c;
                c = MessageBox.Show("Sporcu Kaydını Silmek İstediğinize Emin Misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (c == DialogResult.Yes)
                {


                    baglanti.Open();
                    komut.Connection = baglanti;
                    komut.CommandText = "Delete from sporcukayit where id=" + Convert.ToInt32(textBox1.Text);
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                    MessageBox.Show("Sporcu Kaydı Silindi.", "SİLME İŞLEMİ TAMAMLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ds.Tables["sporcukayit"].Clear();
                    listele();
                }
            }



        }  
           

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int tiklama = 0;
        private void button4_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form4_LocationChanged(object sender, EventArgs e)
        {

        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            lblAna.Show();

        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            lblAna.Hide();

        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            lblSil.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            lblSil.Hide();
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Show();
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            label1.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
