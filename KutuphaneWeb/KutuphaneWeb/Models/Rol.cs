using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class Rol
    {
        public Rol()
        {
            this.Uyes = new List<Uye>();
        }

        public System.Guid ID { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Uye> Uyes { get; set; }
    }
}
