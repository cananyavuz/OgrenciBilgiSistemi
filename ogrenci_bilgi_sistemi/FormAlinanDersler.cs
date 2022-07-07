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
    public partial class AlinanDersler : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANAN-YAVUZ\\SQLEXPRESS;Initial Catalog=obsVeriTabani;Integrated Security=True");
        public AlinanDersler()
        {
            InitializeComponent();
            //FORM AÇILDIĞINDA DATAGRİD'E  4. DÖNEM DERSLERİNİ GETİRİR
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 4 ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        
    }
}
