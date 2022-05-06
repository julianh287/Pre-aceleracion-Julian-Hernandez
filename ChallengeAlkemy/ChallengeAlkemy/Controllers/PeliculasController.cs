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




/*  public IActionResult Get()
       {
           return Ok(_context.Pelicula.ToList());
       }*/



//==================================================================================================================================


// GET: Peliculas
/*public async Task<IActionResult> Index()
{
    return View(await _context.Pelicula.ToListAsync());
}

// GET: Peliculas/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var peliculas = await _context.Pelicula
        .FirstOrDefaultAsync(m => m.Id == id);
    if (peliculas == null)
    {
        return NotFound();
    }

    return View(peliculas);
}

// GET: Peliculas/Create
public IActionResult Create()
{
    return View();
}

// POST: Peliculas/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Imagen,Titulo,Fecha,Calificacion")] Peliculas peliculas)
{
    if (ModelState.IsValid)
    {
        _context.Add(peliculas);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(peliculas);
}

// GET: Peliculas/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var peliculas = await _context.Pelicula.FindAsync(id);
    if (peliculas == null)
    {
        return NotFound();
    }
    return View(peliculas);
}

// POST: Peliculas/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Imagen,Titulo,Fecha,Calificacion")] Peliculas peliculas)
{
    if (id != peliculas.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(peliculas);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PeliculasExists(peliculas.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
    }
    return View(peliculas);
}

// GET: Peliculas/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var peliculas = await _context.Pelicula
        .FirstOrDefaultAsync(m => m.Id == id);
    if (peliculas == null)
    {
        return NotFound();
    }

    return View(peliculas);
}

// POST: Peliculas/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var peliculas = await _context.Pelicula.FindAsync(id);
    _context.Pelicula.Remove(peliculas);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool PeliculasExists(int id)
{
    return _context.Pelicula.Any(e => e.Id == id);
}*/


//==========================================================================================================================================
//==========================================================================================================================================
//==========================================================================================================================================
//==========================================================================================================================================
//==========================================================================================================================================
//==========================================================================================================================================

/*//GET de peliculas. Deberá mostrar imagen, titulo y fecha. endpoint: /movies
[HttpGet]
[Route("movies")]
public async Task<IActionResult> GetMovieList()
{
    try
    {
        var query = _context.GetQueryable()
                    .Select(m => new ListMovieDTO { img_url = m.Image_url, title = m.Title, date = m.Date_creation })
                    .ToList();

        return Ok(query);
    }
    catch (System.Exception e)
    {
        throw new Exception(e.Message);
    }
}

//GET Pelicula. Devuelve todos los campos de Pelicula y los personajes asociados. 
[HttpGet]
[Route("movie/details")]
public async Task<IActionResult> GetMovieDetails()
{
    try
    {
        var query = _context.GetMovieDetails();
        return Ok(query);
    }
    catch (System.Exception e)
    {
        throw new Exception(e.Message);
    }
}
//POST Pelicula
[HttpPost]
[Route("movie/create")]
public async Task<ActionResult> Create([FromBody] CreateMovieDTO model)
{
    var exists = await _context.SingleOrDefaultAsync(m => m.Title == model.title);

    if (exists != null)
    {
        return StatusCode(StatusCodes.Status400BadRequest, new
        {
            Status = "Error",
            Message = "The character already exists!"
        });
    }

    var pelicula = new Peliculas
    {
        Image_url = model.image_url,
        Title = model.title,
        Date_creation = model.date_creation,
        Rating = model.rating,
    };

    if (ModelState.IsValid)
    {
        try
        {
            if (string.IsNullOrEmpty(model.image_url))
            {
                return Ok("Image not found");
            }
            if (string.IsNullOrEmpty(model.title))
            {
                return Ok("Name required");
            }

            await _context.Insert(pelicula);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    return Ok(new
    {
        Status = "Success",
        Message = "Movie creation successfully!"
    });

}
//PUT Pelicula
[HttpPut]
[Route("movie/update")]
public async Task<ActionResult> Edit(UpdateMovieDTO model)
{
    var match = _context.GetQueryable().FirstOrDefault(c => c.MovieID == model.movieID);

    if (match == null)
    {
        return StatusCode(StatusCodes.Status400BadRequest, new
        {
            Status = "Error",
            Message = "Id number not found!"
        });
    }

    if (ModelState.IsValid)
    {
        try
        {
            match.Image_url = model.image_url;
            match.Title = model.title;
            match.Date_creation = model.date_creation;
            match.Rating = model.rating;

            if (string.IsNullOrEmpty(model.image_url))
            {
                return Ok("Image not found");
            }
            if (string.IsNullOrEmpty(model.title))
            {
                return Ok("Name required");
            }

            await _context.Update(match);
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    return Ok(new
    {
        Status = "Success",
        Message = "Movie updated successfully!"
    });
}
//DELETE Pelicula
[HttpDelete]
[Route("movie/delete")]
public async Task<ActionResult> Delete(int? id)
{
    try
    {
        if (id == null)
            return NotFound();

        await _context.Delete(id.Value);

        return Ok(new
        {
            Status = "Success",
            Message = "Movie deleted successfully!"
        });
    }
    catch (Exception)
    {
        return NotFound("Movie doesn't exists");
    }
}

//BUSQUEDA DE PELICULAS
//GET /movies?name=nombre
[HttpGet]
[Route("movie/byTitle")]
public async Task<ActionResult> GetMovieByTitle([FromQuery] SearchMovieDTO model)
{
    var exists2 = await _context.FirstOrDefaultAsync(m => m.Title.Contains(model.title));

    if (exists2 == null)
    {
        return StatusCode(StatusCodes.Status400BadRequest, new
        {
            Status = "Error",
            Message = "The movie doesn't exists!"
        });
    }

    try
    {
        var query = _context.GetMovieByTitle(model.title, model.genreId, model.orderBy);
        return Ok(query);
    }
    catch (System.Exception ex)
    {
        throw new Exception(ex.Message);
    }
}
//GET /movies?genre=idGenero
//GET /movies?order=ASC | DESC*/