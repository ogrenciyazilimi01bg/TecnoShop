using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class OdemeBilgisi
    {
        public int OdemeId { get; set; }
        public int MusteriId { get; set; }
        public string KartSahibi { get; set; } = null!;
        public string KartNo { get; set; } = null!;
        public int Cvv { get; set; }
        public DateTime SonKullanimTarihi { get; set; }
        public string ToplamFiyat { get; set; } = null!;

        public virtual MusteriKayit Musteri { get; set; } = null!;
    }
}
