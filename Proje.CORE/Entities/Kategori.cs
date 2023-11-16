using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class Kategori : BaseEntity
    {
        public List<FilmlerKategoriler> FilmlerKategoriler { get; set; }
    }
}
