using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace xml
{
    public partial class anasayfa : Form
    {
        private void Yenile()
        {
            string no=txtNo.Text;
            dosyayolu = "veriler/" + no + ".xml";

            if (File.Exists(dosyayolu))
            {

                try
                {

                   
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(dosyayolu);

                    DataTable dt = new DataTable(); //Bu nesne, bir tabloyu temsil eden bir veri yapısıdır.
                    dt.Columns.Add("Numara");
                    dt.Columns.Add("Ad");
                    dt.Columns.Add("Soyad");
                    dt.Columns.Add("Sınıf");


                    XmlNodeList nodes = xmldoc.SelectNodes("/ogrenci");
                    foreach (XmlNode ogrenciNode in nodes)
                    {
                        DataRow row = dt.NewRow(); //bu sınıf sayesinde DatTable yapısında tanımlanan sütun uygun boş satır ayarlar.
                        row["Numara"] = ogrenciNode.SelectSingleNode("numara").InnerText;
                        row["Ad"] = ogrenciNode.SelectSingleNode("ad").InnerText;
                        row["Soyad"] = ogrenciNode.SelectSingleNode("soyad").InnerText;
                        row["Sınıf"] = ogrenciNode.SelectSingleNode("sınıf").InnerText;



                        dt.Rows.Add(row);

                    }

                    dataGridView1.Show();
                    button5.Show();

                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["Numara"].ReadOnly = true;
                    dataGridView1.Columns["Ad"].ReadOnly = true;
                    dataGridView1.Columns["Soyad"].ReadOnly = true;
                    dataGridView1.Columns["Sınıf"].ReadOnly = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Xml Dosyası Okunamadı!" + ex.ToString());
                }


            }
            else
            {
                MessageBox.Show("Dosya Bulunamadı!");
            }

        }

        public anasayfa()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
          
            button5.Hide();
            button6.Hide();
            label2.Hide();
            Soyisim.Hide();
            label4.Hide();
            label5.Hide();
            button7.Hide();
            txtAd.Hide();
            txtSoyad.Hide();
            txtSinif.Hide();
            txtNumara.Hide();
            txtAd1.Hide();
            txtSoyad1.Hide();
            txtSinif1.Hide();
            button6.Hide();
            label3.Hide();
            label6.Hide();
            label7.Hide();
            label9.Hide();
            txtNumara1.Hide();
        }
        //private void FormGetir(Form form)
        //{
          
        //}


        private void button2_Click(object sender, EventArgs e)
        {
            txtNo.Text = "";
            label2.Show();
            Soyisim.Show();
            label4.Show();
            label5.Show();
            button7.Show();
            txtAd.Show();
            txtSoyad.Show();
            txtSinif.Show();
            txtNumara.Show();
            dataGridView1.Hide();
            txtAd1.Hide();
            txtSoyad1.Hide();
            txtSinif1.Hide();
            button6.Hide();
            label3.Hide();
            label6.Hide();
            label7.Hide();
            button5.Hide();
            label9.Hide();
            txtNumara1.Hide();
        }
        private string dosyayolu;
        private void button1_Click(object sender, EventArgs e)
        {
            label2.Hide();
            Soyisim.Hide();
            label4.Hide();
            label5.Hide();
            button7.Hide();
            txtAd.Hide();
            txtSoyad.Hide();
            txtSinif.Hide();
            txtNumara.Hide();
            txtAd1.Hide();
            txtSoyad1.Hide();
            txtSinif1.Hide();
            button6.Hide();
            label9.Hide();
            txtNumara1.Hide();
            string no = txtNo.Text;
            if (!string.IsNullOrEmpty(no))
            {
                dosyayolu = "veriler/" + no + ".xml";

                if (File.Exists(dosyayolu))
                {

                    try
                    {

                        MessageBox.Show("Dosya Bulundu.");
                        XmlDocument xmldoc = new XmlDocument();
                        xmldoc.Load(dosyayolu);

                        DataTable dt = new DataTable(); //Bu nesne, bir tabloyu temsil eden bir veri yapısıdır.
                        dt.Columns.Add("Numara");
                        dt.Columns.Add("Ad");
                        dt.Columns.Add("Soyad");
                        dt.Columns.Add("Sınıf");


                        XmlNodeList nodes = xmldoc.SelectNodes("/ogrenci");
                        foreach (XmlNode ogrenciNode in nodes)
                        {
                            DataRow row = dt.NewRow(); //bu sınıf sayesinde DatTable yapısında tanımlanan sütun uygun boş satır ayarlar.
                            row["Numara"] = ogrenciNode.SelectSingleNode("numara").InnerText;
                            row["Ad"] = ogrenciNode.SelectSingleNode("ad").InnerText;
                            row["Soyad"] = ogrenciNode.SelectSingleNode("soyad").InnerText;
                            row["Sınıf"] = ogrenciNode.SelectSingleNode("sınıf").InnerText;



                            dt.Rows.Add(row);

                        }

                        dataGridView1.Show();
                        button5.Show();
                       
                        dataGridView1.DataSource = dt;
                        dataGridView1.Columns["Numara"].ReadOnly = true;
                        dataGridView1.Columns["Ad"].ReadOnly = true;
                        dataGridView1.Columns["Soyad"].ReadOnly = true;
                        dataGridView1.Columns["Sınıf"].ReadOnly = true;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Xml Dosyası Okunamadı!" + ex.ToString());
                    }


                }
                else
                {
                    MessageBox.Show("Dosya Bulunamadı!");
                }
            }
            else
            {
                MessageBox.Show("Boş geçilemez");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (File.Exists(dosyayolu))
                {
                    File.Delete(dosyayolu);
                    MessageBox.Show("Xml dosyası silindi!!!");
                    dataGridView1.DataSource = null;
                    dataGridView1.Hide();
                    button5.Hide();
                    button6.Hide();
                    
                   
                }
                else
                {
                    MessageBox.Show("Dosya Bulunamadı!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Silme işlemi Gerçekleşemedi!" + ex.ToString());
            }
        }


        private void button6_Click(object sender, EventArgs e)
        {

            string isim = txtAd1.Text;
            string soyisim = txtSoyad1.Text;
            string sinif1=txtSinif1.Text;
            string numara1 = txtNumara1.Text;

            dosyayolu = "veriler/" + numara1 + ".xml";

            if (!string.IsNullOrEmpty(isim) || !string.IsNullOrEmpty(soyisim) || !string.IsNullOrEmpty(sinif1)) {

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

                            txtAd1.Hide();
                            txtSoyad1.Hide();
                            txtSinif1.Hide();
                            label3.Hide();
                            label6.Hide();
                            label7.Hide();
                            button6.Hide();
                            label9.Hide();
                            txtNumara1.Hide();
                            Soyisim.Hide();
                            label2.Hide();
                            label4.Hide();
                            label5.Hide();

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
                MessageBox.Show("Lütfen Gerekli Alanları Doldurun!");
            }
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
           
            string kadi = txtAd.Text;
            string ksoyad = txtSoyad.Text;
            string numara = txtNumara.Text;
            string sinif = txtSinif.Text;
            if (!string.IsNullOrEmpty(kadi) || !string.IsNullOrEmpty(ksoyad) || !string.IsNullOrEmpty(sinif) || !string.IsNullOrEmpty(numara))
            {
                string dosyayolu = "veriler/" + numara + ".xml";
              if (File.Exists(dosyayolu))
               {
                   MessageBox.Show("Zaten Dosya mevcut");

                }
                else
               {
                    XmlDocument xml = new XmlDocument();
                    XmlElement ogrenciElement = xml.CreateElement("ogrenci");
                    xml.AppendChild(ogrenciElement);

                    XmlElement numaraElement = xml.CreateElement("numara");
                    numaraElement.InnerText = numara;
                    ogrenciElement.AppendChild(numaraElement);

                    XmlElement adElement = xml.CreateElement("ad");
                    adElement.InnerText = kadi;
                    ogrenciElement.AppendChild(adElement);

                    XmlElement soyadElement = xml.CreateElement("soyad");
                    soyadElement.InnerText = ksoyad;
                    ogrenciElement.AppendChild(soyadElement);

                   XmlElement sinifElement = xml.CreateElement("sınıf");
                   sinifElement.InnerText = sinif;
                   ogrenciElement.AppendChild(sinifElement);

                   xml.Save(dosyayolu);

                   MessageBox.Show("Öğrenci Oluşturuldu!");
                    label2.Hide();
                    Soyisim.Hide();
                    label4.Hide();
                    label5.Hide();
                    button7.Hide();
                    txtAd.Hide();
                    txtSoyad.Hide();
                    txtSinif.Hide();
                    txtNumara.Hide();


                }


            }
            else
            {
               MessageBox.Show("Lütfen ilgili alanları doldurunuz!");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int seciliAlan = dataGridView1.SelectedCells[0].RowIndex;//seçilen hücrenin bulunduğu hücrenin satırnı indeksini aldık.
            string numara = dataGridView1.Rows[seciliAlan].Cells[0].Value.ToString();//0 indexse sahip hücrenin değerini alırız.
            string ad = dataGridView1.Rows[seciliAlan].Cells[1].Value.ToString();
            string soyad = dataGridView1.Rows[seciliAlan].Cells[2].Value.ToString();
            string sinif = dataGridView1.Rows[seciliAlan].Cells[3].Value.ToString();

            txtNumara1.Text = numara;
            txtAd1.Text = ad;
            txtSoyad1.Text = soyad;
            txtSinif1.Text = sinif;
            txtAd1.Show();
            txtSoyad1.Show();
            txtSinif1.Show();
            label3.Show();
            label6.Show();
            label7.Show();
            button6.Show();
            label9.Show();
            txtNumara1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Listele l =new Listele();
            this.Hide();
            l.Show();
            
        }

        private void anasayfa_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void anasayfa_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

//e.KeyChar klavyeden girilen karakteri temsil ediyor.
//girilen karakter ne kontrol karakteri ne de rakam ise, bu karakterin olayının işlenmediği belirtilir. Bu da girilen karakterin görüntülenmeyeceği veya kullanılmayacağı anlamına gelir.
        }
    }
}
    
