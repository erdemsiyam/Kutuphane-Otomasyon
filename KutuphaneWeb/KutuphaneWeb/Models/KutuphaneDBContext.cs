using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using KutuphaneWeb.Models.Mapping;

namespace KutuphaneWeb.Models
{
    public partial class KutuphaneDBContext : DbContext
    {
        static KutuphaneDBContext()
        {
            Database.SetInitializer<KutuphaneDBContext>(null);
        }

        public KutuphaneDBContext()
            : base("Name=KutuphaneDBContext")
        {
        }

        public DbSet<Kitap> Kitaps { get; set; }
        public DbSet<KitapTuru> KitapTurus { get; set; }
        public DbSet<OduncKitap> OduncKitaps { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<Tip> Tips { get; set; }
        public DbSet<Tur> Turs { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<YayinEvi> YayinEvis { get; set; }
        public DbSet<Yazar> Yazars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KitapMap());
            modelBuilder.Configurations.Add(new KitapTuruMap());
            modelBuilder.Configurations.Add(new OduncKitapMap());
            modelBuilder.Configurations.Add(new RolMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new TipMap());
            modelBuilder.Configurations.Add(new TurMap());
            modelBuilder.Configurations.Add(new UyeMap());
            modelBuilder.Configurations.Add(new YayinEviMap());
            modelBuilder.Configurations.Add(new YazarMap());
        }
    }
}
