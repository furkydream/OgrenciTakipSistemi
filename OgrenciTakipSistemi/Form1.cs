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
                "M�hendislik", "�ktisadi �dari Bilimler", "Fen Edebiyat", "T�p",
                "E�itim", "Hukuk", "G�zel Sanatlar", "Spor Bilimleri",
                "�leti�im", "Tar�m"
            });

            cmbProgram.Items.AddRange(new string[]
            {
                "Lisans", "Y�ksek Lisans", "Doktora", "�nlisans", "Sertifika Program�",
                "Uzaktan E�itim", "K�sa D�nem", "Uzun D�nem", "Yaz Okulu",
                "K�� Okulu", "Yaz Staj�", "K�� Staj�"
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
                MessageBox.Show("L�tfen t�m alanlar� doldurunuz.");
                return;
            }

            if (!int.TryParse(txtNo.Text, out int numara))
            {
                MessageBox.Show("Numara sadece rakamlardan olu�mal�d�r.");
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
                MessageBox.Show("L�tfen silinecek bir ��renci se�iniz.");
            }
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
                MessageBox.Show("L�tfen g�ncellenecek bir ��renci se�iniz.");
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
