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
    public class PeliculasController : Controller
    {
        private readonly PeliculasContext _context;

        public PeliculasController(PeliculasContext context)
        {
            _context = context;
        }

        //GET de peliculas. Deberá mostrar imagen, titulo y fecha. endpoint: /movies
        [HttpGet]
        [Route("movies")]     
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = _context.GetAllPeliculas();
                return Ok(list);
            }
            catch
            {
                return BadRequest("Error: No se pudo obtener el listado de películas");
            }
        }

        //GET Pelicula. Devuelve todos los campos de Pelicula y los personajes asociados. 
        [HttpGet]
        [Route("movie/details/{id}")]
        public IActionResult GetMovie(int id)
        {
            if (_context.Pelicula.Where(x => x.Id == id) == null) return BadRequest("La pelicula no existe");

            var peliculaAuxiliar = _context.Pelicula.Find(id);
            return Ok(peliculaAuxiliar);
        }

        //POST Pelicula
        [HttpPost]
        [Route("movie/create")]
        public IActionResult Post(Peliculas pelicula)
        {
            _context.Pelicula.Add(pelicula);
            _context.SaveChanges();
            return Ok(_context.Pelicula.ToList());
        }

        //PUT Pelicula
        [HttpPut]
        [Route("movie/update")]
        public IActionResult Put(Peliculas pelicula)
        {
            if (_context.Pelicula.Where(x => x.Id == pelicula.Id) == null) return BadRequest("La pelicula no existe");

            var peliculaAuxiliar = _context.Pelicula.Find(pelicula.Id);
            peliculaAuxiliar.Titulo = pelicula.Titulo;
            peliculaAuxiliar.Imagen = pelicula.Imagen;
            peliculaAuxiliar.Fecha = pelicula.Fecha;
            peliculaAuxiliar.Personaje = pelicula.Personaje;
            peliculaAuxiliar.Calificacion = pelicula.Calificacion;
            peliculaAuxiliar.Genero = pelicula.Genero;
            _context.SaveChanges();
            return Ok(_context.Pelicula.ToList());
        }

        //DELETE Pelicula
        [HttpDelete]
        [Route("movie/delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (_context.Pelicula.Where(x => x.Id == id) == null) return BadRequest("La pelicula no existe");
            var peliculaAuxiliar = _context.Pelicula.Find(id);
            _context.Pelicula.Remove(peliculaAuxiliar);
            _context.SaveChanges();
            return Ok(_context.Pelicula.ToList());
        }


        //BUSQUEDA DE PELICULAS
        //GET /movies?name=nombre
        [HttpGet]
        [Route("movies")]
        public IActionResult GetByName(string nombre)
        {
            if (_context.Pelicula.Where(x => x.Titulo == nombre) == null) return BadRequest("La pelicula no existe");

            var peliculaAuxiliar = _context.Pelicula.Find(nombre);
            return Ok(peliculaAuxiliar);
        }

        //GET /movies?genre=idGenero
        //GET /movies?order=ASC | DESC
    }
}