using ChallengeAlkemy.Context;
using ChallengeAlkemy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.Implements
{
    public class PeliculasRepositorio : IGenericRepository<Peliculas>
    {
        private PeliculasContext _peliculasContext;

        public PeliculasRepositorio(PeliculasContext peliculasContext) : base()
        {
            _peliculasContext = peliculasContext;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Peliculas>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Peliculas>> GetAllPeliculas()
        {
            return _peliculasContext.Pelicula.ToList();
        }

        public Task<Peliculas> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> Insert(Peliculas entity)
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> Update(Peliculas entity)
        {
            throw new NotImplementedException();
        }
    }
}
