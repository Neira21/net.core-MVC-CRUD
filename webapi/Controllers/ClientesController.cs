using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Models;



namespace webapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ConfigurationContext _context;
        public ClientesController(ConfigurationContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }





        // [HttpGet]
        // public IActionResult Get()
        // {
        //     RPClientes rpCli = new RPClientes();
        //     return Ok(rpCli.ObtenerClientes());
        // }

        // [HttpGet("{id}")]
        // public IActionResult Get(int id)
        // {
        //     RPClientes rpCli = new RPClientes();

        //     var cliRet = rpCli.ObtenerCliente(id);

        //     if (cliRet == null)
        //     {
        //         var nf = NotFound("El cliente " + id.ToString() + " no existe.");
        //         return nf;
        //     }

        //     return Ok(cliRet);
        // }

        // [HttpPost("agregar")]
        // public IActionResult AgregarCliente(Cliente nuevoCliente)
        // {
        //     RPClientes rpCli = new RPClientes();
        //     rpCli.Agregar(nuevoCliente);
        //     return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        // }

        // [HttpPut("actualizar")]
        // public IActionResult ActualizarCliente(Cliente cliente)
        // {
        //     RPClientes rpCli = new RPClientes();
        //     rpCli.Actualizar(cliente);
        //     return Ok(cliente);
        // }

        // [HttpDelete("eliminar/{id}")]
        // public IActionResult EliminarCliente(int id)
        // {
        //     RPClientes rpCli = new RPClientes();
        //     rpCli.Eliminar(id);
        //     return Ok();
        // }
    }
}