using System.Text.Json;
using System.IO;
namespace OgrenciTakipSistemi
{
    public partial class Form1 : Form
    {
       // string dosyaYolu = "ogrenciler.json";
        string dosyaYolu = @"C:\Users\ASUS\Desktop\ogrenciler.json";

        public Form1()
        {
            InitializeComponent();

        }
        private void VerileriKaydet()
        {
            string json = JsonSerializer.Serialize(ogrenciListesi, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dosyaYolu, json);
        }

        List<Ogrenci> ogrenciListesi = new List<Ogrenci>();

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text) ||
                string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtNo.Text) ||
                cmbFakulte.SelectedItem == null ||
                cmbProgram.SelectedItem == null)
            {
                MessageBox.Show("Lütfen fakülte ve program seçiniz.");
                return;
            }
            Ogrenci yeniOgrenci = new Ogrenci();
            {
                yeniOgrenci.Ad = txtAd.Text;
                yeniOgrenci.Soyad = txtSoyad.Text;
                if (!int.TryParse(txtNo.Text, out int numara))
                {
                    MessageBox.Show("Numara sadece rakamlardan oluþmalýdýr.");
                    return;
                }
                yeniOgrenci.Numara = numara;
                yeniOgrenci.Fakulte = cmbFakulte.Text;
                yeniOgrenci.Program = cmbProgram.Text;
            }
            txtAd.Clear();
            txtSoyad.Clear();
            txtNo.Clear();
            cmbFakulte.SelectedItem = null;
            cmbProgram.SelectedItem = null;

            ogrenciListesi.Add(yeniOgrenci);
            VerileriKaydet();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciListesi;




        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                int seciliIndex = dataGridView1.CurrentRow.Index;

                ogrenciListesi.RemoveAt(seciliIndex);

                txtAd.Clear();
                txtSoyad.Clear();
                txtNo.Clear();
                cmbFakulte.SelectedItem = null;
                cmbProgram.SelectedItem = null;

                VerileriKaydet();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciListesi;
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediðiniz kullanýcýyý seçiniz.");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells["Ad"].Value.ToString();
                txtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells["Soyad"].Value.ToString();
                txtNo.Text = dataGridView1.Rows[e.RowIndex].Cells["Numara"].Value.ToString();
                cmbFakulte.Text = dataGridView1.Rows[e.RowIndex].Cells["Fakulte"].Value.ToString();
                cmbProgram.Text = dataGridView1.Rows[e.RowIndex].Cells["Program"].Value.ToString();
            }
        }




        private void FormuTemizle()
        {
            txtAd.Clear();
            txtSoyad.Clear();
            txtNo.Clear();
            cmbFakulte.SelectedItem = null;
            cmbProgram.SelectedItem = null;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                int index = dataGridView1.CurrentRow.Index;

                if (!int.TryParse(txtNo.Text, out int numara))
                {
                    MessageBox.Show("Numara sadece rakamlardan oluþmalýdýr.");
                    return;
                }

                ogrenciListesi[index].Ad = txtAd.Text;
                ogrenciListesi[index].Soyad = txtSoyad.Text;
                ogrenciListesi[index].Numara = numara;
                ogrenciListesi[index].Fakulte = cmbFakulte.Text;
                ogrenciListesi[index].Program = cmbProgram.Text;

                FormuTemizle();

                VerileriKaydet();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciListesi;
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir öðrenci seçiniz.");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(dosyaYolu))
            {
                string json = File.ReadAllText(dosyaYolu);
                ogrenciListesi = JsonSerializer.Deserialize<List<Ogrenci>>(json) ?? new List<Ogrenci>();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciListesi;
            }
            cmbFakulte.Items.Add("Mühendislik");
            cmbFakulte.Items.Add("Ýktisadi Ýdari Bilimler");
            cmbFakulte.Items.Add("Fen Edebiyat");
            cmbFakulte.Items.Add("Týp");
            cmbFakulte.Items.Add("Eðitim");
            cmbFakulte.Items.Add("Hukuk");
            cmbFakulte.Items.Add("Güzel Sanatlar");
            cmbFakulte.Items.Add("Spor Bilimleri");
            cmbFakulte.Items.Add("Ýletiþim");
            cmbFakulte.Items.Add("Tarým");

            cmbProgram.Items.Add("Lisans");
            cmbProgram.Items.Add("Yüksek Lisans");
            cmbProgram.Items.Add("Doktora");
            cmbProgram.Items.Add("Önlisans");
            cmbProgram.Items.Add("Sertifika Programý");
            cmbProgram.Items.Add("Uzaktan Eðitim");
            cmbProgram.Items.Add("Kýsa Dönem");
            cmbProgram.Items.Add("Uzun Dönem");
            cmbProgram.Items.Add("Yaz Okulu");
            cmbProgram.Items.Add("Kýþ Okulu");
            cmbProgram.Items.Add("Yaz Stajý");
            cmbProgram.Items.Add("Kýþ Stajý");
        }
    }
}
