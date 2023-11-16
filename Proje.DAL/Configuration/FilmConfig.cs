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
    public class FilmConfig : BaseConfig<Film>
    {
        public override void Configure(EntityTypeBuilder<Film> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Dil).HasMaxLength(30);
        }
    }
}
