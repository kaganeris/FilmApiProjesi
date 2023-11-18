using FluentValidation;
using Proje.BLL.Models.DTOs.FilmDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Validations.FilmValidations
{
    public class CreateFilmValidations : AbstractValidator<FilmDTO>
    {
        public CreateFilmValidations()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez!").NotEqual("string").WithMessage("Ad 'string' olamaz!"); 
            RuleFor(x => x.Dil).NotEmpty().WithMessage("Dil boş geçilemez!").NotEqual("string").WithMessage("Dil 'string' olamaz!");
            RuleFor(x => x.Sure).GreaterThan(0).WithMessage("Süre boş geçilemez!");
        }
    }
}
