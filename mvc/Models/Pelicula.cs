namespace mvc.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = null!;
        public int Duracion { get; set; }
        public bool EnCines { get; set; }
        public DateTime FechaEstreno { get; set; }
        
        //Para trabajar con colecciones en EF Core, se debe inicializar la colección en el constructor
        //Pero no permite ordenar, filtrar, etc.
        public HashSet<Comentario> Comentarios { get; set; } = new HashSet<Comentario>();
        public HashSet<Genero> Generos { get; set; } = new HashSet<Genero>();
        //public List<Comentario> Comentarios { get; set; } = null!;
        //public List<Genero> Generos { get; set; } = null!;
        public List<PeliculaActor> PeliculaActores { get; set; } = new List<PeliculaActor>();
    }
}
