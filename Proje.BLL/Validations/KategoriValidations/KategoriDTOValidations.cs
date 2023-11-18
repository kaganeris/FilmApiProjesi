using FluentValidation;
using Proje.BLL.Models.DTOs.KategoriDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.BLL.Validations.KategoriValidations
{
    public class KategoriDTOValidations : AbstractValidator<KategoriDTO>
    {
        public KategoriDTOValidations()
        {
            RuleFor(x => x.Ad).NotEmpty().WithMessage("Ad boş geçilemez!").NotEqual("string").WithMessage("Ad 'string' olamaz!");
        }
    }
}
