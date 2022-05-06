using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChallengeAlkemy.Context;
using ChallengeAlkemy.Entities;

namespace ChallengeAlkemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonajesController : Controller
    {
        private readonly PeliculasContext _context;

        public PersonajesController(PeliculasContext context)
        {
            _context = context;
        }

        //GET Personajes. Debe mostrar imagen y nombre de todos los personajes. Endpoint: /characters
        [HttpGet]
        [Route("characters")]
        public IActionResult Get()
        {
            return Ok(_context.Personaje.ToList());
        }


        //GET Personaje. Debe mostrar los atributos del personaje y sus películas asociadas. 
        [HttpGet]
        [Route("character/details")]
        public IActionResult GetPersonaje(int id)
        {
            if (_context.Personaje.Where(x => x.Id == id) == null) return BadRequest("El personaje no existe");

            var personajeAuxiliar = _context.Personaje.Find(id);
            return Ok(personajeAuxiliar);
        }

        //POST Personaje
        [HttpPost]
        [Route("character/create")]
        public IActionResult Post(Personajes personaje)
        {
            _context.Personaje.Add(personaje);
            _context.SaveChanges();
            return Ok(_context.Personaje.ToList());
        }

        //PUT Personaje
        [HttpPut]
        [Route("character/update")]
        public IActionResult Put(Personajes personaje)
        {
            if (_context.Personaje.Where(x => x.Id == personaje.Id) == null) return BadRequest("La pelicula no existe");

            var personajeAuxiliar = _context.Personaje.Find(personaje.Id);
            personajeAuxiliar.Nombre = personaje.Nombre;
            personajeAuxiliar.Imagen = personaje.Imagen;
            personajeAuxiliar.Edad = personaje.Edad;
            personajeAuxiliar.Peso = personaje.Peso;
            personajeAuxiliar.Historia = personaje.Historia;
            _context.SaveChanges();
            return Ok(_context.Personaje.ToList());
        }

        //DELETE Personaje
        [HttpDelete]
        [Route("character/delete")]
        public IActionResult Delete(int id)
        {
            if (_context.Personaje.Where(x => x.Id == id) == null) return BadRequest("El personaje no existe");
            var personajeAuxiliar = _context.Personaje.Find(id);
            _context.Personaje.Remove(personajeAuxiliar);
            _context.SaveChanges();
            return Ok(_context.Personaje.ToList());
        }

        //BUSQUEDA DE PERSONAJES
        //GET /characters?name=nombre
        [HttpGet]
        [Route("character/byName")]
        public IActionResult GetByName(string nombre)
        {
            if (_context.Personaje.Where(x => x.Nombre == nombre) == null) return BadRequest("El personaje no existe");

            var personajeAuxiliar = _context.Personaje.Find(nombre);
            return Ok(personajeAuxiliar);
        }

        //GET /characters?age=edad
        //GET /characters?movies=idMovie

    }
}