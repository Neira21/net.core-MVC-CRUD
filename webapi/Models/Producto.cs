namespace webapi.Models
{
    public class Producto
    {
        public string IDProducto { get; set; }
        public string IDCategoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Precio { get; set; }
    }
}   