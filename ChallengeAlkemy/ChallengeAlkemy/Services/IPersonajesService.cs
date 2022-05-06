﻿using ChallengeAlkemy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Services
{
    public interface IPersonajesService : IGenericService<Personajes>
    {
        IQueryable<Personajes> GetPersonajeDetails();
        IQueryable<Personajes> GetPersonajeByName(string nombre, int edad, decimal peso, int personajeId);
    }
}
