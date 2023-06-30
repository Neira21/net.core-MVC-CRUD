using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
        public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions options) : base(options)
        {
        }
        
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Genero>().Property(g => g.Nombre).HasMaxLength(150);
            
            modelBuilder.Entity<Actor>().Property(g=>g.Nombre).HasMaxLength(150);
            modelBuilder.Entity<Actor>().Property(g=>g.FechaNacimiento).HasColumnType("date");
            modelBuilder.Entity<Actor>().Property(g=>g.Fortuna).HasPrecision(18, 2);

            modelBuilder.Entity<Pelicula>().Property(g=>g.Titulo).HasMaxLength(150);
            modelBuilder.Entity<Pelicula>().Property(g=>g.FechaEstreno).HasColumnType("date");
        }

        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Actor> Actores { get; set; } = null!;
        public DbSet<Genero> Generos { get; set; } = null!;
        public DbSet<Pelicula> Peliculas { get; set; } = null!;
        public DbSet<Comentario> Comentarios { get; set; } = null!;
    }
    
}