using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class Uye
    {
        public Uye()
        {
            this.OduncKitaps = new List<OduncKitap>();
        }

        public System.Guid ID { get; set; }
        public string Email { get; set; }
        public string AdSoyad { get; set; }
        public int DogumYili { get; set; }
        public string Sifre { get; set; }
        public string Telefon { get; set; }
        public Nullable<System.Guid> RolID { get; set; }
        public virtual ICollection<OduncKitap> OduncKitaps { get; set; }
        public virtual Rol Rol { get; set; }
    }
}
