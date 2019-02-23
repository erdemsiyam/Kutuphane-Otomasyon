using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneWeb.Models.Mapping
{
    public class KitapMap : EntityTypeConfiguration<Kitap>
    {
        public KitapMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Dili)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ISBN)
                .HasMaxLength(50);

            this.Property(t => t.ResimURL)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Kitap");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.SayfaSayisi).HasColumnName("SayfaSayisi");
            this.Property(t => t.YazarID).HasColumnName("YazarID");
            this.Property(t => t.Dili).HasColumnName("Dili");
            this.Property(t => t.YayinEviID).HasColumnName("YayinEviID");
            this.Property(t => t.TipID).HasColumnName("TipID");
            this.Property(t => t.ISBN).HasColumnName("ISBN");
            this.Property(t => t.AlimTarihi).HasColumnName("AlimTarihi");
            this.Property(t => t.BasimTarihi).HasColumnName("BasimTarihi");
            this.Property(t => t.Fiyati).HasColumnName("Fiyati");
            this.Property(t => t.ResimURL).HasColumnName("ResimURL");
            this.Property(t => t.Aktif).HasColumnName("Aktif");
            this.Property(t => t.OkunmaSayisi).HasColumnName("OkunmaSayisi");

            // Relationships
            this.HasRequired(t => t.Tip)
                .WithMany(t => t.Kitaps)
                .HasForeignKey(d => d.TipID);
            this.HasOptional(t => t.YayinEvi)
                .WithMany(t => t.Kitaps)
                .HasForeignKey(d => d.YayinEviID);
            this.HasRequired(t => t.Yazar)
                .WithMany(t => t.Kitaps)
                .HasForeignKey(d => d.YazarID);

        }
    }
}
