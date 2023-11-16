using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Configuration
{
    public class FilmlerOyuncularConfig : IEntityTypeConfiguration<FilmlerOyuncular>
    {
        public void Configure(EntityTypeBuilder<FilmlerOyuncular> builder)
        {
            builder.HasOne(x => x.Oyuncu).WithMany(x => x.FilmlerOyuncular).HasForeignKey(x => x.OyuncuID);
            builder.HasOne(x => x.Film).WithMany(x => x.FilmlerOyuncular).HasForeignKey(x => x.FilmID);
            builder.HasKey(x => new { x.OyuncuID, x.FilmID });
        }
    }
}
