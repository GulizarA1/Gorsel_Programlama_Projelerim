using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace ÖdevSon
{
    public partial class Form1 : Form
    {
        TextBox txtAd, txtSoyad, txtBoy, txtKilo;
        ListBox lbGun, lbAy, lbYil;
        Button btnHesapla;
        Label lblSonuc;
        PictureBox pbBurc;

        public Form1()
        {
            InitializeComponent(); // Designer tarafından üretilen bileşenleri yükler
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form
            this.Text = "BURÇ HESAPLAMA";
            this.ClientSize = new Size(720, 420);
            this.StartPosition = FormStartPosition.CenterScreen;

            // --- Etiketler ---
            var lblAd = new Label() { Text = "Adı:", Left = 20, Top = 20, AutoSize = true };
            var lblSoyAd = new Label() { Text = "Soyadı:", Left = 20, Top = 60, AutoSize = true };
            var lblBoy = new Label() { Text = "Boy (metre):", Left = 20, Top = 100, AutoSize = true };
            var lblKilo = new Label() { Text = "Kilo (kg):", Left = 20, Top = 140, AutoSize = true };
            var lblGun = new Label() { Text = "Gün:", Left = 20, Top = 195, AutoSize = true };
            var lblAy = new Label() { Text = "Ay:", Left = 90, Top = 195, AutoSize = true };
            var lblYil = new Label() { Text = "Yıl:", Left = 160, Top = 195, AutoSize = true };

            this.Controls.Add(lblAd);
            this.Controls.Add(lblSoyAd);
            this.Controls.Add(lblBoy);
            this.Controls.Add(lblKilo);
            this.Controls.Add(lblGun);
            this.Controls.Add(lblAy);
            this.Controls.Add(lblYil);

            // --- Girişler ---
            txtAd = new TextBox() { Left = 120, Top = 18, Width = 120 };
            txtSoyad = new TextBox() { Left = 120, Top = 58, Width = 120 };
            txtBoy = new TextBox() { Left = 120, Top = 98, Width = 120, PlaceholderText = "Örn: 1,70" };
            txtKilo = new TextBox() { Left = 120, Top = 138, Width = 120, PlaceholderText = "Örn: 62" };

            this.Controls.Add(txtAd);
            this.Controls.Add(txtSoyad);
            this.Controls.Add(txtBoy);
            this.Controls.Add(txtKilo);

            // --- ListBox'lar ---
            lbGun = new ListBox() { Left = 20, Top = 220, Width = 50, Height = 120 };
            lbAy = new ListBox() { Left = 90, Top = 220, Width = 50, Height = 120 };
            lbYil = new ListBox() { Left = 160, Top = 220, Width = 80, Height = 120 };

            for (int i = 1; i <= 31; i++) lbGun.Items.Add(i);
            for (int i = 1; i <= 12; i++) lbAy.Items.Add(i);
            int yilNow = DateTime.Now.Year;
            for (int y = 1950; y <= yilNow; y++) lbYil.Items.Add(y);

            this.Controls.Add(lbGun);
            this.Controls.Add(lbAy);
            this.Controls.Add(lbYil);

            // --- Buton ---
            btnHesapla = new Button() { Text = "Hesapla", Left = 20, Top = 360, Width = 220, Height = 32 };
            btnHesapla.Click += BtnHesapla_Click;
            this.Controls.Add(btnHesapla);

            // --- Sonuç Label ---
            lblSonuc = new Label()
            {
                Left = 280,
                Top = 20,
                Width = 400,
                Height = 160,
                AutoSize = false,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 12, FontStyle.Bold)
            };
            this.Controls.Add(lblSonuc);

            // --- PictureBox (Burç resmi) ---
            pbBurc = new PictureBox()
            {
                Left = 280,
                Top = 200,
                Width = 400,
                Height = 200,
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.Zoom
            };
            this.Controls.Add(pbBurc);
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {
            // 1) Ad soyad
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtSoyad.Text))
            {
                MessageBox.Show("Ad ve Soyadı gir.");
                txtAd.Focus();
                return;
            }

            // 2) Tarih seçimleri
            if (lbGun.SelectedItem == null || lbAy.SelectedItem == null || lbYil.SelectedItem == null)
            {
                MessageBox.Show("Gün, Ay ve Yıl seç.");
                return;
            }

            int gun = (int)lbGun.SelectedItem;
            int ay = (int)lbAy.SelectedItem;
            int yil = (int)lbYil.SelectedItem;

            // 3) Geçerli tarih mi?
            DateTime dogum;
            try
            {
                dogum = new DateTime(yil, ay, gun);
            }
            catch
            {
                MessageBox.Show("Geçersiz tarih. Lütfen doğru bir gün/ay/yıl seç.");
                return;
            }

            // 4) Boy & Kilo
            if (!TryParseDoubleTr(txtBoy.Text, out double boy) || boy <= 0)
            {
                MessageBox.Show("Boyu metre cinsinden gir (örn: 1,70).");
                txtBoy.Focus();
                return;
            }

            if (!TryParseDoubleTr(txtKilo.Text, out double kilo) || kilo <= 0)
            {
                MessageBox.Show("Kiloyu kg cinsinden gir (örn: 62).");
                txtKilo.Focus();
                return;
            }

            // 5) BMI
            double bmi = kilo / (boy * boy);

            // 6) Burç
            string burc = BurcHesapla(gun, ay);

            // 7) Sonuç yaz
            lblSonuc.Text =
                $"Ad Soyad: {txtAd.Text} {txtSoyad.Text}\r\n" +
                $"Doğum Tarihi: {dogum:dd.MM.yyyy}\r\n" +
                $"Vücut Kitle İndeksi (BMI): {bmi:F1}\r\n" +
                $"Burç: {burc}";

            // 8) Burç resmi (varsa göster)
            YukleBurcResmi(burc);
        }

        // Türkçe girişte hem virgül hem nokta desteklemek için
        private bool TryParseDoubleTr(string s, out double value)
        {
            s = (s ?? "").Trim().Replace(',', '.');
            return double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out value);
        }

        private string BurcHesapla(int gun, int ay)
        {
            if ((ay == 3 && gun >= 21) || (ay == 4 && gun <= 20)) return "Koç";
            if ((ay == 4 && gun >= 21) || (ay == 5 && gun <= 21)) return "Boğa";
            if ((ay == 5 && gun >= 22) || (ay == 6 && gun <= 21)) return "İkizler";
            if ((ay == 6 && gun >= 22) || (ay == 7 && gun <= 22)) return "Yengeç";
            if ((ay == 7 && gun >= 23) || (ay == 8 && gun <= 23)) return "Aslan";
            if ((ay == 8 && gun >= 24) || (ay == 9 && gun <= 23)) return "Başak";
            if ((ay == 9 && gun >= 24) || (ay == 10 && gun <= 23)) return "Terazi";
            if ((ay == 10 && gun >= 24) || (ay == 11 && gun <= 22)) return "Akrep";
            if ((ay == 11 && gun >= 23) || (ay == 12 && gun <= 21)) return "Yay";
            if ((ay == 12 && gun >= 22) || (ay == 1 && gun <= 20)) return "Oğlak";
            if ((ay == 1 && gun >= 21) || (ay == 2 && gun <= 19)) return "Kova";
            if ((ay == 2 && gun >= 20) || (ay == 3 && gun <= 20)) return "Balık";
            return "Bilinmiyor";
        }

        private void YukleBurcResmi(string burc)
        {
            try
            {
                string klasor = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "burclar");
                string dosya = Path.Combine(klasor, $"{burc}.jpg");

                if (File.Exists(dosya))
                {
                    if (pbBurc.Image != null)
                    {
                        var eski = pbBurc.Image;
                        pbBurc.Image = null;
                        eski.Dispose();
                    }
                    pbBurc.Image = Image.FromFile(dosya);
                }
                else
                {
                    pbBurc.Image = null;
                }
            }
            catch
            {
                pbBurc.Image = null;
            }
        }
    }
}
