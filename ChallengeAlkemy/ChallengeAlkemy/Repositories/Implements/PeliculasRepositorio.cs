using ChallengeAlkemy.Context;
using ChallengeAlkemy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.Implements
{
    public class PeliculasRepositorio : IGenericRepository<Peliculas>, IPeliculasRepositorio
    {
        private PeliculasContext _peliculasContext;

        public PeliculasRepositorio(PeliculasContext peliculasContext) : base(peliculasContext)
        {
            _peliculasContext = peliculasContext;
        }
        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> FirstOrDefaultAsync(Expression<Func<Peliculas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> FirstOrDefaultAsync(Expression<Func<Personajes, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Peliculas>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Peliculas> GetPeliculaByName(string nombre, string genero, DateTime fecha, int peliculaId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Peliculas> GetPeliculaDetails()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Personajes> GetPersonajeByName(string nombre, int edad, decimal peso, int personajeId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Personajes> GetPersonajeDetails()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Peliculas> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> Insert(Peliculas entity)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> Insert(Personajes entity)
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> SingleOrDefaultAsync(Expression<Func<Peliculas, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> SingleOrDefaultAsync(Expression<Func<Personajes, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Peliculas> Update(Peliculas entity)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> Update(Personajes entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Personajes>> IGenericRepository<Personajes>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Personajes> IGenericRepository<Personajes>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<Personajes> IGenericRepository<Personajes>.GetQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
