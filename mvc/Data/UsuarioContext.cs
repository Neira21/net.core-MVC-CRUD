using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
        public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Persona> Personas { get; set; } = null!;
    }
    
}