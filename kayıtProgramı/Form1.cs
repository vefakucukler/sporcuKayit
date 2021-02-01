using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kayıtProgramı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Hide();
            if (txtKullaniciAdi.Text == "admin" && txtSifre.Text == "6161")
            {
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else if (txtKullaniciAdi.Text != "admin") 
            {
                txtSifre.Text = "";
                label3.Show();
            }
            else if (txtSifre.Text != "6161")
            {
                txtSifre.Text = "";
                label3.Show();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
