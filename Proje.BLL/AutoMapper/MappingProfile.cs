using AutoMapper;
using Proje.BLL.Models.DTOs.FilmDTOs;
using Proje.BLL.Models.DTOs.KategoriDTOs;
using Proje.BLL.Models.DTOs.OyuncuDTOs;
using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<FilmDTO, Film>();
            CreateMap<OyuncuDTO, Oyuncu>();
            CreateMap<KategoriDTO, Kategori>();
        }
    }
}
