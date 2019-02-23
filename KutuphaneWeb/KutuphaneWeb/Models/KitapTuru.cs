using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class KitapTuru
    {
        public System.Guid ID { get; set; }
        public System.Guid KitapID { get; set; }
        public System.Guid TurID { get; set; }
        public virtual Kitap Kitap { get; set; }
        public virtual Tur Tur { get; set; }
    }
}
