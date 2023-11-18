using AutoMapper;
using Proje.BLL.Models.DTOs.FilmDTOs;
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
        }
    }
}
