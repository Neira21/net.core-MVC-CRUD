namespace mvc.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int Duracion { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
    }
}
