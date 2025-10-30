using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public partial class Form1 : Form
    {
        // MouseDown anında kaydedeceğimiz başlangıç noktası
        private Point? _startPoint = null;

        // İsteğe bağlı: oluşturulan butonları numaralandırmak istersen
        private int _buttonCounter = 1;

        public Form1()
        {
            InitializeComponent();
            Text = "MouseDown → MouseUp: Buton Çiz";
            Width = 900;
            Height = 600;

            // Form olayları
            this.MouseDown += Form1_MouseDown;
            this.MouseUp += Form1_MouseUp;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            // Sadece sol tuşu dikkate alalım (ödev mantığı gereği)
            if (e.Button == MouseButtons.Left)
            {
                _startPoint = e.Location; // Eski (başlangıç) konum
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (_startPoint == null) return; // Güvenlik

            // Yeni (bırakma) konumu
            Point end = e.Location;
            Point start = _startPoint.Value;

            // Ödev tanımı: "Sol üst köşe eski, sağ alt köşe yeni"
            // Bu nedenle kullanıcının sağ-alt yöne sürüklediğini varsayıyoruz.
            int width = end.X - start.X;
            int height = end.Y - start.Y;

            // Eğer kullanıcı sola/üste doğru sürüklediyse,
            // ödev tanımına uymuyor demektir. Uyarı verip buton oluşturmuyoruz.
            if (width <= 0 || height <= 0)
            {
                // İsterseniz sessizce görmezden de gelebilirsiniz.
                MessageBox.Show("Lütfen fareyi sol üstten sağ alta doğru sürükleyin.",
                                "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _startPoint = null;
                return;
            }

            // Butonu oluştur
            Button btn = new Button();
            btn.Location = start;                 // Sol-üst köşe: eski yer
            btn.Size = new Size(width, height);   // Sağ-alt köşe: yeni yer
            btn.Text = _buttonCounter.ToString(); // İsteğe bağlı numara
            _buttonCounter++;

            // Görsel küçük dokunuşlar (opsiyonel)
            btn.BackColor = Color.LightSteelBlue;
            btn.ForeColor = Color.Black;

            // Tıklanınca butonu kaldır (ödevde istenmese de pratik olur)
            btn.Click += Btn_Click;

            // Forma ekle
            this.Controls.Add(btn);

            // Sıradaki çizim için başlangıcı sıfırla
            _startPoint = null;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
                btn.Dispose();
        }
    }
}
