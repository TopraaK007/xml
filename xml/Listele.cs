using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace xml
{
    public partial class Listele : Form
    {
        private string dosyayolu;
        public Listele()
        {
            InitializeComponent();
        }
        private void Yenile()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numara");
            dt.Columns.Add("Ad");
            dt.Columns.Add("Soyad");
            dt.Columns.Add("Sınıf");

            string verilerKlasoru = "veriler/";

            foreach (string dosya in Directory.GetFiles(verilerKlasoru, "*.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(dosya);

                DataRow row = dt.NewRow();
                row["Numara"] = xml.SelectSingleNode("/ogrenci/numara")?.InnerText;
                row["Ad"] = xml.SelectSingleNode("/ogrenci/ad")?.InnerText;
                row["Soyad"] = xml.SelectSingleNode("/ogrenci/soyad")?.InnerText;
                row["Sınıf"] = xml.SelectSingleNode("/ogrenci/sınıf")?.InnerText;

                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Numara"].ReadOnly = true;
            dataGridView1.Columns["Ad"].ReadOnly = true;
            dataGridView1.Columns["Soyad"].ReadOnly = true;
            dataGridView1.Columns["Sınıf"].ReadOnly = true;
           

        }

        private void Listele_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Numara");
            dt.Columns.Add("Ad");
            dt.Columns.Add("Soyad");
            dt.Columns.Add("Sınıf");

            string verilerKlasoru = "veriler/";

            foreach (string dosya in Directory.GetFiles(verilerKlasoru, "*.xml"))
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(dosya);

                DataRow row = dt.NewRow();
                row["Numara"] = xml.SelectSingleNode("/ogrenci/numara")?.InnerText;
                row["Ad"] = xml.SelectSingleNode("/ogrenci/ad")?.InnerText;
                row["Soyad"] = xml.SelectSingleNode("/ogrenci/soyad")?.InnerText;
                row["Sınıf"] = xml.SelectSingleNode("/ogrenci/sınıf")?.InnerText;

                dt.Rows.Add(row);
            }
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Numara"].ReadOnly = true;
            dataGridView1.Columns["Ad"].ReadOnly = true;
            dataGridView1.Columns["Soyad"].ReadOnly = true;
            dataGridView1.Columns["Sınıf"].ReadOnly = true;
        }

        private void Listele_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            anasayfa ana = new anasayfa();
            ana.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;

            string numara = dataGridView1.Rows[seciliAlan].Cells[0].Value.ToString();
            string ad = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();
            string sinif = dataGridView1.Rows[seciliAlan].Cells[3].Value.ToString();

            txtNumara.Text = numara;
            txtAd.Text = ad;
            txtSoyad.Text = soyad;
            txtSinif.Text = sinif;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = txtNumara.Text;
            dosyayolu = "veriler/" + no + ".xml";

            if (File.Exists(dosyayolu))
            {
                int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;//tıklanan satırı seçer

                File.Delete(dosyayolu);
                dataGridView1.Rows.RemoveAt(seciliAlan);//seçili satırı siler.

                txtAd.Text = "";
                txtNumara.Text = "";
                txtSinif.Text = "";
                txtSoyad.Text = "";

                MessageBox.Show("silindi");

            }
            else
            {
                MessageBox.Show("Lütfen Tablodan Öğrenci Seçiniz!");
            }

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            string no = txtNumara.Text;
            string isim = txtAd.Text;
            string soyisim = txtSoyad.Text;
            string sinif1 = txtSinif.Text;
            dosyayolu = "veriler/" + no + ".xml";
            if (!string.IsNullOrEmpty(isim) || !string.IsNullOrEmpty(soyisim) || !string.IsNullOrEmpty(sinif1))
            {

                if (File.Exists(dosyayolu))
                {
                    try
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(dosyayolu);

                        XmlNode ogrenciNode = xml.SelectSingleNode("/ogrenci");

                        if (ogrenciNode != null)
                        {
                            XmlNode adNode = ogrenciNode.SelectSingleNode("ad");
                            XmlNode soyadNode = ogrenciNode.SelectSingleNode("soyad");
                            XmlNode sinifNode = ogrenciNode.SelectSingleNode("sınıf");

                            if (adNode != null) adNode.InnerText = isim;
                            if (soyadNode != null) soyadNode.InnerText = soyisim;
                            if (sinifNode != null) sinifNode.InnerText = sinif1;

                            xml.Save(dosyayolu);
                            MessageBox.Show("Veriler Güncellendi");

                            Yenile();
                        }
                        else
                        {
                            MessageBox.Show("Öğrenci bulunamadı!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme İşlemi Başarısız: " + ex.Message);
                    }
                }


            }
            else
            {
                MessageBox.Show("Lütfen Tablodan Öğrenci Seçiniz!");
            }

        }
    }
}
