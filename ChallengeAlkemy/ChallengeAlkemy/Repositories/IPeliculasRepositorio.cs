using ChallengeAlkemy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories
{
    public interface IPeliculasRepositorio : IGenericRepository<Peliculas>
    {
        IQueryable<Peliculas> GetPeliculaDetails();
        IQueryable<Peliculas> GetPeliculaByName(string nombre, string genero, DateTime fecha, int peliculaId);
    }
}
