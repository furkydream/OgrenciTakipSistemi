using System.Text.Json;

namespace OgrenciTakipSistemi
{
    public class OgrenciManager
    {
        private string dosyaYolu = @"C:\Users\ASUS\Desktop\ogrenciler.json";
        public List<Ogrenci> Ogrenciler { get; private set; }

        public OgrenciManager()
        {
            if (File.Exists(dosyaYolu))
            {
                string json = File.ReadAllText(dosyaYolu);
                Ogrenciler = JsonSerializer.Deserialize<List<Ogrenci>>(json) ?? new List<Ogrenci>();
            }
            else
            {
                Ogrenciler = new List<Ogrenci>();
            }
        }

        public void Kaydet()
        {
            string json = JsonSerializer.Serialize(Ogrenciler, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dosyaYolu, json);
        }

        public void Ekle(Ogrenci ogrenci)
        {
            Ogrenciler.Add(ogrenci);
            Kaydet();
        }

        public void Sil(int index)
        {
            Ogrenciler.RemoveAt(index);
            Kaydet();
        }

        public void Guncelle(int index, Ogrenci ogrenci)
        {
            Ogrenciler[index] = ogrenci;
            Kaydet();
        }
    }
}
