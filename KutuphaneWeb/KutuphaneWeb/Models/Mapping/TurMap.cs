using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace KutuphaneWeb.Models.Mapping
{
    public class TurMap : EntityTypeConfiguration<Tur>
    {
        public TurMap()
        {
            // Primary Key
            this.HasKey(t => t.ID);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Tur");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Adi).HasColumnName("Adi");
        }
    }
}