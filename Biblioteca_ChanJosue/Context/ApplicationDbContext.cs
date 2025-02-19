using Biblioteca_ChanJosue.Models.Domain;
using Microsoft.EntityFrameworkCore;
namespace Biblioteca_ChanJosue.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //modelos a mapear
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "JosueChan",
                    Username = "Hipprx",
                    Password = "Josue123",
                    FkRol = 1
                }
                );

            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "Administrador"
                }
                );
        }
    }
}
