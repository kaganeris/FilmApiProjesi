using Microsoft.EntityFrameworkCore;
using Proje.CORE.Entities;
using Proje.DAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Film> Filmler { get; set; }
        public DbSet<Oyuncu> Oyuncular { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<FilmlerKategoriler> FilmlerKategoriler { get; set; }
        public DbSet<FilmlerOyuncular> FilmlerOyuncular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FilmConfig());
            modelBuilder.ApplyConfiguration(new KategoriConfig());
            modelBuilder.ApplyConfiguration(new OyuncuConfig());
            modelBuilder.ApplyConfiguration(new FilmlerKategorilerConfig());
            modelBuilder.ApplyConfiguration(new FilmlerOyuncularConfig());
            base.OnModelCreating(modelBuilder);

        }
    }
}
