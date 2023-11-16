using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class FilmlerOyuncular
    {
        public int FilmID { get; set; }
        public int OyuncuID { get; set; }
        public Film Film { get; set; }
        public Oyuncu Oyuncu { get; set; }
    }
}
