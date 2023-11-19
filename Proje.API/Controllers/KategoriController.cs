using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.KategoriDTOs;
using Proje.BLL.Models.DTOs.OyuncuDTOs;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Services.Concrete;
using Proje.BLL.Validations.KategoriValidations;
using Proje.BLL.Validations.OyuncuValidations;
using Proje.CORE.Entities;

namespace Proje.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;

        public KategoriController(IKategoriService kategoriService,IMapper mapper)
        {
            this.kategoriService = kategoriService;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var kategoriler = kategoriService.GetAll();
            return Ok(kategoriler);
        }

        [HttpPost]
        public IActionResult Create(KategoriDTO kategoriDTO)
        {
            KategoriDTOValidations validationRules = new KategoriDTOValidations();
            var result = validationRules.Validate(kategoriDTO);
            if (result.IsValid)
            {
                Kategori kategori = new Kategori();
                kategori = mapper.Map<Kategori>(kategoriDTO);

                bool serviceResult = kategoriService.Add(kategori);

                if (serviceResult == true)
                    return Ok("Kategori başarıyla eklendi");
                else
                    return BadRequest("Kategori eklenemedi! \nNot:Ad 30 harften fazla olamaz.");
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
        public IActionResult Update(int id, KategoriDTO kategoriDTO)
        {
            var updatedKategori = kategoriService.GetByID(id);
            if (updatedKategori == null)
                return NotFound();
            else
            {

                KategoriDTOValidations validationRules = new KategoriDTOValidations();
                var result = validationRules.Validate(kategoriDTO);
                if (result.IsValid)
                {
                    updatedKategori = mapper.Map(kategoriDTO, updatedKategori);

                    bool serviceResult = kategoriService.Update(updatedKategori);

                    if (serviceResult == true)
                        return Ok("Kategori başarıyla güncellendi");
                    else
                        return BadRequest("Kategori güncellenemedi! \nNot:Ad 30 harften fazla olamaz.");
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
            var deletedKategori = kategoriService.GetByID(id);
            if (deletedKategori == null)
                return NotFound();
            else
            {
                bool serviceResult = kategoriService.Delete(id);

                if (serviceResult == true)
                    return Ok("Kategori başarıyla silindi!");
                else return BadRequest("HATA! Kategori silinemedi!");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var kategori = kategoriService.GetByID(id);
            if (kategori == null)
                return NotFound();
            else
                return Ok(kategori);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllInclude()
        {
            var kategoriler = kategoriService.GetAllKategoriIncludeFilmler();
            return Ok(kategoriler);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetInclude(int id)
        {
            var kategori = kategoriService.GetKategoriIncludeFilmlerById(id);
            if (kategori == null)
                return NotFound();
            else
                return Ok(kategori);
        }
    }
}
