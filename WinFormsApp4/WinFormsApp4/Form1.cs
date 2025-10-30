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

        private List<int> kullanilanNumaralar = new List<int>(); // Kullanýlmýþ numaralar
        private Random rnd = new Random(); // Rastgele renk için

        public Form1()
        {
            InitializeComponent();
            this.Text = "MouseClick ile Renkli Düðmeler (En Küçük Numara)";
            this.Width = 800;
            this.Height = 600;

            // MouseClick olayýný yakalýyoruz
            this.MouseClick += Form1_MouseClick;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // Yeni bir düðme oluþturuyoruz
            Button btn = new Button();
            btn.Width = 50;
            btn.Height = 50;

            // Düðmeyi týklanan nokta ortalanacak þekilde yerleþtiriyoruz
            btn.Left = e.X - btn.Width / 2;
            btn.Top = e.Y - btn.Height / 2;

            // Yeni düðmenin alacaðý en küçük boþ numarayý buluyoruz
            int yeniNumara = 1;
            while (kullanilanNumaralar.Contains(yeniNumara))
                yeniNumara++;
            kullanilanNumaralar.Add(yeniNumara);

            // Düðmeye numara yazýyoruz
            btn.Text = yeniNumara.ToString();

            // Rastgele arka plan rengi veriyoruz
            btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            btn.ForeColor = Color.Black;

            // Click olayýný iþliyoruz: klasik yöntemle
            btn.Click += Btn_Click;

            // Düðmeyi formun Controls koleksiyonuna ekliyoruz
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                int numara = int.Parse(b.Text);
                kullanilanNumaralar.Remove(numara);

                // Düðmeyi kaldýrýyoruz
                b.Dispose();
            }
        }
    }
}
