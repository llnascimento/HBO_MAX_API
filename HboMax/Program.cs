using HboMax.Data;
using HboMax.Repositorios;
using HboMax.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace HboMax
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

            builder.Services.AddEntityFrameworkSqlServer()
              .AddDbContext<HboMaxDBContext>(
                  options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataSomee"))
            );

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositoriocs>();

            builder.Services.AddCors();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
            });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}