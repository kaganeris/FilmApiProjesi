using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public DateTime SilinmeTarihi { get; set; }
        public bool AktifMi { get; set; }
    }
}
