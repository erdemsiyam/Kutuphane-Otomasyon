using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneWeb.Models.Mapping
{
    public class KitapTuruMap : EntityTypeConfiguration<KitapTuru>
    {
        public KitapTuruMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            // Table & Column Mappings
            this.ToTable("KitapTuru");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.KitapID).HasColumnName("KitapID");
            this.Property(t => t.TurID).HasColumnName("TurID");

            // Relationships
            this.HasRequired(t => t.Kitap)
                .WithMany(t => t.KitapTurus)
                .HasForeignKey(d => d.KitapID);
            this.HasRequired(t => t.Tur)
                .WithMany(t => t.KitapTurus)
                .HasForeignKey(d => d.TurID);

        }
    }
}
