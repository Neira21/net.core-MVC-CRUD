using System.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webapi.Models;
using webapi.Recursos;

namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarProducto")]
        public dynamic ListarProducto(){
            List<Parametro> parametros = new List<Parametro>{
                new Parametro("@Estado", "1")
            };
            DataTable tCategoria = DBDatos.Listar("Categoria_Listar", parametros);
            DataTable tProducto = DBDatos.Listar("Producto_Listar");
            
            string jsonCategoria = JsonConvert.SerializeObject(tCategoria);
            string jsonProducto = JsonConvert.SerializeObject(tProducto);

            return new {
                success = true,
                mensaje = "exito",
                result = new {
                    Categoria = JsonConvert.DeserializeObject<List<Categoria>>(jsonCategoria),
                    Producto = JsonConvert.DeserializeObject<List<Producto>>(jsonProducto),
                }
            };
        }

        [HttpPost]
        [Route("AgregarProducto")]
        public dynamic Agregar_Producto(Producto producto){
            List<Parametro> parametros = new List<Parametro>
            {
                new Parametro("@IDCategoria", producto.IDCategoria),
                new Parametro("@Nombre" , producto.Nombre),
                new Parametro("@Precio" , producto.Precio),
            };
            bool exito = DBDatos.Ejecutar("Producto_Agregar", parametros);
            return new {
                success = true,
                mensaje = exito ? "exito" : "error al guardar",
                result = ""
            };
        }

    }
}