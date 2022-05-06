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
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var query = _context.GetQueryable()
                            .Select(c => new ListCharacterDTO { name = c.Name, img_url = c.Image_url })
                            .ToList();
                return Ok(query);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //GET Personaje. Debe mostrar los atributos del personaje y sus películas asociadas. 
        [HttpGet]
        [Route("character/details")]
        public async Task<IActionResult> GetDetails()
        {
            try
            {
                var query = _context.GetCharacterDetails();
                return Ok(query);
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //POST Personaje
        [HttpPost]
        [Route("character/create")]
        public async Task<ActionResult> Create(CreateCharacterDTO model)
        {
            var exists = await _context.SingleOrDefaultAsync(m => m.Name == model.name);

            if (exists != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = "Error",
                    Message = "The character already exists!"
                });
            }

            var personaje = new Personajes
            {
                Imagen = model.image_url,
                Nombre = model.name,
                Edad = model.age,
                Peso = model.weight,
                Historia = model.story
            };

            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(model.image_url))
                    {
                        return Ok("Image not found");
                    }
                    if (string.IsNullOrEmpty(model.name))
                    {
                        return Ok("Name required");
                    }
                    if (string.IsNullOrEmpty(model.story))
                    {
                        return Ok("Story required");
                    }

                    await _context.Insert(personaje);
                }
                catch (System.Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return Ok(new
            {
                Status = "Success",
                Message = "Character creation successfully!"
            });

        }
        //PUT Personaje
        [HttpPut]
        [Route("character/update")]
        public async Task<ActionResult> Edit(UpdateCharacterDTO model)
        {
            var match = _context.GetQueryable().FirstOrDefault(c => c.CharacterID == model.id);

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
                    match.Name = model.name;
                    match.Age = model.age;
                    match.Weight = model.weight;
                    match.Story = model.story;

                    if (string.IsNullOrEmpty(model.image_url))
                    {
                        return Ok("Image not found");
                    }
                    if (string.IsNullOrEmpty(model.name))
                    {
                        return Ok("Name required");
                    }
                    if (string.IsNullOrEmpty(model.story))
                    {
                        return Ok("Story required");
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
                Message = "Character updated successfully!"
            });
        }
        //DELETE Personaje
        [HttpDelete]
        [Route("character/delete")]
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
                    Message = "Character deleted successfully!"
                });
            }
            catch (Exception)
            {
                return NotFound("Character doesn't exists");
            }
        }

        //BUSQUEDA DE PERSONAJES
        //GET /characters?name=nombre
        [HttpGet]
        [Route("character/byName")]
        public async Task<ActionResult> GetByName([FromQuery] SearchCharacterDTO model)
        {
            //var exists = await _characterService.SingleOrDefaultAsync(m => m.Name == model.name);
            var exists = await _context.FirstOrDefaultAsync(m => m.Name.Contains(model.name));

            if (exists == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    Status = "Error",
                    Message = "The character doesn't exists!"
                });
            }

            try
            {
                var query = _context.GetByName(model.name, model.age, model.weight, model.movieId);
                return Ok(query);
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //GET /characters?age=edad
        //GET /characters?movies=idMovie

    }
}










//========================================================================================================================0
// GET: Personajes
/*public async Task<IActionResult> Index()
{
    return View(await _context.Personaje.ToListAsync());
}

// GET: Personajes/Details/5
public async Task<IActionResult> Details(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var personajes = await _context.Personaje
        .FirstOrDefaultAsync(m => m.Id == id);
    if (personajes == null)
    {
        return NotFound();
    }

    return View(personajes);
}

// GET: Personajes/Create
public IActionResult Create()
{
    return View();
}

// POST: Personajes/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Id,Imagen,Nombre,Edad,Peso,Historia")] Personajes personajes)
{
    if (ModelState.IsValid)
    {
        _context.Add(personajes);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    return View(personajes);
}

// GET: Personajes/Edit/5
public async Task<IActionResult> Edit(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var personajes = await _context.Personaje.FindAsync(id);
    if (personajes == null)
    {
        return NotFound();
    }
    return View(personajes);
}*/

// POST: Personajes/Edit/5
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
/*[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Imagen,Nombre,Edad,Peso,Historia")] Personajes personajes)
{
    if (id != personajes.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            _context.Update(personajes);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PersonajesExists(personajes.Id))
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
    return View(personajes);
}

// GET: Personajes/Delete/5
public async Task<IActionResult> Delete(int? id)
{
    if (id == null)
    {
        return NotFound();
    }

    var personajes = await _context.Personaje
        .FirstOrDefaultAsync(m => m.Id == id);
    if (personajes == null)
    {
        return NotFound();
    }

    return View(personajes);
}

// POST: Personajes/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
    var personajes = await _context.Personaje.FindAsync(id);
    _context.Personaje.Remove(personajes);
    await _context.SaveChangesAsync();
    return RedirectToAction(nameof(Index));
}

private bool PersonajesExists(int id)
{
    return _context.Personaje.Any(e => e.Id == id);
}*/