using System;
using System.Collections;
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
    public partial class FormMüfredatDurum : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=CANAN-YAVUZ\\SQLEXPRESS;Initial Catalog=obsVeriTabani;Integrated Security=True");

        public FormMüfredatDurum()

        {
            // TÜM DATAGRİD'LERDE İLGİLİ DÖNEMİN DERSLERİNİ GÖSTERİR.
            InitializeComponent();
            baglanti.Open();
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 1 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 2 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView2.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 3 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView3.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 4 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView4.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 5 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView5.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 6 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView6.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 7 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView7.DataSource = tablo;
            }
            {
                SqlDataAdapter da = new SqlDataAdapter("Select donemBilgisi, dersKodu, dersAdi, dersKredi from Tbl_Dersler where donemBilgisi = 8 ", baglanti);
                DataTable tablo = new DataTable();
                da.Fill(tablo);
                dataGridView8.DataSource = tablo;
            }

            //DÖNEM 1 İÇİN GPA VE CPGA  HESAPLAMA
            int toplamKredi1 = 0;
            double total1 = 0;
            {
                //harf notu olan derslerin sayını adet değişkenine atar.
                int adet = 0;
                SqlCommand komut1 = new SqlCommand("Select count(harfNotu) from Tbl_Dersler where donemBilgisi = 1  ", baglanti);
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    adet = Convert.ToInt32(dr1[0].ToString());
                }
                dr1.Close();
                
                //harf notlarını arraylistte sıralar.
                ArrayList harfNotList1 = new ArrayList();
                SqlCommand komut2 = new SqlCommand("Select harfNotu from Tbl_Dersler where donemBilgisi = 1 ", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    harfNotList1.Add(dr2[0].ToString());
                }

                double not = 0;
                //arraylistte sıralanan harfnotlarını farklı bir arraylistte sayısal değerlerle döndürür.
                ArrayList notList1 = new ArrayList();
                for (int i = 0; i < harfNotList1.Count; i++)
                {
                    string harfNot = harfNotList1[i].ToString();
                    if (harfNot == "AA                  ")
                    {
                        not = 4.0;
                    }
                    else if (harfNot == "BA                  ")
                    {
                        not = 3.5;
                    }
                    else if (harfNot == "BB                  ")
                    {
                        not = 3.0;
                    }
                    else if (harfNot == "CB                  ")
                    {
                        not = 2.5;
                    }
                    else if (harfNot == "CC                  ")
                    {
                        not = 2.0;
                    }
                    else if (harfNot == "DC                  ")
                    {
                        not = 1.5;
                    }
                    else if (harfNot == "DD                  ")
                    {
                        not = 1.0;
                    }
                    else if (harfNot == "FD                  ")
                    {
                        not = 0.5;
                    }
                    else if (harfNot == "FF                  ")
                    {
                        not = 0.0;
                    }

                    notList1.Add(not);
                }
                dr2.Close();

                //ders kredilerini arraylistte sıralar.
                ArrayList krediList1 = new ArrayList();
                SqlCommand komut3 = new SqlCommand("Select dersKredi from Tbl_Dersler where ortalama between 0 and 101 AND donemBilgisi = 1 ", baglanti);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    krediList1.Add(Convert.ToInt32(dr3[0].ToString()));
                    
                    for (int j = 0; j < krediList1.Count; j++)
                    {
                        //notların bulunduğu ve derskredilerinin bulundu iki listenin karşılık gelen değerlerini çarpar.
                        double carpim = Convert.ToInt32(notList1[j]) * Convert.ToInt32(krediList1[j]);
                        //total değişkeninde tüm derslerin çarpımlarını tutar.
                        total1 = total1+ carpim;
                        //sütunda bulunan kredilerin toplamını verir.
                        toplamKredi1 = toplamKredi1 + Convert.ToInt32(krediList1[j]);
                    }
                }
                dr3.Close();

                double ortalama1 = 0;
                ortalama1 = total1 / toplamKredi1;
                ortalama1 = Math.Round(ortalama1, 2);
                TxtDnm1Gpa.Text = "GPA: " + ortalama1;
                TxtDnm1Cgpa.Text = "CGPA: " + ortalama1;
            }


            //DÖNEM 2 İÇİN GPA VE CGPA HESAPLAMA
            double total2 = 0;
            int toplamKredi2 = 0;
            {
                //Gano
                int adet = 0;
                SqlCommand komut1 = new SqlCommand("Select count(harfNotu) from Tbl_Dersler where donemBilgisi = 2 ", baglanti);
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    adet = Convert.ToInt32(dr1[0].ToString());
                    //arrlist1.Add(dr1[0].ToString());
                }
                dr1.Close();

                ArrayList harfNotList1 = new ArrayList();
                SqlCommand komut2 = new SqlCommand("Select harfNotu from Tbl_Dersler where donemBilgisi = 2 ", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {
                    harfNotList1.Add(dr2[0].ToString());
                }

                double not = 0;

                ArrayList notList1 = new ArrayList();
                for (int i = 0; i < harfNotList1.Count; i++)
                {

                    string harfNot = harfNotList1[i].ToString();
                    if (harfNot == "AA                  ")
                    {
                        not = 4.0;
                    }
                    else if (harfNot == "BA                  ")
                    {
                        not = 3.5;
                    }
                    else if (harfNot == "BB                  ")
                    {
                        not = 3.0;
                    }
                    else if (harfNot == "CB                  ")
                    {
                        not = 2.5;
                    }
                    else if (harfNot == "CC                  ")
                    {
                        not = 2.0;
                    }
                    else if (harfNot == "DC                  ")
                    {
                        not = 1.5;
                    }
                    else if (harfNot == "DD                  ")
                    {
                        not = 1.0;
                    }
                    else if (harfNot == "FD                  ")
                    {
                        not = 0.5;
                    }
                    else if (harfNot == "FF                  ")
                    {
                        not = 0.0;
                    }

                    notList1.Add(not);
                }

                dr2.Close();
                
                
                ArrayList krediList1 = new ArrayList();
                SqlCommand komut3 = new SqlCommand("Select dersKredi from Tbl_Dersler where ortalama between 0 and 101  AND donemBilgisi = 2", baglanti);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    krediList1.Add(Convert.ToInt32(dr3[0].ToString()));

                    for (int j = 0; j < krediList1.Count; j++)
                    {
                        float carpim = Convert.ToInt32(notList1[j]) * Convert.ToInt32(krediList1[j]);
                        total2 = total2 + carpim;
                        toplamKredi2 = toplamKredi2 + Convert.ToInt32(krediList1[j]);
                    }
                }
                dr3.Close();
                double ortalama2 = total2 / toplamKredi2;
                ortalama2 = Math.Round(ortalama2, 2);

                double ortalamacgpa2 = ((total1 + total2) / (toplamKredi1 + toplamKredi2));
                ortalamacgpa2 = Math.Round(ortalamacgpa2, 2);

                TxtDnm2Gpa.Text = "GPA: " + (ortalama2) + "";
                TxtDnm2Cgpa.Text = "CGPA: " + ortalamacgpa2;
            }


            //DÖNEM 3 İÇİN GPA VE CGPA HESAPLAMA
            double total3 = 0;
            int toplamKredi3 = 0;
            {
                //Gano
                int adet = 0;
                SqlCommand komut1 = new SqlCommand("Select count(harfNotu) from Tbl_Dersler where donemBilgisi = 3 ", baglanti);
                SqlDataReader dr1 = komut1.ExecuteReader();
                while (dr1.Read())
                {
                    adet = Convert.ToInt32(dr1[0].ToString());
                    //arrlist1.Add(dr1[0].ToString());
                }
                dr1.Close();



                ArrayList harfNotList1 = new ArrayList();
                SqlCommand komut2 = new SqlCommand("Select harfNotu from Tbl_Dersler where donemBilgisi = 3", baglanti);
                SqlDataReader dr2 = komut2.ExecuteReader();
                while (dr2.Read())
                {

                    harfNotList1.Add(dr2[0].ToString());

                }

                double not = 0;

                ArrayList notList1 = new ArrayList();
                for (int i = 0; i < harfNotList1.Count; i++)
                {

                    string harfNot = harfNotList1[i].ToString();
                    if (harfNot == "AA                  ")
                    {
                        not = 4.0;
                    }
                    else if (harfNot == "BA                  ")
                    {
                        not = 3.5;
                    }
                    else if (harfNot == "BB                  ")
                    {
                        not = 3.0;
                    }
                    else if (harfNot == "CB                  ")
                    {
                        not = 2.5;
                    }
                    else if (harfNot == "CC                  ")
                    {
                        not = 2.0;
                    }
                    else if (harfNot == "DC                  ")
                    {
                        not = 1.5;
                    }
                    else if (harfNot == "DD                  ")
                    {
                        not = 1.0;
                    }
                    else if (harfNot == "FD                  ")
                    {
                        not = 0.5;
                    }
                    else if (harfNot == "FF                  ")
                    {
                        not = 0.0;
                    }

                    notList1.Add(not);
                }

                dr2.Close();
                
                ArrayList krediList1 = new ArrayList();
                SqlCommand komut3 = new SqlCommand("Select dersKredi from Tbl_Dersler where ortalama between 0 and 101 AND donemBilgisi = 3", baglanti);
                SqlDataReader dr3 = komut3.ExecuteReader();
                while (dr3.Read())
                {
                    krediList1.Add(Convert.ToInt32(dr3[0].ToString()));

                    for (int j = 0; j < krediList1.Count; j++)
                    {
                        float carpim = Convert.ToInt32(notList1[j]) * Convert.ToInt32(krediList1[j]);
                        total3 = total3 + carpim;
                        toplamKredi3 = toplamKredi3 + Convert.ToInt32(krediList1[j]);
                    }
                }
                dr3.Close();
                double ortalama3 = 0;
                ortalama3 = total3 / toplamKredi3;
                ortalama3 = Math.Round(ortalama3, 2);

                double ortalamacgpa3 = ((total1 + total2 + total3) / (toplamKredi1 + toplamKredi2 + toplamKredi3));
                ortalamacgpa3 = Math.Round(ortalamacgpa3, 2);

                TxtDnm3Gpa.Text = "GPA: " + (ortalama3) + "";
                TxtDnm3Cgpa.Text = "CGPA: " + ortalamacgpa3;
            }

            baglanti.Close();
        }

        
    }
}
