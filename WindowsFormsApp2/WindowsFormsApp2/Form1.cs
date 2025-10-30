using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private List<Button> buttons = new List<Button>();
        private int buttonCount = 10; // Toplam düğme sayısı
        private Random rnd = new Random(); // Rastgele renk için

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Tüm düğmeleri oluştur
            for (int i = 1; i <= buttonCount; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(100, 100);
                btn.Location = new Point(350, 150); // Aynı koordinat
                btn.Text = i.ToString();
                btn.Click += Button_Click;

                // Rastgele renk ata
                btn.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                btn.ForeColor = Color.White; // Yazı rengi beyaz

                buttons.Add(btn);
                this.Controls.Add(btn);
            }

            // Başlangıçta en üstteki düğme 10 olacak şekilde sırala
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].BringToFront();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button topButton = sender as Button;

            if (topButton != null)
            {
                // En üste tıklanılan düğme en alta geçsin
                topButton.SendToBack();
            }
        }
    }
}
