using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class Sepet
    {
        public int SepetNo { get; set; }
        public int MusteriId { get; set; }
        public int UrunId { get; set; }
        public int UurnAdet { get; set; }
        public decimal UrunFiyat { get; set; }

        public virtual MusteriKayit Musteri { get; set; } = null!;
        public virtual UrunBilgi Urun { get; set; } = null!;
    }
}
