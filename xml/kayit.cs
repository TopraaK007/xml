using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace xml
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           string kadi=txtAd.Text;
           string ksoyad=txtSoyad.Text;
           string numara = txtNumara.Text;
           string sinif = txtSinif.Text;
            if(!string.IsNullOrEmpty(kadi)|| !string.IsNullOrEmpty(ksoyad) || !string.IsNullOrEmpty(sinif) || !string.IsNullOrEmpty(numara))
            {
                string dosyayolu = "veriler/" + numara + ".xml";
                if (File.Exists(dosyayolu))
                {
                    MessageBox.Show("Zaten Dosya mevcut");

                }
                else
                {
                    XmlDocument xml =new XmlDocument();
                    XmlElement ogrenciElement = xml.CreateElement("ogrenci");
                    xml.AppendChild(ogrenciElement);

                    XmlElement numaraElement = xml.CreateElement("numara");
                    numaraElement.InnerText=numara;
                    ogrenciElement.AppendChild(numaraElement);

                    XmlElement adElement = xml.CreateElement("ad");
                    adElement.InnerText=kadi;
                    ogrenciElement.AppendChild(adElement);

                    XmlElement soyadElement = xml.CreateElement("soyad");
                    soyadElement.InnerText=ksoyad;
                    ogrenciElement.AppendChild(soyadElement);

                    XmlElement sinifElement = xml.CreateElement("sınıf");
                    sinifElement.InnerText = sinif;
                    ogrenciElement.AppendChild(sinifElement);

                    xml.Save(dosyayolu);

                    MessageBox.Show("Öğrenci Oluşturuldu!");

                   
                    this.Close();

                   
                }

               
            }
            else
            {
                MessageBox.Show("Lütfen ilgili alanları doldurunuz!");
            }
        }
    }
}
