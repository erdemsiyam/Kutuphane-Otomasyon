using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class Kitap
    {
        public Kitap()
        {
            this.KitapTurus = new List<KitapTuru>();
            this.OduncKitaps = new List<OduncKitap>();
        }

        public System.Guid ID { get; set; }
        public string Adi { get; set; }
        public int SayfaSayisi { get; set; }
        public System.Guid YazarID { get; set; }
        public string Dili { get; set; }
        public Nullable<System.Guid> YayinEviID { get; set; }
        public System.Guid TipID { get; set; }
        public string ISBN { get; set; }
        public System.DateTime AlimTarihi { get; set; }
        public System.DateTime BasimTarihi { get; set; }
        public decimal Fiyati { get; set; }
        public string ResimURL { get; set; }
        public Nullable<bool> Aktif { get; set; }
        public Nullable<int> OkunmaSayisi { get; set; }
        public virtual Tip Tip { get; set; }
        public virtual YayinEvi YayinEvi { get; set; }
        public virtual Yazar Yazar { get; set; }
        public virtual ICollection<KitapTuru> KitapTurus { get; set; }
        public virtual ICollection<OduncKitap> OduncKitaps { get; set; }
    }
}
