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
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez!");
            RuleFor(x => x.Dil).NotEmpty().WithMessage("Dil boş geçilemez!");
            RuleFor(x => x.Sure).NotEmpty().WithMessage("Süre boş geçilemez!");
        }
    }
}
