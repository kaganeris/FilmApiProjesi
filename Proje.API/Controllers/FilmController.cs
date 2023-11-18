using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proje.BLL.Models.DTOs.FilmDTOs;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Validations.FilmValidations;
using Proje.CORE.Entities;

namespace Proje.API.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly IFilmService filmService;
        private readonly IOyuncuService oyuncuService;
        private readonly IKategoriService kategoriService;
        private readonly IMapper mapper;

        public FilmController(IFilmService filmService, IOyuncuService oyuncuService, IKategoriService kategoriService, IMapper mapper)
        {
            this.filmService = filmService;
            this.oyuncuService = oyuncuService;
            this.kategoriService = kategoriService;
            this.mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var filmler = filmService.GetAll();
            return Ok(filmler);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var film = filmService.GetByID(id);
            if (film == null)
                return NotFound();
            else
                return Ok(film);
        }

        [HttpPost]
        public IActionResult Create(FilmDTO filmDTO)
        {
            CreateFilmValidations validationRules = new CreateFilmValidations();
            var result = validationRules.Validate(filmDTO);
            if (result.IsValid)
            {
                Film film = new Film();
                film = mapper.Map<Film>(filmDTO);


                foreach (var item in filmDTO.OyuncuIDleri)
                {
                    var oyuncu = oyuncuService.GetByID(item);
                    if (oyuncu == null)
                        return BadRequest("Girdiğiniz OyuncuID'si ile oyuncu bulunamadı!");
                    else
                    {
                        film.FilmlerOyuncular.Add(new FilmlerOyuncular { Film = film, Oyuncu = oyuncu });
                    }
                }

                foreach (var item in filmDTO.KategoriIDleri)
                {
                    var kategori = kategoriService.GetByID(item);
                    if (kategori == null)
                        return BadRequest("Girdiğiniz KategoriID'si ile kategori bulunamadı!");
                    else
                    {
                        film.FilmlerKategoriler.Add(new FilmlerKategoriler { Film = film, Kategori = kategori });
                    }
                }

                bool serviceResult = filmService.Add(film);

                if (serviceResult == true)
                    return Ok("Film başarıyla eklendi!");
                else
                    return BadRequest("HATA! Film eklenemedi! \nNOT: Ad 30 harftan fazla olamaz!");



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
        public IActionResult Update(int id, FilmDTO filmDTO)
        {
            var updatedFilm = filmService.GetByID(id);
            if (updatedFilm == null)
                return NotFound();
            else
            {

                CreateFilmValidations validationRules = new CreateFilmValidations();
                var result = validationRules.Validate(filmDTO);
                if (result.IsValid)
                {
                    updatedFilm = mapper.Map(filmDTO, updatedFilm);

                    bool serviceResult = filmService.Update(updatedFilm);

                    if (serviceResult == true)
                        return Ok("Film başarıyla güncellendi");
                    else
                        return BadRequest("Film güncellenemedi! \nNot:Ad ve dil 30 harften fazla olamaz.");
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
            var deletedFilm = filmService.GetByID(id);
            if (deletedFilm == null)
                return NotFound();
            else
            {
                bool serviceResult = filmService.Delete(id);

                if (serviceResult == true)
                    return Ok("Film başarıyla silindi!");
                else return BadRequest("HATA! Film silinemedi!");
            }
        }
    }
}
