using System;
using System.Windows.Forms;

namespace OdevBasit
{
    public class Form1 : Form
    {
        ComboBox cmbIl, cmbIlce;
        TextBox txtAdSoyad;
        Button btnEkle;
        ListBox listBox;
        RadioButton rbErkek, rbKadin;
        CheckBox cbOnay;
        Label lblDurum;

        public Form1()
        {
            // Form özellikleri
            this.Text = "Basit Ödev Formu";
            this.Width = 400;
            this.Height = 400;

            // Ad Soyad
            Label lblAd = new Label();
            lblAd.Text = "Ad Soyad:";
            lblAd.Top = 20; lblAd.Left = 20;
            this.Controls.Add(lblAd);

            txtAdSoyad = new TextBox();
            txtAdSoyad.Top = 40; txtAdSoyad.Left = 20; txtAdSoyad.Width = 150;
            this.Controls.Add(txtAdSoyad);

            // İl
            Label lblIl = new Label();
            lblIl.Text = "İl:";
            lblIl.Top = 70; lblIl.Left = 20;
            this.Controls.Add(lblIl);

            cmbIl = new ComboBox();
            cmbIl.Top = 90; cmbIl.Left = 20;
            cmbIl.Width = 100;
            cmbIl.Items.AddRange(new string[]
            { "İstanbul","Ankara","İzmir","Bursa","Antalya","Konya","Adana","Gaziantep","Samsun","Trabzon"});
            cmbIl.SelectedIndexChanged += CmbIl_SelectedIndexChanged;
            this.Controls.Add(cmbIl);

            // İlçe
            Label lblIlce = new Label();
            lblIlce.Text = "İlçe:";
            lblIlce.Top = 70; lblIlce.Left = 140;
            this.Controls.Add(lblIlce);

            cmbIlce = new ComboBox();
            cmbIlce.Top = 90; cmbIlce.Left = 140;
            cmbIlce.Width = 100;
            this.Controls.Add(cmbIlce);

            // Cinsiyet
            rbErkek = new RadioButton();
            rbErkek.Text = "Erkek"; rbErkek.Top = 130; rbErkek.Left = 20;
            this.Controls.Add(rbErkek);

            rbKadin = new RadioButton();
            rbKadin.Text = "Kadın"; rbKadin.Top = 130; rbKadin.Left = 100;
            this.Controls.Add(rbKadin);

            // Onay
            cbOnay = new CheckBox();
            cbOnay.Text = "Onaylıyorum"; cbOnay.Top = 160; cbOnay.Left = 20;
            this.Controls.Add(cbOnay);

            // Liste
            listBox = new ListBox();
            listBox.Top = 190; listBox.Left = 20; listBox.Width = 220; listBox.Height = 100;
            this.Controls.Add(listBox);

            // Buton
            btnEkle = new Button();
            btnEkle.Text = "Listeye Ekle";
            btnEkle.Top = 300; btnEkle.Left = 20;
            btnEkle.Click += BtnEkle_Click;
            this.Controls.Add(btnEkle);

            // Durum Label
            lblDurum = new Label();
            lblDurum.Text = "Durum: Bekleniyor"; lblDurum.Top = 330; lblDurum.Left = 20;
            this.Controls.Add(lblDurum);
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Items.Clear();
            if (cmbIl.SelectedItem.ToString() == "İstanbul")
                cmbIlce.Items.AddRange(new string[] { "Kadıköy", "Beşiktaş", "Üsküdar", "Şişli", "Bakırköy", "Sarıyer", "Pendik", "Kartal", "Beykoz", "Fatih" });
            else if (cmbIl.SelectedItem.ToString() == "Ankara")
                cmbIlce.Items.AddRange(new string[] { "Çankaya", "Keçiören", "Yenimahalle", "Mamak", "Etimesgut", "Sincan", "Altındağ", "Polatlı", "Kızılay", "Batıkent" });
            else
                cmbIlce.Items.AddRange(new string[] { "Merkez1", "Merkez2", "Merkez3", "Merkez4", "Merkez5", "Merkez6", "Merkez7", "Merkez8", "Merkez9", "Merkez10" });
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            if (txtAdSoyad.Text == "" || cmbIl.SelectedItem == null || cmbIlce.SelectedItem == null || (!rbErkek.Checked && !rbKadin.Checked) || !cbOnay.Checked)
            {
                MessageBox.Show("Tüm alanları doldurun ve onaylayın!");
                return;
            }

            string cinsiyet = rbErkek.Checked ? "Erkek" : "Kadın";
            string adSoyad = txtAdSoyad.Text.Trim();
            string bilgi = adSoyad + " - " + cinsiyet + " - " + cmbIl.SelectedItem + "/" + cmbIlce.SelectedItem;
            listBox.Items.Add(bilgi);

            lblDurum.Text = "Durum: Listeye eklendi!";
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
