using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class UrunBilgi
    {
        public UrunBilgi()
        {
            Sepets = new HashSet<Sepet>();
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int UrunBilgiId { get; set; }
        public string UrunKodu { get; set; } = null!;
        public string Kategori { get; set; } = null!;
        public string Markası { get; set; } = null!;
        public decimal Fiyat { get; set; }
        public int SaticiId { get; set; }
        public int Stok { get; set; }
        public int GarantiSuresi { get; set; }
        public string AcıklamaDetay { get; set; } = null!;
        public string KargoBilgisi { get; set; } = null!;
        public string TeknikOzellikler { get; set; } = null!;
        public string IadeBilgisi { get; set; } = null!;
        public DateTime Eklenentarih { get; set; }
        public byte[] Resim { get; set; } = null!;

        public virtual SaticiKayit Satici { get; set; } = null!;
        public virtual ICollection<Sepet> Sepets { get; set; }
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
