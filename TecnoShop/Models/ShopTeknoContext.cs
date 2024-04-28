using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TecnoShop.Models
{
    public partial class ShopTeknoContext : DbContext
    {
        public ShopTeknoContext()
        {
        }

        public ShopTeknoContext(DbContextOptions<ShopTeknoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MusteriKayit> MusteriKayits { get; set; } = null!;
        public virtual DbSet<OdemeBilgisi> OdemeBilgisis { get; set; } = null!;
        public virtual DbSet<SaticiKayit> SaticiKayits { get; set; } = null!;
        public virtual DbSet<Sepet> Sepets { get; set; } = null!;
        public virtual DbSet<SiparisBilgileri> SiparisBilgileris { get; set; } = null!;
        public virtual DbSet<UrunBilgi> UrunBilgis { get; set; } = null!;
        public virtual DbSet<Yorumlar> Yorumlars { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-VEKTUC8;Database=ShopTekno;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MusteriKayit>(entity =>
            {
                entity.HasKey(e => e.MusteriId);

                entity.ToTable("MusteriKayit");

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.MusteriAd)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.MusteriMailAdresi)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.MusteriTelefon)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Sehir)
                    .HasMaxLength(170)
                    .IsFixedLength();

                entity.Property(e => e.Sifre)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<OdemeBilgisi>(entity =>
            {
                entity.HasKey(e => e.OdemeId);

                entity.ToTable("OdemeBilgisi");

                entity.Property(e => e.KartNo)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.KartSahibi)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SonKullanimTarihi).HasColumnType("date");

                entity.Property(e => e.ToplamFiyat)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.OdemeBilgisis)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OdemeBilgisi_MusteriKayit");
            });

            modelBuilder.Entity<SaticiKayit>(entity =>
            {
                entity.HasKey(e => e.SaticiId);

                entity.ToTable("SaticiKayit");

                entity.Property(e => e.KullaniciAdi)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.MailAdresi)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SaticiAd)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SaticiTelefon)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Sifre)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.SirketAd)
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.SirketAdresi)
                    .HasMaxLength(1000)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Sepet>(entity =>
            {
                entity.HasKey(e => e.SepetNo);

                entity.ToTable("Sepet");

                entity.Property(e => e.UrunFiyat).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Sepets)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sepet_MusteriKayit");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Sepets)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sepet_UrunBilgi");
            });

            modelBuilder.Entity<SiparisBilgileri>(entity =>
            {
                entity.HasKey(e => e.MusteriSiparisBilgileriId);

                entity.ToTable("SiparisBilgileri");

                entity.Property(e => e.EvAdresi)
                    .HasMaxLength(200)
                    .IsFixedLength();

                entity.Property(e => e.Sehir)
                    .HasMaxLength(170)
                    .IsFixedLength();

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.SiparisBilgileris)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SiparisBilgileri_MusteriKayit");
            });

            modelBuilder.Entity<UrunBilgi>(entity =>
            {
                entity.ToTable("UrunBilgi");

                entity.Property(e => e.AcıklamaDetay)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Eklenentarih).HasColumnType("date");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.IadeBilgisi)
                    .HasMaxLength(100)
                    .HasColumnName("iadeBilgisi")
                    .IsFixedLength();

                entity.Property(e => e.KargoBilgisi)
                    .HasMaxLength(90)
                    .IsFixedLength();

                entity.Property(e => e.Kategori)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Markası)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Resim).HasColumnType("image");

                entity.Property(e => e.TeknikOzellikler)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.UrunKodu)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.HasOne(d => d.Satici)
                    .WithMany(p => p.UrunBilgis)
                    .HasForeignKey(d => d.SaticiId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UrunBilgi_SaticiKayit");
            });

            modelBuilder.Entity<Yorumlar>(entity =>
            {
                entity.HasKey(e => e.YorumId);

                entity.ToTable("Yorumlar");

                entity.Property(e => e.Yorum)
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.HasOne(d => d.Musteri)
                    .WithMany(p => p.Yorumlars)
                    .HasForeignKey(d => d.MusteriId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Yorumlar_MusteriKayit");

                entity.HasOne(d => d.Urun)
                    .WithMany(p => p.Yorumlars)
                    .HasForeignKey(d => d.UrunId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Yorumlar_UrunBilgi");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
