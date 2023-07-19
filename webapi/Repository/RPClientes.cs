using System.Diagnostics;
using webapi.Models;

namespace webapi.Repository
{
    public class RPClientes
    {
        public static List<Cliente> _listaClientes = new List<Cliente>()
        {
            new Cliente() { Id = 1, Nombre = "Cliente 1" , Apellidos = "Apellido 1" },
            new Cliente() { Id = 2, Nombre = "Cliente 2" , Apellidos= "Apellido 2" },
            new Cliente() { Id = 3, Nombre = "Cliente 3" , Apellidos = "Apellido 3" }
        };

        public IEnumerable<Cliente> ObtenerClientes()
        {
            return _listaClientes;
        }

        public Cliente ObtenerCliente(int id)
        {
            
            var cliente = _listaClientes.Where(cli => cli.Id == id);
            return cliente.FirstOrDefault();
        }

        public void Agregar(Cliente nuevoCliente)
        {
            _listaClientes.Add(nuevoCliente);
        }

        public void Actualizar(Cliente cliente)
        {
            var clienteExistente = _listaClientes.Where(cli => cli.Id == cliente.Id).FirstOrDefault();
            clienteExistente.Nombre = cliente.Nombre;
            clienteExistente.Apellidos = cliente.Apellidos;
        }

        public void Eliminar(int id)
        {
            var cliente = _listaClientes.Where(cli => cli.Id == id).FirstOrDefault();
            _listaClientes.Remove(cliente);
        }
    }
}