using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Entities
{
    public class Peliculas
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Titulo { get; set; }
        public DateTime Fecha { get; set; }
        public int Calificacion { get; set; }
        public ICollection<Personajes> Personaje { get; set; }
        public ICollection<Generos> Genero { get; set; }
    }
}
