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
    public partial class Panel_Open3 : UserControl
    {
        static string[] Renkler;

        public Panel_Open3()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) //Renkler dosyasının seçilmesi için kullanılan buton.
        {
            OpenFileDialog File = new OpenFileDialog(); //Klasik dosya seçim ekranı için kullanılan hazır fonksiyon.
            if (File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = File.FileName; //Seçilen dosyanın tam adresi textBox1' e yazıldı.
                string strfilename = File.FileName;
                MessageBox.Show("Dosya Yüklendi", "Yükleme Durumu"); //Yükleme durum mesajı.
            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi!", "Yükleme Durumu");
            }
        }

        private void Button2_Click(object sender, EventArgs e) //Seçilen Renk dosyasının içine, mesaj şifrelenirken boşluk yerine kullanılacak karakter eklenir ve dosya programa yüklenir.
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(textBox1.Text);
            Renkler = new string[27];
            for (int i = 0; i < 27; i++)
            {
                Renkler[i] = sr.ReadLine(); //Renkler dosyası satır satır okunur ve içeriği Renkler dizisine konulur.
            }
            Renkler[26] = "Rb"; //Diziye boşluk karakteri için belirlenen kısaltma eklendi.
            MessageBox.Show(string.Join(" ", Renkler), "Yükleme Durumu");

            sr.Close();
        }

        private void Button4_Click(object sender, EventArgs e) //Şifreli metin dosyasını seçmemizi sağlayan buton.
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

        private void Button3_Click(object sender, EventArgs e) //Decryption işleminde yapılan işlemler bu aşamada dosya deşifrelemeye uygulandı.
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(textBox2.Text);
            string[] satir = System.IO.File.ReadAllLines(textBox2.Text);
            sr.Close();

            System.IO.StreamWriter Desifrelenmis_Dosya = new System.IO.StreamWriter("Desifrelenmis_Dosya.txt");
            for (int i = 0; i < satir.Length; i++)
            {
                string[] sifrelenmis_satir = satir[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                char[] Desifrelenmis_Satir = Mesaj_Desifreleme(sifrelenmis_satir, sifrelenmis_satir.Length);

                Desifrelenmis_Dosya.Write(Desifrelenmis_Satir);
                Desifrelenmis_Dosya.Write("\n");
            }
            Desifrelenmis_Dosya.Close();
            MessageBox.Show("Sifreleme basarıyla tamamlandı!", "Durum");
        }
        static char[] Mesaj_Desifreleme(string[] sifrelenmis_mesaj, int mesaj_uzunlugu)
        {
            char[] orjinal_mesaj = new char[mesaj_uzunlugu];

            for (int i = 0; i < mesaj_uzunlugu; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (String.Compare(sifrelenmis_mesaj[i], Renkler[j]) == 0)
                    {
                        if (j == 26)
                        {
                            orjinal_mesaj[i] = ' ';
                        }
                        else
                        {
                            orjinal_mesaj[i] = (char)(j + 97);
                        }
                    }
                }
            }
            return orjinal_mesaj;
        }
    }
}
