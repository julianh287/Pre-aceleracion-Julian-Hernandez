using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using System.Threading.Tasks;
using ChallengeAlkemy.Entities;

namespace ChallengeAlkemy.Context
{
    public class PeliculasContext : DbContext
    {
        public const string schema = "peliculasDB";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GMEC-NT-001\\SQLEXPRESS; Database=PeliculasDB;Trusted_Connection=True;");
        }
        /*        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options) { }
        */
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(schema);
            builder.Entity<Peliculas>().HasData(
            new Peliculas
            {
                Id = 1,
                Titulo = "Titanic",
                Imagen = "TestImagen"
            });
            builder.Entity<Personajes>().HasData(
            new Personajes
            {
                Id = 1,
                Nombre = "Leo Dicky",
                Imagen = "TestImagen"
            });

        }

        internal Task GetAllPeliculas()
        {
            throw new NotImplementedException();
        }

        public DbSet<Peliculas> Pelicula { get; set; }
        public DbSet<Personajes> Personaje { get; set; }
        public DbSet<Generos> Genero { get; set; }
    }
}
