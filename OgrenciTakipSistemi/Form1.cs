using System;
using System.Windows.Forms;

namespace OgrenciTakipSistemi
{
    public partial class Form1 : Form
    {
        OgrenciManager ogrenciManager = new OgrenciManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciManager.Ogrenciler;

            cmbFakulte.Items.AddRange(new string[]
            {
                "Mühendislik", "Ýktisadi Ýdari Bilimler", "Fen Edebiyat", "Týp",
                "Eðitim", "Hukuk", "Güzel Sanatlar", "Spor Bilimleri",
                "Ýletiþim", "Tarým"
            });

            cmbProgram.Items.AddRange(new string[]
            {
                "Lisans", "Yüksek Lisans", "Doktora", "Önlisans", "Sertifika Programý",
                "Uzaktan Eðitim", "Kýsa Dönem", "Uzun Dönem", "Yaz Okulu",
                "Kýþ Okulu", "Yaz Stajý", "Kýþ Stajý"
            });
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text) ||
                string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtNo.Text) ||
                cmbFakulte.SelectedItem == null ||
                cmbProgram.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurunuz.");
                return;
            }

            if (!int.TryParse(txtNo.Text, out int numara))
            {
                MessageBox.Show("Numara sadece rakamlardan oluþmalýdýr.");
                return;
            }

            Ogrenci yeni = new Ogrenci
            {
                Ad = txtAd.Text,
                Soyad = txtSoyad.Text,
                Numara = numara,
                Fakulte = cmbFakulte.Text,
                Program = cmbProgram.Text
            };

            ogrenciManager.Ekle(yeni);
            FormuTemizle();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ogrenciManager.Ogrenciler;
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.Index >= 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                ogrenciManager.Sil(index);
                FormuTemizle();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciManager.Ogrenciler;
            }
            else
            {
                MessageBox.Show("Lütfen silinecek bir öðrenci seçiniz.");
            }
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

                Ogrenci guncel = new Ogrenci
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    Numara = numara,
                    Fakulte = cmbFakulte.Text,
                    Program = cmbProgram.Text
                };

                ogrenciManager.Guncelle(index, guncel);
                FormuTemizle();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = ogrenciManager.Ogrenciler;
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir öðrenci seçiniz.");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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
    }
}
