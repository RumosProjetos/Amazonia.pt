using Amazonia.DAL.Modelo;
using Microsoft.EntityFrameworkCore;
using System;

namespace Amazonia.eCommerceRazor.Models
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Morada>().HasData(
                    new Morada
                    {
                        Id = Guid.NewGuid(),
                        Distrito = "Setubal",
                        Localidade = "Barreiro"
                    },
                   new Morada
                   {
                       Id = Guid.NewGuid(),
                       Distrito = "Lisboa",
                       Localidade = "Lisboa"
                   }
            );
        }


        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<Morada> Morada { get; set; }
    }
}
