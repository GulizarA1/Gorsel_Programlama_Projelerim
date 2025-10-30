using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private int buttonCounter = 1; // Düðmelerin numaralandýrmasý
        private Button aktifButton = null; // Sürükleme sýrasýnda deðiþecek düðme
        private Point baslangicNoktasi;   // MouseDown'da kaydedilen baþlangýç noktasý

        public Form1()
        {
            InitializeComponent();
            this.Text = "Mouse ile Düðme Boyutlandýrma";
            this.Width = 800;
            this.Height = 600;

            // Mouse olaylarýný yakalýyoruz
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Yeni bir düðme oluþtur
                aktifButton = new Button();
                aktifButton.Left = e.X;
                aktifButton.Top = e.Y;
                aktifButton.Width = 10;  // baþlangýç boyutu
                aktifButton.Height = 10;
                aktifButton.Text = buttonCounter.ToString();
                aktifButton.BackColor = Color.Aqua;
                aktifButton.ForeColor = Color.Black;

                this.Controls.Add(aktifButton);

                baslangicNoktasi = e.Location; // baþlangýç noktasýný kaydet
                buttonCounter++;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (aktifButton != null)
            {
                // Boyutu deðiþtir: sol üst sabit, sað alt fareye göre deðiþir
                int width = e.X - baslangicNoktasi.X;
                int height = e.Y - baslangicNoktasi.Y;

                // Negatif deðerleri önle
                aktifButton.Width = Math.Abs(width);
                aktifButton.Height = Math.Abs(height);

                // Eðer fare yukarý veya sola gidiyorsa, düðmeyi sola/üsteye kaydýr
                aktifButton.Left = width < 0 ? e.X : baslangicNoktasi.X;
                aktifButton.Top = height < 0 ? e.Y : baslangicNoktasi.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Fare býrakýldýðýnda aktif düðmeyi null yapýyoruz, boyutu sabit kalýr
            aktifButton = null;
        }
    }
}
