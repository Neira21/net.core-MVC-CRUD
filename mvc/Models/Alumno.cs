namespace mvc.Models
{
    public class Alumno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Contraseña { get; set; } = null!;
    }
}