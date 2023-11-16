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
    public class FilmlerKategorilerConfig : IEntityTypeConfiguration<FilmlerKategoriler>
    {
        public void Configure(EntityTypeBuilder<FilmlerKategoriler> builder)
        {
            builder.HasOne(x => x.Kategori).WithMany(x => x.FilmlerKategoriler).HasForeignKey(x => x.KategoriID);
            builder.HasOne(x => x.Film).WithMany(x => x.FilmlerKategoriler).HasForeignKey(x => x.FilmID);
            builder.HasKey(x => new { x.KategoriID, x.FilmID });
        }
    }
}
