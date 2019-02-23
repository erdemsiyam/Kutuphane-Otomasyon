using System;
using System.Collections.Generic;

namespace KutuphaneWeb.Models
{
    public partial class OduncKitap
    {
        public System.Guid ID { get; set; }
        public System.Guid KitapID { get; set; }
        public System.Guid UyeID { get; set; }
        public System.DateTime BaslangicTarih { get; set; }
        public System.DateTime BitisTarih { get; set; }
        public Nullable<bool> GeriAlindiMi { get; set; }
        public Nullable<System.DateTime> GeriAlinmaTarihi { get; set; }
        public virtual Kitap Kitap { get; set; }
        public virtual Uye Uye { get; set; }
    }
}
