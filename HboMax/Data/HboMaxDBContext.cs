using HboMax.Data.Map;
using HboMax.Models;
using Microsoft.EntityFrameworkCore;

namespace HboMax.Data
{
    public class HboMaxDBContext: DbContext 
    {
        public HboMaxDBContext(DbContextOptions<HboMaxDBContext> options) : base(options) 
        {
            
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);

            UsuarioModel user = new UsuarioModel();
            user.Id = 1;
            user.Nome = "Lucas Lopes do Nascimento";
            user.Email = "lucaslopesnascimento122@gmail.com";
            user.Senha = "1233456";
            user.CPF = 54436359808;

            modelBuilder.Entity<UsuarioModel>().HasData(user);
        }
    }
}
