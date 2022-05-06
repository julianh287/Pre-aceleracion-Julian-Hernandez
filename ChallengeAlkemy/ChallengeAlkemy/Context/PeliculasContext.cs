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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=GMEC-NT-001\\SQLEXPRESS; Database=PeliculasDB;Trusted_Connection=True;");
        }
        /*        public PeliculasContext(DbContextOptions<PeliculasContext> options) : base(options) { }
        */
        public DbSet<Peliculas> Pelicula { get; set; }
        public DbSet<Personajes> Personaje { get; set; }
        public DbSet<Generos> Genero { get; set; }
    }
}
