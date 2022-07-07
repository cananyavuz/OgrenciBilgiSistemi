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
    public partial class FormNotBilgisi : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANAN-YAVUZ\\SQLEXPRESS;Initial Catalog=obsVeriTabani;Integrated Security=True");

        //FORM AÇILDIĞINDA DATAGRİD'E  4. DÖNEM DERSLERİNİ GETİRİR
        public FormNotBilgisi()
        {
            InitializeComponent();
            baglanti.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi," +
                "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                "from Tbl_Dersler where donemBilgisi = 4 ", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        //DATAGRİD'E ÇİFT TIKLANDIĞINDA İLGİLİ TEXTBOXLARA İLGİLİ VERİLERİ YERLEŞTİRİR
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            comboBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtDersKodu.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtDersAdi.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            TxtDersKredisi.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            TxtHarfNotu.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtOrtalama.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
        }

        //COMBOBOX'TAKİ DEĞERE GÖRE İLGİLİ DÖNEMİN DERSLERİNİ LİSTELER
        private void BtnListele_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (comboBox1.Text == "1")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 1 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;

            }
            else if (comboBox1.Text == "2")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 2 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "3")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 3 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "4")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 4 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "5")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 5 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "6")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 6 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "7")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuclandirilmadi') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 7 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            else if (comboBox1.Text == "8")
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu, dersID " +
                    "from Tbl_Dersler where donemBilgisi = 8 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            baglanti.Close();
        }


        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            comboBox1.Text = " ";
            TxtDersAdi.Text = " ";
            TxtDersKodu.Text = " ";
            TxtDersKredisi.Text = " ";
            TxtHarfNotu.Text = " ";
            TxtOrtalama.Text = " ";        }


        //TEXTBOXTAKİ VERİLERLE YENİ DERS BİLGİSİ OLUŞTURUR VE DATAGRİDE EKLER
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sqltxt = "insert into Tbl_Dersler (donemBilgisi, dersKodu, dersAdi, dersKredi, ortalama, harfNotu) values (@p1, @p2, @p3, @p4 ,@p5, @p6)";
            SqlCommand komut = new SqlCommand(sqltxt, baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            komut.Parameters.AddWithValue("@p2", TxtDersKodu.Text);
            komut.Parameters.AddWithValue("@p3", TxtDersAdi.Text);
            komut.Parameters.AddWithValue("@p4", TxtDersKredisi.Text);
            komut.Parameters.AddWithValue("@p5", TxtOrtalama.Text);
            komut.Parameters.AddWithValue("@p6", TxtHarfNotu.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ders Bilgisi Eklendi.");
            BtnListele_Click(sender, e);
        }
        
        //TIKLANILAN SATIRI SİLER
        private void BtnBırak_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string sil = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            string sqlbirakkomut = "Delete from Tbl_Dersler where dersID=" +sil+"";
            SqlCommand komutsil = new SqlCommand(sqlbirakkomut,baglanti);
            komutsil.ExecuteNonQuery(); 
            baglanti.Close();
            MessageBox.Show("Ders Bilgisi Silindi.");
            BtnListele_Click(sender, e);
        }

        //DATAGRİD'E ÇİFT TIKLANDIĞINDA İLGİLİ TEXTBOXLARA YERLEŞEN VERİLER ÜZERİNDE YAPILAN DEĞİŞİKLİKLERİ MEVCUT DERS KAYDINININ ÜZERİNDE UYGULAR.
        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            string güncelletxt = "Update Tbl_Dersler Set donemBilgisi=@g1, dersAdi=@g2, dersKredi=@g3, ortalama=@g4, harfNotu=@g5 Where dersKodu=@g6";
            SqlCommand komut = new SqlCommand(güncelletxt, baglanti);

            komut.Parameters.AddWithValue("@g1", comboBox1.Text);
            komut.Parameters.AddWithValue("@g2", TxtDersAdi.Text);
            komut.Parameters.AddWithValue("@g3", TxtDersKredisi.Text);
            komut.Parameters.AddWithValue("@g4", TxtOrtalama.Text);
            komut.Parameters.AddWithValue("@g5", TxtHarfNotu.Text);
            komut.Parameters.AddWithValue("@g6", TxtDersKodu.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Ders Bilgisi Güncellendi.");

            BtnListele_Click(sender, e);

        }

        //GİRİLEN VERİYE GÖRE DERS ARATIR
        private void BtnDersAra_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select donemBilgisi, dersKodu, dersAdi, dersKredi, " +
                    "IsNull(ortalama, 'Sonuçlandırılmadı') ortalama, IsNull(harfNotu, 'Sonuçlandırılmadı') harfNotu " +
                    " from Tbl_Dersler where dersAdi like '%" + TxtDersAdi.Text + "%' ",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }
    }
}
