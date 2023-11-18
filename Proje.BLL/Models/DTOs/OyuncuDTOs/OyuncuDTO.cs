using Proje.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Models.DTOs.OyuncuDTOs
{
    public class OyuncuDTO
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Ulke { get; set; }
    }
}
