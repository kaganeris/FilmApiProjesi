using Microsoft.EntityFrameworkCore;
using Proje.BLL.Services.Abstract;
using Proje.BLL.Services.Concrete;
using Proje.CORE.Repositories;
using Proje.DAL.Context;
using Proje.DAL.Repositories;

namespace Proje.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultCon")));

            // Repository dependency injection
            builder.Services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddTransient(typeof(IOyuncuRepository), typeof(OyuncuRepository));
            builder.Services.AddTransient(typeof(IFilmRepository), typeof(FilmRepository));
            builder.Services.AddTransient(typeof(IKategoriRepository), typeof(KategoriRepository));

            // Service dependency intection
            builder.Services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            builder.Services.AddTransient(typeof(IKategoriService), typeof(KategoriService));
            builder.Services.AddTransient(typeof(IOyuncuService), typeof(OyuncuService));
            builder.Services.AddTransient(typeof(IFilmService), typeof(FilmService));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}