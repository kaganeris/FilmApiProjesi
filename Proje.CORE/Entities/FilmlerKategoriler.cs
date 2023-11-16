using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class FilmlerKategoriler
    {
        public int FilmID { get; set; }
        public int KategoriID { get; set; }
        public Film Film { get; set; }
        public Kategori Kategori { get; set; }
    }
}
