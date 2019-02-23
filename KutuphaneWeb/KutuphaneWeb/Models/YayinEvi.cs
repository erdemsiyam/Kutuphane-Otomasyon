using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class YayinEvi
    {
        public YayinEvi()
        {
            this.Kitaps = new List<Kitap>();
        }

        public System.Guid ID { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Kitap> Kitaps { get; set; }
    }
}
