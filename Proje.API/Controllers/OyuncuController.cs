using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.FilmDTOs;
using Proje.BLL.Models.DTOs.OyuncuDTOs;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Services.Concrete;
using Proje.BLL.Validations.FilmValidations;
using Proje.BLL.Validations.OyuncuValidations;
using Proje.CORE.Entities;

namespace Proje.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class OyuncuController : ControllerBase
    {
        private readonly IOyuncuService oyuncuService;
        private readonly IMapper mapper;

        public OyuncuController(IOyuncuService oyuncuService,IMapper mapper)
        {
            this.oyuncuService = oyuncuService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var oyuncular = oyuncuService.GetAll();
            return Ok(oyuncular);
        }

        [HttpPost]
        public IActionResult Create(OyuncuDTO oyuncuDTO)
        {
            OyuncuDTOValidations validationRules = new OyuncuDTOValidations();
            var result = validationRules.Validate(oyuncuDTO);
            if (result.IsValid)
            {
                Oyuncu oyuncu = new Oyuncu();
                oyuncu = mapper.Map<Oyuncu>(oyuncuDTO);

                bool serviceResult = oyuncuService.Add(oyuncu);

                if (serviceResult == true)
                    return Ok("Oyuncu başarıyla eklendi");
                else
                    return BadRequest("Oyuncu eklenemedi! \nNot:Ad 30 harften ve Soyad 20 harften fazla olamaz.");
            }
            else
            {
                var errors = "";
                foreach (var err in result.Errors)
                {
                    errors += err.ErrorMessage + "\n";
                }
                return BadRequest(errors);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, OyuncuDTO oyuncuDTO)
        {
            var updatedOyuncu = oyuncuService.GetByID(id);
            if (updatedOyuncu == null)
                return NotFound();
            else
            {

                OyuncuDTOValidations validationRules = new OyuncuDTOValidations();
                var result = validationRules.Validate(oyuncuDTO);
                if (result.IsValid)
                {
                    updatedOyuncu = mapper.Map(oyuncuDTO, updatedOyuncu);

                    bool serviceResult = oyuncuService.Update(updatedOyuncu);

                    if (serviceResult == true)
                        return Ok("Oyuncu başarıyla güncellendi");
                    else
                        return BadRequest("Oyuncu güncellenemedi! \nNot:Ad 30 harften ve Soyad 20 harften fazla olamaz.");
                }
                else
                {
                    var errors = "";
                    foreach (var err in result.Errors)
                    {
                        errors += err.ErrorMessage + "\n";
                    }
                    return BadRequest(errors);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedOyuncu = oyuncuService.GetByID(id);
            if (deletedOyuncu == null)
                return NotFound();
            else
            {
                bool serviceResult = oyuncuService.Delete(id);

                if (serviceResult == true)
                    return Ok("Oyuncu başarıyla silindi!");
                else return BadRequest("HATA! Oyuncu silinemedi!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var oyuncu = oyuncuService.GetByID(id);
            if (oyuncu == null)
                return NotFound();
            else
                return Ok(oyuncu);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInclude()
        {
            var oyuncular = oyuncuService.GetAllIncludeFilmler();
            return Ok(oyuncular);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetInclude(int id)
        {
            var oyuncu = oyuncuService.GetOyuncuIncludeFilmlerById(id);
            if (oyuncu == null)
                return NotFound();
            else
                return Ok(oyuncu);
        }
    }
}
