using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneWeb.Models.Mapping
{
    public class UyeMap : EntityTypeConfiguration<Uye>
    {
        public UyeMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Email)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.AdSoyad)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Sifre)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Telefon)
                .IsFixedLength()
                .HasMaxLength(10);

            // Table & Column Mappings
            this.ToTable("Uye");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.AdSoyad).HasColumnName("AdSoyad");
            this.Property(t => t.DogumYili).HasColumnName("DogumYili");
            this.Property(t => t.Sifre).HasColumnName("Sifre");
            this.Property(t => t.Telefon).HasColumnName("Telefon");
            this.Property(t => t.RolID).HasColumnName("RolID");

            // Relationships
            this.HasOptional(t => t.Rol)
                .WithMany(t => t.Uyes)
                .HasForeignKey(d => d.RolID);

        }
    }
}
