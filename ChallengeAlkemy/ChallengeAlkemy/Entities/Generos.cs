using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Entities
{
    public class Generos
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public ICollection<Peliculas> Pelicula { get; set; }
    }
}
