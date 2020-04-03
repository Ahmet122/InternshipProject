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
    public partial class Panel_Open : UserControl
    {
        static string[] Renkler; //Renkler dizisi global tanımlandı.
        static string[] sifrelenmis_mesaj; //Tüm işlemin sonucunda şifrelenen mesajın atandığı dizi tanımlandı.
        public Panel_Open()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e) //Renkler dosyasının seçilmesi için kullanılan buton.
        {
            OpenFileDialog File= new OpenFileDialog(); //Klasik dosya seçim ekranı için kullanılan hazır fonksiyon.
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

        private void Button2_Click(object sender, EventArgs e) //Seçilen Renk dosyasının içine, mesaj şifrelenirken boşluk yerine kullanılacak karakter eklenir ve dosya programa yüklenir.
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(textBox1.Text);
            Renkler = new string[27];
            for (int i = 0; i < 27; i++)
            {
                Renkler[i] = sr.ReadLine(); 
            }
            Renkler[26] = "Rb"; //Diziye boşluk karakteri için belirlenen kısaltma eklendi.
            MessageBox.Show(string.Join(" ", Renkler)); //Renker dizisi ekrana basılır ve kontrolü sağlanır.

            sr.Close();
        }

        private void Button3_Click(object sender, EventArgs e) //textBox2 ye girilen mesajın ASCII değerleri kullanılarak şifrelenip, şifrelenen mesajın ekrana basılmasını sağlayan buton.
        {
            
            sifrelenmis_mesaj = new string[textBox2.Text.Length]; //En başta tanımlanan sifreli_mesaj dizisinin uzunluğu, girilen mesajın uzunluğu olarak belirlendi.
            for (int i = 0; i < textBox2.Text.Length; i++)
            {
                if (textBox2.Text[i] == 32) //Boşluk karakterinin ASCII değeri olan '32' nin kontrolü sağlandı.
                {
                    sifrelenmis_mesaj[i] = Renkler[26]; //Bu kontrol sonucu mesajın boşluk kısmına belirlenen kısaltma yazıldı.
                }
                else if(textBox2.Text[i] < 91)
                {
                    sifrelenmis_mesaj[i] = Renkler[textBox2.Text[i] - 65];
                }
                else
                {
                    sifrelenmis_mesaj[i] = Renkler[textBox2.Text[i] - 97]; //Boşluk haricindeki harflerin, 'a' harfinin ASCII değerinden çıkarılmasıyla Renkler dizinde karşılıkları olan kısaltmalara eşitlenmeleri sağlandı.
                }
            }
            
            MessageBox.Show(string.Join(" ",sifrelenmis_mesaj)); //Şifreli mesajın ekrana yazılması.

        }

        private void Panel_Open_Load(object sender, EventArgs e)
        {

        }
    }
}
