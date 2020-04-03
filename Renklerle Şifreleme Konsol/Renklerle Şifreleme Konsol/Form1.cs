using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Renklerle_Şifreleme_Konsol
{
    public partial class Form1 : Form //Form'un kodu.
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//Form ilk başlatıldığında hangi panellerin gösterileceğinin koda verildiği kısım.
        {
            panel_Open1.Visible = false;
            panel_open21.Visible = false;
            panel_Open31.Visible = false;
            panel_OPen41.Visible = false;
        }

        private void UserControl12_Click(object sender, EventArgs e)//Encryption butonuna basıldığında yapacağı işlem.
        {
            panel_Open1.Visible = true;
            panel_open21.Visible = false;
            panel_Open31.Visible = false;
            panel_OPen41.Visible = false;
        }

        private void UserControl13_Click(object sender, EventArgs e)//Decryption butonuna basıldığında yapacağı işlem.
        {
            panel_Open1.Visible = false;
            panel_open21.Visible = true;
            panel_Open31.Visible = false;
            panel_OPen41.Visible = false;
        }

        private void UserControl15_Click(object sender, EventArgs e)//File Encryption butonuna basıldığında yapacağı işlem.
        {
            panel_Open1.Visible = false;
            panel_open21.Visible = false;
            panel_Open31.Visible = true;
            panel_OPen41.Visible = false;
        }

        private void UserControl14_Click(object sender, EventArgs e)//File Decryption butonuna basıldığında yapacağı işlem.
        {
            panel_Open1.Visible = false;
            panel_open21.Visible = false;
            panel_Open31.Visible = false;
            panel_OPen41.Visible = true;
        }

        private void UserControl19_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UserControl110_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void UserControl16_Click_1(object sender, EventArgs e)
        {
            panel_Open1.Visible = false;
            panel_open21.Visible = false;
            panel_Open31.Visible = false;
            panel_OPen41.Visible = false;
        }
    }
}
