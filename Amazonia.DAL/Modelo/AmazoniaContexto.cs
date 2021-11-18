﻿using Microsoft.EntityFrameworkCore;

namespace Amazonia.DAL.Modelo
{
    public class AmazoniaContexto : DbContext
    {
        public DbSet<Morada> Moradas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }


        //Exemplo SQLServer
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = @$"Server=(LocalDB)\MSSQLLocalDB;Database=Amazonia.pt;Trusted_Connection=True;";
            options.UseSqlServer(connectionString);
        }

        //Exemplo SQLite
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var connectionString = @$"Data Source=c:\temp\meudb.db";
        //    options.UseSqlite(connectionString);
        //}


        //Forma Alternativa
        //protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Amazonia.pt;Trusted_Connection=True;");


    }
}
