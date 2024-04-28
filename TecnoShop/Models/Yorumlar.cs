using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class Yorumlar
    {
        public int YorumId { get; set; }
        public int UrunId { get; set; }
        public string Yorum { get; set; } = null!;
        public int MusteriId { get; set; }

        public virtual MusteriKayit Musteri { get; set; } = null!;
        public virtual UrunBilgi Urun { get; set; } = null!;
    }
}
