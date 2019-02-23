using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneWeb.Models.Mapping
{
    public class OduncKitapMap : EntityTypeConfiguration<OduncKitap>
    {
        public OduncKitapMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("OduncKitap");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.KitapID).HasColumnName("KitapID");
            this.Property(t => t.UyeID).HasColumnName("UyeID");
            this.Property(t => t.BaslangicTarih).HasColumnName("BaslangicTarih");
            this.Property(t => t.BitisTarih).HasColumnName("BitisTarih");
            this.Property(t => t.GeriAlindiMi).HasColumnName("GeriAlindiMi");
            this.Property(t => t.GeriAlinmaTarihi).HasColumnName("GeriAlinmaTarihi");

            // Relationships
            this.HasRequired(t => t.Kitap)
                .WithMany(t => t.OduncKitaps)
                .HasForeignKey(d => d.KitapID);
            this.HasRequired(t => t.Uye)
                .WithMany(t => t.OduncKitaps)
                .HasForeignKey(d => d.UyeID);

        }
    }
}
