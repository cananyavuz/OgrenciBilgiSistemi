using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ogrenci_bilgi_sistemi
{
    public partial class FormAnaEkran : Form
    {
        public FormAnaEkran()
        {
            InitializeComponent();

            groupBox1.Visible = false;
            
        }

        SqlConnection baglanti = new SqlConnection("Data Source=CANAN-YAVUZ\\SQLEXPRESS;Initial Catalog=obsVeriTabani;Integrated Security=True");

        private void buttonAnaEkran_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void BtnDanismanBilgi_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
        }

        private void BtnNotBilgi_Click(object sender, EventArgs e)
        {
            FormNotBilgisi frm = new FormNotBilgisi();
            frm.Show();
        }

        private void BtnAlinanDersler_Click(object sender, EventArgs e) 
        {
            AlinanDersler frm = new AlinanDersler();
            frm.Show();
        }

        private void BtnMufredatDurum_Click(object sender, EventArgs e)
        {
            FormMüfredatDurum frm = new FormMüfredatDurum();
            frm.Show();
        }

       
    }
}
