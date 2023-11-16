using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Proje.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DAL.Configuration
{
    public class OyuncuConfig : BaseConfig<Oyuncu>
    {
        public override void Configure(EntityTypeBuilder<Oyuncu> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Soyad).HasMaxLength(20);
        }
    }
}
