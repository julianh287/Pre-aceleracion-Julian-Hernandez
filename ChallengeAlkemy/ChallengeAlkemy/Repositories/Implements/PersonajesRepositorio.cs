using ChallengeAlkemy.Context;
using ChallengeAlkemy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Repositories.Implements
{
    public class PersonajesRepositorio : IGenericRepository<Personajes>, IPersonajesRepositorio
    {
        private PeliculasContext _peliculasContext;

        public PersonajesRepositorio(PeliculasContext peliculasContext) : base(peliculasContext)
        {
            _peliculasContext = peliculasContext;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> FirstOrDefaultAsync(Expression<Func<Personajes, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<List<Personajes>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> GetById(int id)
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

        public IQueryable<Personajes> GetQueryable()
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> Insert(Personajes entity)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> SingleOrDefaultAsync(Expression<Func<Personajes, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Personajes> Update(Personajes entity)
        {
            throw new NotImplementedException();
        }
    }
}
