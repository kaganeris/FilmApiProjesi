using Proje.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.CORE.Entities
{
    public class Oyuncu : BaseEntity
    {
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Ulke { get; set; }
        public List<FilmlerOyuncular> FilmlerOyuncular { get; set; }
    }
}
