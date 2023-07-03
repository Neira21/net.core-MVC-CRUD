using System.ComponentModel.DataAnnotations;

namespace mvc.DTOs
{
    public class ActorCreacionDTO
    {
        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}