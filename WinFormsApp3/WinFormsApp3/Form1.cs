using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3

{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            // Buraya form a��ld���nda yap�lacak i�lemleri yazabilirsin
        }

        private int buttonCounter = 1; // D��melerin numaraland�rmas� i�in saya�
        private Random rnd = new Random(); // Rastgele renk i�in

        public Form1()
        {
            InitializeComponent();
            this.Text = "MouseClick ile Renkli D��meler";
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

            // D��meye numara yaz�yoruz
            btn.Text = buttonCounter.ToString();
            buttonCounter++;

            // Rastgele arka plan rengi veriyoruz
            btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            // Yaz� rengini kontrast olacak �ekilde beyaz yap�yoruz
            btn.ForeColor = Color.White;

            // Click olay�n� i�liyoruz: t�klan�nca d��meyi kald�racak
            btn.Click += Btn_Click;

            // D��meyi formun Controls koleksiyonuna ekliyoruz
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // T�klanan d��meyi al�yoruz
            Button btn = sender as Button;

            if (btn != null)
            {
                // D��meyi formdan kald�r�p bellekten temizliyoruz
                btn.Dispose();
            }
        }
    }
}
