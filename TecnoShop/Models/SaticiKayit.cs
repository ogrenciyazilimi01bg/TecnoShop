using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class SaticiKayit
    {
        public SaticiKayit()
        {
            UrunBilgis = new HashSet<UrunBilgi>();
        }

        public int SaticiId { get; set; }
        public string SaticiAd { get; set; } = null!;
        public string SaticiTelefon { get; set; } = null!;
        public string SirketAd { get; set; } = null!;
        public string SirketAdresi { get; set; } = null!;
        public string MailAdresi { get; set; } = null!;
        public string KullaniciAdi { get; set; } = null!;
        public string Sifre { get; set; } = null!;

        public virtual ICollection<UrunBilgi> UrunBilgis { get; set; }
    }
}
