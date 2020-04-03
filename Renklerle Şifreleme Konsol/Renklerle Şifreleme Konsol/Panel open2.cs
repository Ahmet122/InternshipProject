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
    public partial class Panel_open2 : UserControl
    {

        static string[] Renkler;
        static char[] orjinal_mesaj;
        public Panel_open2()
        {
            InitializeComponent();
        }

        private void Panel_open2_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click_1(object sender, EventArgs e) //Renkler dosyasının seçilmesi için kullanılan buton.
        {
            OpenFileDialog File = new OpenFileDialog(); //Klasik dosya seçim ekranı için kullanılan hazır fonksiyon.
            if (File.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = File.FileName; //Seçilen dosyanın tam adresi textBox1' e yazıldı.
                string strfilename = File.FileName;
                MessageBox.Show("Dosya Seçildi", "Yükleme Durumu"); //Yükleme durum mesajı.
            }
            else
            {
                MessageBox.Show("Dosya Seçilmedi!", "Yükleme Durumu");
            }
        }

        private void Button2_Click_1(object sender, EventArgs e) //Seçilen Renk dosyasının içine, mesaj şifrelenirken boşluk yerine kullanılacak karakter eklenir ve dosya programa yüklenir.
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(textBox1.Text); //textBox1'de adresi bulunan dosyanın içeriğini okur.
            Renkler = new string[27];
            for (int i = 0; i < 27; i++)
            {
                Renkler[i] = sr.ReadLine(); //Renkler dosyası satır satır okunur ve içeriği Renkler dizisine konur.
            }
            Renkler[26] = "R"; //Boşluk karakteri için belirlenen kısaltma diziye eklendi.
            MessageBox.Show(string.Join(" ", Renkler)); //Renker dizisi ekrana basılır ve kontrolü sağlanır.

            sr.Close();
        }

        private void Button3_Click_1(object sender, EventArgs e) //Şifrelenmiş mesajın deşifrelenmesi.
        {
            orjinal_mesaj = new char[textBox2.Text.Length]; //Orjinal mesajın uzunluğu şifreli mesajın uzunluğu olarak belirlendi.
            int indis = 0;
            string kelimem = "";
            int uzunluk = textBox2.Text.Length;
            string[] text = new string[uzunluk];
            for (int i = 0; i < uzunluk; i++)
            {
                if(textBox2.Text[i]== ' ') //Şifreli mesaj yazıldığında içerdiği iki harfli kısaltmaları bulmak için boşluklar kullanıldı.
                {
                    indis++; //Boşluk görüldüğünde devam edilir.
                }
                else
                {
                    text[indis]+= textBox2.Text[i]; /*Bu işlem, belirlenmis iki harfli kısaltmalarda(Örneğin Tr), mesajın textBox'dan alınması durumunda, programın
                                                    kısaltmanın ilk harfini ayrı, ikinci harfini ayrı eleman olarak almasından dolayı bu sorunu çözmek için yapılmıştır.*/
                }
            }
            for (int q = 0; q <= indis; q++)
            {
                kelimem += text[q]; //kelimem string'i, textBox2'nin içeriğini text dizisi sayesinde kelime kelime alır.
            }
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
             
            }
            for (int i = 0; i < kelimem.Length; i++) 
            {
              for (int j = 0; j < 27; j++)
              {
                if (string.Compare(text[i], Renkler[j]) == 0) //text dizisinde bulunan kısaltmalar Renkler dizinde bulunanlarla karşılaştırılıyor.
                {
                    if (j == 26) //Daha önceden boşluk karakteri için atanan özel kısaltma Renkler dizisinin 26. elemanına atanmıştı. Burada da bunun kontrolü yapılıyor.
                    {
                        orjinal_mesaj[i] = ' ';
                    }
                    else
                    {
                        orjinal_mesaj[i] = (char)(j + 97); //Eğer sadece kısaltma geldiyse sayısal olarak dizide bulunduğu yer ile 'a' nın ASCII değeri ile toplanır ve böylece orjinal harf bulunur.
                    }
                }
              }
            }

            MessageBox.Show(string.Join("", orjinal_mesaj));
        }
    }
}
