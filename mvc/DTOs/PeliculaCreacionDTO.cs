using System.ComponentModel.DataAnnotations;
using mvc.Models;

namespace mvc.DTOs
{
    public class PeliculaCreacionDTO
    {
        [StringLength(maximumLength: 150)]
        public string Titulo { get; set; } = null!;
        public int Duracion { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        public List<int> Generos { get; set; } = new List<int>();
        public List<PeliculaActorCreacionDTO> PeliculaActores { get; set; } 
            = new List<PeliculaActorCreacionDTO>();

    }
}