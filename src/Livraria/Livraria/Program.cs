
using Livraria.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
//            builder.Services.AddDbContext<DbLivraria>(options =>
                //options.UseMySql("Server=192.168.3.1;Database=dbprodutos;User Id=sa;Password=RR.SqlServerDev;"));

            builder.Services.AddDbContext<DbLivraria>(opt =>
            {
                opt.UseMySql
                (
                    builder.Configuration.GetConnectionString("Db"), 
                    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("Db"))
                )
                .UseLazyLoadingProxies();
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
