using Client.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Client.Infrastructure.Data.Context
{
    public static class UsuarioSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().HasData(
            new Usuario
            {
                Id = 1,
                Nome = "Admin",
                Email = "admin@teste.com",
                DataInclusao = DateTime.Now,
            });        
        }
    }
}
