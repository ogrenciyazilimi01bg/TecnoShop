using System;
using System.Collections.Generic;

namespace TecnoShop.Models
{
    public partial class MusteriKayit
    {
        public MusteriKayit()
        {
            OdemeBilgisis = new HashSet<OdemeBilgisi>();
            Sepets = new HashSet<Sepet>();
            SiparisBilgileris = new HashSet<SiparisBilgileri>();
            Yorumlars = new HashSet<Yorumlar>();
        }

        public int MusteriId { get; set; }
        public string MusteriAd { get; set; } = null!;
        public int Yas { get; set; }
        public string MusteriTelefon { get; set; } = null!;
        public string MusteriMailAdresi { get; set; } = null!;
        public string Sehir { get; set; } = null!;
        public string KullaniciAdi { get; set; } = null!;
        public string Sifre { get; set; } = null!;

        public virtual ICollection<OdemeBilgisi> OdemeBilgisis { get; set; }
        public virtual ICollection<Sepet> Sepets { get; set; }
        public virtual ICollection<SiparisBilgileri> SiparisBilgileris { get; set; }
        public virtual ICollection<Yorumlar> Yorumlars { get; set; }
    }
}
