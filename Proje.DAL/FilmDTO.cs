using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL
{
    public class FilmDTO
    {
        public int ID { get; set; }
        public string Ad { get; set; }
        public string Dil { get; set; }
        public string Sure { get; set; }
        public string oyuncuAdı { get; set; }
        public string kategoriAdı { get; set; }
    }
}
