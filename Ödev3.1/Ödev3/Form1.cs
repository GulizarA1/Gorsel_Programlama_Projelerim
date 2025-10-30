using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ödev3
{
    public partial class Form1 : Form
    {
        private Button[,] buttons = new Button[5, 5]; // 5x5 matris
        private int emptyRow = 4, emptyCol = 4; // Başlangıçta boş alan sağ alt köşe
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Boyutlandırmayı kapat
            this.MaximizeBox = false;

            // Formun iç boyutunu 5x5 düğmeye göre ayarla (her düğme 80x80)
            this.ClientSize = new Size(5 * 80, 5 * 80);

            CreateButtons();
        }

        /*public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // Boyutlandırmayı kapat
            this.MaximizeBox = false;
            CreateButtons();
        }
        */
        private void CreateButtons()
        {
            int number = 1;

            // Önce sırayla yerleştir
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (row == 4 && col == 4) continue; // Boş alan

                    Button btn = new Button();
                    btn.Size = new Size(80, 80);
                    btn.Location = new Point(col * 80, row * 80);
                    btn.Text = number.ToString();
                    btn.Font = new Font("Arial", 16, FontStyle.Bold);
                    btn.Click += Button_Click;

                    buttons[row, col] = btn;
                    this.Controls.Add(btn);

                    number++;
                }
            }

            // Başlangıçta rastgele diz
            ShuffleButtons();
        }

        private void ShuffleButtons()
        {
            for (int i = 0; i < 100; i++) // 100 defa rastgele takas
            {
                int r1 = rnd.Next(5);
                int c1 = rnd.Next(5);
                int r2 = rnd.Next(5);
                int c2 = rnd.Next(5);

                if ((r1 == emptyRow && c1 == emptyCol) || (r2 == emptyRow && c2 == emptyCol))
                    continue;

                SwapButtons(r1, c1, r2, c2);
            }
        }

        private void SwapButtons(int r1, int c1, int r2, int c2)
        {
            string tempText = buttons[r1, c1].Text;
            buttons[r1, c1].Text = buttons[r2, c2].Text;
            buttons[r2, c2].Text = tempText;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;

            // Tıklanan düğmeyi bul
            int row = -1, col = -1;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (buttons[r, c] == clicked)
                    {
                        row = r;
                        col = c;
                        break;
                    }
                }
            }

            // Boş alan komşu mu kontrol et
            if ((Math.Abs(row - emptyRow) == 1 && col == emptyCol) ||
                (Math.Abs(col - emptyCol) == 1 && row == emptyRow))
            {
                // Konum değiştir
                clicked.Location = new Point(emptyCol * 80, emptyRow * 80);
                buttons[emptyRow, emptyCol] = clicked;
                buttons[row, col] = null;

                emptyRow = row;
                emptyCol = col;
            }
        }
    }
}
