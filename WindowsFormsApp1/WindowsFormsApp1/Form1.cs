using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private int buttonCounter = 0; // Düğme sayacı
        private Random rnd = new Random(); // Rastgele renk için sınıf seviyesinde Random

        public Form1()
        {
            InitializeComponent();
            this.MouseClick += Form1_MouseClick; // MouseClick eventi
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Yeni düğme oluştur
            Button btn = new Button();
            btn.Size = new Size(50, 50);

            // Düğmeyi tıklanan yerin ortasına yerleştir
            btn.Location = new Point(e.X - btn.Width / 2, e.Y - btn.Height / 2);

            // Üzerine numara yaz
            buttonCounter++;
            btn.Text = buttonCounter.ToString();

            // Rastgele renk ata
            btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            btn.ForeColor = Color.Black; // Yazı rengi beyaz olsun

            // Form üzerine ekle
            this.Controls.Add(btn);
        }
    }
}
