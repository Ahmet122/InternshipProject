using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renklerle_Şifreleme_Konsol
{
    public partial class Panel_OPen4 : UserControl
    {
        static string[] Renkler;

        public Panel_OPen4()
        {
            InitializeComponent();
        }

        private void Panel_Open4_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e) //Renkler dosyasının seçilmesi için kullanılan buton.
        {
            OpenFileDialog File = new OpenFileDialog();
            if (File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = File.FileName;
                string strfilename = File.FileName;
                MessageBox.Show("Dosya Seçildi", "Yükleme Durumu");
            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi!", "Yükleme Durumu");
            }
        }

        private void Button2_Click(object sender, EventArgs e) //Seçilen Renk dosyasının içine, mesaj şifrelenirken boşluk yerine kullanılacak karakter eklenir ve dosya programa yüklenir.
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(@textBox1.Text);
            Renkler = new string[27];
            for (int i = 0; i < 27; i++)
            {
                Renkler[i] = sr.ReadLine();
            }
            Renkler[26] = "Rb";
            MessageBox.Show(string.Join(" ", Renkler), "Yükleme Durumu");

            sr.Close();
        }

        private void Button4_Click(object sender, EventArgs e) //Şifrelenecek olan dosyayı seçmemiz için panel açılır.
        {
            OpenFileDialog File = new OpenFileDialog();
            if (File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = File.FileName;
                string strfilename = File.FileName;
                MessageBox.Show("Dosya Seçildi", "Yükleme Durumu");
            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi!", "Yükleme Durumu");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(textBox2.Text);
            string[] satir = System.IO.File.ReadAllLines(textBox2.Text);
            for(int k = 0; k < satir.Length; k++)
            {
                satir[k] = satir[k].ToLower();
            }
            sr.Close();
                
            System.IO.StreamWriter Sifrelenmis_Dosya = new System.IO.StreamWriter("Sifrelenmis_Dosya.txt");
            for (int i = 0; i < satir.Length; i++)
            {
                string[] Sifrelenmis_Satir = Mesaj_Sifreleme(satir[i], satir[i].Length);

                for (int j = 0; j < Sifrelenmis_Satir.Length; j++)
                {
                    Sifrelenmis_Dosya.Write(Sifrelenmis_Satir[j]);
                }
                Sifrelenmis_Dosya.Write("\n");
            }
            Sifrelenmis_Dosya.Close();
            MessageBox.Show("Sifreleme basarıyla tamamlandı!", "Durum");
        }

        static string[] Mesaj_Sifreleme(string mesaj, int mesaj_uzunlugu)
        {
            mesaj = mesaj.ToLower();
            string[] sifrelenmis_mesaj = new string[mesaj_uzunlugu];
            for (int i = 0; i < mesaj.Length; i++)
            {
                if (mesaj[i] == 32)
                {
                    sifrelenmis_mesaj[i] = Renkler[26] + ' ';
                }
                /*else if (mesaj[i] < 91)
                {
                    sifrelenmis_mesaj[i] = Renkler[mesaj[i] - 65] + ' ';
                }*/
                else
                {
                    sifrelenmis_mesaj[i] = Renkler[mesaj[i] - 97] + ' ';
                }
            }
            return sifrelenmis_mesaj;
        }
    }
        
}
