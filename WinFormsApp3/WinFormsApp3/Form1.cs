using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3

{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            // Buraya form açýldýðýnda yapýlacak iþlemleri yazabilirsin
        }

        private int buttonCounter = 1; // Düðmelerin numaralandýrmasý için sayaç
        private Random rnd = new Random(); // Rastgele renk için

        public Form1()
        {
            InitializeComponent();
            this.Text = "MouseClick ile Renkli Düðmeler";
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

            // Düðmeye numara yazýyoruz
            btn.Text = buttonCounter.ToString();
            buttonCounter++;

            // Rastgele arka plan rengi veriyoruz
            btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

            // Yazý rengini kontrast olacak þekilde beyaz yapýyoruz
            btn.ForeColor = Color.White;

            // Click olayýný iþliyoruz: týklanýnca düðmeyi kaldýracak
            btn.Click += Btn_Click;

            // Düðmeyi formun Controls koleksiyonuna ekliyoruz
            this.Controls.Add(btn);
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            // Týklanan düðmeyi alýyoruz
            Button btn = sender as Button;

            if (btn != null)
            {
                // Düðmeyi formdan kaldýrýp bellekten temizliyoruz
                btn.Dispose();
            }
        }
    }
}
