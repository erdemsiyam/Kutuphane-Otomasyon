using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class Tur
    {
        public Tur()
        {
            this.KitapTurus = new List<KitapTuru>();
        }

        public System.Guid ID { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<KitapTuru> KitapTurus { get; set; }
    }
}
