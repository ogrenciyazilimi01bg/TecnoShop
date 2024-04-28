using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class SiparisBilgileri
    {
        public int MusteriSiparisBilgileriId { get; set; }
        public int MusteriId { get; set; }
        public string Sehir { get; set; } = null!;
        public string EvAdresi { get; set; } = null!;

        public virtual MusteriKayit Musteri { get; set; } = null!;
    }
}
