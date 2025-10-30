using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private int buttonCounter = 1; // D��melerin numaraland�rmas�
        private Button aktifButton = null; // S�r�kleme s�ras�nda de�i�ecek d��me
        private Point baslangicNoktasi;   // MouseDown'da kaydedilen ba�lang�� noktas�

        public Form1()
        {
            InitializeComponent();
            this.Text = "Mouse ile D��me Boyutland�rma";
            this.Width = 800;
            this.Height = 600;

            // Mouse olaylar�n� yakal�yoruz
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Yeni bir d��me olu�tur
                aktifButton = new Button();
                aktifButton.Left = e.X;
                aktifButton.Top = e.Y;
                aktifButton.Width = 10;  // ba�lang�� boyutu
                aktifButton.Height = 10;
                aktifButton.Text = buttonCounter.ToString();
                aktifButton.BackColor = Color.Aqua;
                aktifButton.ForeColor = Color.Black;

                this.Controls.Add(aktifButton);

                baslangicNoktasi = e.Location; // ba�lang�� noktas�n� kaydet
                buttonCounter++;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (aktifButton != null)
            {
                // Boyutu de�i�tir: sol �st sabit, sa� alt fareye g�re de�i�ir
                int width = e.X - baslangicNoktasi.X;
                int height = e.Y - baslangicNoktasi.Y;

                // Negatif de�erleri �nle
                aktifButton.Width = Math.Abs(width);
                aktifButton.Height = Math.Abs(height);

                // E�er fare yukar� veya sola gidiyorsa, d��meyi sola/�steye kayd�r
                aktifButton.Left = width < 0 ? e.X : baslangicNoktasi.X;
                aktifButton.Top = height < 0 ? e.Y : baslangicNoktasi.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            // Fare b�rak�ld���nda aktif d��meyi null yap�yoruz, boyutu sabit kal�r
            aktifButton = null;
        }
    }
}
