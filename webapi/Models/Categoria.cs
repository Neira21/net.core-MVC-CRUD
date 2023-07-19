namespace webapi.Models
{
    public class Categoria
    {
        public int IDCategoria { get; set; }
        public string codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Estado { get; set; }
    }
}   