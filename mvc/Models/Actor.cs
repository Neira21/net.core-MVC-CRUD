namespace mvc.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Fortuna { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public List<PeliculaActor> PeliculaActores { get; set; } = new List<PeliculaActor>();

    }
}