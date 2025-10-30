using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ödev32
{
    public partial class Form1 : Form
    {
        // 5x5 oyun tahtası; 0 boşluk demek. Diğerleri 1..24
        private int[,] board = new int[5, 5];
        // Taş numarasından butona erişmek için
        private Dictionary<int, Button> buttons = new Dictionary<int, Button>();
        // Boşluğun konumu
        private int emptyRow = 4, emptyCol = 4;

        private readonly int ROWS = 5;
        private readonly int COLS = 5;

        public Form1()
        {
            InitializeComponent();

            // Pencere boyutlandırılabilir olacak
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MinimumSize = new Size(420, 440); // Çok küçülmeyi engelle
            this.DoubleBuffered = true;

            // Başlangıç boyutu (keyfi, grid yine uyum sağlar)
            this.ClientSize = new Size(600, 600);

            // Yeniden boyutlanınca butonları yeniden konumlandır
            this.Resize += (s, e) => LayoutButtons();

            InitBoard();
            CreateButtons();
            ShuffleByLegalMoves(200); // çözülebilir karışım
            LayoutButtons();
        }

        // 1..24 sırayla diz, son hücre boş (0)
        private void InitBoard()
        {
            int n = 1;
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (r == ROWS - 1 && c == COLS - 1)
                        board[r, c] = 0; // boşluk
                    else
                        board[r, c] = n++;
                }
            }
            emptyRow = ROWS - 1;
            emptyCol = COLS - 1;
        }

        // 1..24 için butonları bir kez oluştur (metin ve click olayı)
        private void CreateButtons()
        {
            for (int val = 1; val <= 24; val++)
            {
                var btn = new Button();
                btn.Text = val.ToString();
                btn.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                btn.Tag = val; // hangi taş olduğu
                btn.Click += Tile_Click;

                // Temel görünüm
                btn.FlatStyle = FlatStyle.Standard;

                buttons[val] = btn;
                this.Controls.Add(btn);
            }
        }

        // Geçerli hamlelerle rastgele karıştır (her adımda boşluğun komşusu bir taşı boşluğa sür)
        private void ShuffleByLegalMoves(int steps)
        {
            var rnd = new Random();
            for (int i = 0; i < steps; i++)
            {
                var neighbors = GetNeighborsOfEmpty();
                var pick = neighbors[rnd.Next(neighbors.Count)];
                // pick: (r,c) konumundaki taşı boşluğa kaydır
                MoveIfNeighbor(pick.r, pick.c);
            }
        }

        // Boşluğun (up,down,left,right) komşuları
        private List<(int r, int c)> GetNeighborsOfEmpty()
        {
            var list = new List<(int r, int c)>();
            if (emptyRow > 0) list.Add((emptyRow - 1, emptyCol));
            if (emptyRow < ROWS - 1) list.Add((emptyRow + 1, emptyCol));
            if (emptyCol > 0) list.Add((emptyRow, emptyCol - 1));
            if (emptyCol < COLS - 1) list.Add((emptyRow, emptyCol + 1));
            return list;
        }

        // Bir taşa tıklandığında: boşluğun komşusuysa onu boşluğa kaydır
        private void Tile_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int val = (int)btn.Tag;

            // Taşın board üzerindeki konumunu bul
            int tr = -1, tc = -1;
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (board[r, c] == val)
                    {
                        tr = r; tc = c; break;
                    }
                }
                if (tr != -1) break;
            }

            // Komşuysa hareket ettir
            if (IsNeighborOfEmpty(tr, tc))
            {
                MoveIfNeighbor(tr, tc);
                LayoutButtons();

                if (IsSolved())
                {
                    // Küçük bir ödül :)
                    this.Text = "Tebrikler! Çözüldü 🎉";
                }
            }
        }

        private bool IsNeighborOfEmpty(int r, int c)
        {
            return (Math.Abs(r - emptyRow) == 1 && c == emptyCol) ||
                   (Math.Abs(c - emptyCol) == 1 && r == emptyRow);
        }

        // (r,c) taşını boşluğa sür (komşu olduğundan emin olarak)
        private void MoveIfNeighbor(int r, int c)
        {
            if (!IsNeighborOfEmpty(r, c)) return;

            // Taş değeri
            int val = board[r, c];

            // Taşı boşluğa koy
            board[emptyRow, emptyCol] = val;
            board[r, c] = 0;

            // Yeni boşluk
            emptyRow = r;
            emptyCol = c;
        }

        // Pencere boyutuna göre tüm butonların boyut/konumunu hesapla
        private void LayoutButtons()
        {
            // İç alan boyutları
            int W = this.ClientSize.Width;
            int H = this.ClientSize.Height;

            // Hücre boyutları (artık kare zorunlu değil!)
            // Aralara biraz boşluk ekleyelim (hücre başına %2 pay gibi)
            float gapRatio = 0.04f; // toplamda satır/sütunda ~4 aralık var; ufak pay yeterli
            float cellW = (float)W / COLS;
            float cellH = (float)H / ROWS;

            // Her hücre içinde küçük bir padding (görüntü daha ferah)
            int padX = (int)(cellW * gapRatio);
            int padY = (int)(cellH * gapRatio);

            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    int val = board[r, c];
                    if (val == 0) continue; // boşluk için buton yok

                    var btn = buttons[val];

                    // Hücrenin sol üst köşesi
                    int x = (int)(c * cellW) + padX;
                    int y = (int)(r * cellH) + padY;

                    // Butonun boyutu (hücreden paddingleri düş)
                    int bw = (int)(cellW - 2 * padX);
                    int bh = (int)(cellH - 2 * padY);

                    if (bw < 10) bw = 10; // aşırı küçülmeye karşı güvenlik
                    if (bh < 10) bh = 10;

                    btn.SetBounds(x, y, bw, bh);
                }
            }
        }

        // Çözülmüş mü? 1..24 sırayla ve boşluk sağ altta mı?
        private bool IsSolved()
        {
            int expected = 1;
            for (int r = 0; r < ROWS; r++)
            {
                for (int c = 0; c < COLS; c++)
                {
                    if (r == ROWS - 1 && c == COLS - 1)
                    {
                        return board[r, c] == 0; // son hücre boş olmalı
                    }

                    if (board[r, c] != expected) return false;
                    expected++;
                }
            }
            // Normalde buraya gelmez
            return true;
        }
    }
}
