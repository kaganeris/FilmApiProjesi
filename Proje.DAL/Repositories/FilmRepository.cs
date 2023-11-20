using Microsoft.EntityFrameworkCore;
using Proje.CORE.Entities;
using Proje.CORE.Repositories;
using Proje.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Repositories
{
    public class FilmRepository : BaseRepository<Film>,IFilmRepository
    {
        private readonly AppDbContext context;

        public FilmRepository(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public object GetAllIncludeOyuncuKategori()
        {
            var asd = context.Filmler.Join(context.FilmlerKategoriler, f => f.ID, fk => fk.FilmID, (f, fk) => new
            {
                f.Ad,
                f.Dil,
                f.Sure,
                f.ID,
                fk.KategoriID
            }).Join(context.Kategoriler, f => f.KategoriID, k => k.ID, (f, k) => new
            {
                f.Ad,
                f.Dil,
                f.Sure,
                f.ID,
                kategoriAdı = k.Ad
            }).Join(context.FilmlerOyuncular, f => f.ID, fo => fo.FilmID, (f, fo) => new
            {
                f.Ad,
                f.Dil,
                f.Sure,
                f.ID,
                fo.OyuncuID,
                f.kategoriAdı
            }).Join(context.Oyuncular, f => f.OyuncuID, o => o.ID, (f, o) => new
            {
                f.Ad,
                f.Dil,
                f.Sure,
                f.ID,
                f.kategoriAdı,
                oyuncuAdı = o.Ad + o.Soyad
            }).ToList();

            return asd;

            //return context.Filmler.Include(x => x.FilmlerOyuncular).ThenInclude(x => x.Oyuncu).Include(x => x.FilmlerKategoriler).ThenInclude(x => x.Kategori).Select(x => new FilmlerKategoriler
            //{
            //     = x.Ad,

            //}).ToList();


        }

        public Film GetFilmIncludeOyuncularKategorilerById(int id)
        {
            return context.Filmler.Include(x => x.FilmlerOyuncular).Include(x => x.FilmlerKategoriler).Where(x => x.ID == id).FirstOrDefault();
        }


    }
}
