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
                MessageBox.Show("L�tfen fak�lte ve program se�iniz.");
                return;
            }
            Ogrenci yeniOgrenci = new Ogrenci();
            {
                yeniOgrenci.Ad = txtAd.Text;
                yeniOgrenci.Soyad = txtSoyad.Text;
                if (!int.TryParse(txtNo.Text, out int numara))
                {
                    MessageBox.Show("Numara sadece rakamlardan olu�mal�d�r.");
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
                MessageBox.Show("L�tfen silmek istedi�iniz kullan�c�y� se�iniz.");
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
                    MessageBox.Show("Numara sadece rakamlardan olu�mal�d�r.");
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
                MessageBox.Show("L�tfen g�ncellenecek bir ��renci se�iniz.");
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
            cmbFakulte.Items.Add("M�hendislik");
            cmbFakulte.Items.Add("�ktisadi �dari Bilimler");
            cmbFakulte.Items.Add("Fen Edebiyat");
            cmbFakulte.Items.Add("T�p");
            cmbFakulte.Items.Add("E�itim");
            cmbFakulte.Items.Add("Hukuk");
            cmbFakulte.Items.Add("G�zel Sanatlar");
            cmbFakulte.Items.Add("Spor Bilimleri");
            cmbFakulte.Items.Add("�leti�im");
            cmbFakulte.Items.Add("Tar�m");

            cmbProgram.Items.Add("Lisans");
            cmbProgram.Items.Add("Y�ksek Lisans");
            cmbProgram.Items.Add("Doktora");
            cmbProgram.Items.Add("�nlisans");
            cmbProgram.Items.Add("Sertifika Program�");
            cmbProgram.Items.Add("Uzaktan E�itim");
            cmbProgram.Items.Add("K�sa D�nem");
            cmbProgram.Items.Add("Uzun D�nem");
            cmbProgram.Items.Add("Yaz Okulu");
            cmbProgram.Items.Add("K�� Okulu");
            cmbProgram.Items.Add("Yaz Staj�");
            cmbProgram.Items.Add("K�� Staj�");
        }
    }
}
