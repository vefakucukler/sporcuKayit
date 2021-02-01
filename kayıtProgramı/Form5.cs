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
    public partial class Form5 : Form
    {
        public Form5()
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
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
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            if (textBox1.Text.Trim() == "")
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];

            }
            else
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit where tc like '%" + textBox1.Text + "%'", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];
            }
            else
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit where adi like '%" + textBox2.Text + "%'", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {


            if (textBox3.Text.Trim() == "")
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];
            }
            else
            {
                ds.Tables["sporcukayit"].Clear();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From sporcukayit where soyadi like '%" + textBox3.Text + "%'", baglanti);
                adtr.Fill(ds, "sporcukayit");
                dataGridView1.DataSource = ds.Tables["sporcukayit"];
            }
            
        }

        private void Form5_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int tiklama=0;

        private void button2_Click_1(object sender, EventArgs e)
        {
            tiklama++;

            for (int i = 0; i < 10000; i++)
            {
                if (tiklama%2==1)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                else if (tiklama%2==0)
                {
                    this.WindowState = FormWindowState.Normal;
                }
          

            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_MouseMove(object sender, MouseEventArgs e)
        {
            lblAna.Show();
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            lblAna.Hide();
        }
    }
}
