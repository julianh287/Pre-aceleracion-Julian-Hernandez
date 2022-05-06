using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeAlkemy.Entities
{
    public class Personajes
    {
        [Key]
        public int Id { get; set; }
        public string Imagen { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public float Peso { get; set; }
        public string Historia { get; set; }
        [Required]
        public ICollection<Peliculas> Pelicula { get; set; }

    }
}
