using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class Film : BaseEntity
    {
        public Film()
        {
            FilmlerKategoriler = new();
            FilmlerOyuncular = new();
        }
        public string Dil { get; set; }
        public double Sure { get; set; }
        public List<FilmlerKategoriler> FilmlerKategoriler { get; set; }
        public List<FilmlerOyuncular> FilmlerOyuncular { get; set; }
    }
}
