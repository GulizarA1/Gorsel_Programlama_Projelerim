using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            // 
        }

        private List<int> kullanilanNumaralar = new List<int>(); // Kullan�lm�� numaralar
        private Random rnd = new Random(); // Rastgele renk i�in

        public Form1()
        {
            InitializeComponent();
            this.Text = "MouseClick ile Renkli D��meler (En K���k Numara)";
            this.Width = 800;
            this.Height = 600;

            // MouseClick olay�n� yakal�yoruz
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Yeni bir d��me olu�turuyoruz
            Button btn = new Button();
            btn.Width = 50;
            btn.Height = 50;

            // D��meyi t�klanan nokta ortalanacak �ekilde yerle�tiriyoruz
            btn.Left = e.X - btn.Width / 2;
            btn.Top = e.Y - btn.Height / 2;

            // Yeni d��menin alaca�� en k���k bo� numaray� buluyoruz
            int yeniNumara = 1;
            while (kullanilanNumaralar.Contains(yeniNumara))
                yeniNumara++;
            kullanilanNumaralar.Add(yeniNumara);

            // D��meye numara yaz�yoruz
            btn.Text = yeniNumara.ToString();

            // Rastgele arka plan rengi veriyoruz
            btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            btn.ForeColor = Color.Black;

            // Click olay�n� i�liyoruz: klasik y�ntemle
            btn.Click += Btn_Click;

            // D��meyi formun Controls koleksiyonuna ekliyoruz
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                int numara = int.Parse(b.Text);
                kullanilanNumaralar.Remove(numara);

                // D��meyi kald�r�yoruz
                b.Dispose();
            }
        }
    }
}
