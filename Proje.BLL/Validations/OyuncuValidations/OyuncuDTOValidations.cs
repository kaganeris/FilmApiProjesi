using FluentValidation;
using Proje.BLL.Models.DTOs.OyuncuDTOs;
using Proje.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Validations.OyuncuValidations
{
    public class OyuncuDTOValidations : AbstractValidator<OyuncuDTO>
    {
        public OyuncuDTOValidations()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez!").NotEqual("string").WithMessage("Ad 'string' olamaz!");
            RuleFor(x => x.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez!").NotEqual("string").WithMessage("Soyad 'string' olamaz!"); ;
            RuleFor(x => x.Cinsiyet).IsInEnum().WithMessage("Cinsiyet boş geçilemez!");
            RuleFor(x => x.DogumTarihi).NotEmpty().WithMessage("Doğum Tarihi boş geçilemez!");
            RuleFor(x => x.Ulke).NotEmpty().WithMessage("Ülke boş geçilemez!").NotEqual("string").WithMessage("Ülke 'string' olamaz!"); ;
        }
    }
}
