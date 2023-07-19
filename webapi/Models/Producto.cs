namespace webapi.Models
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string IDCategoria { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
    }
}   