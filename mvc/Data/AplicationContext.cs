using System.Reflection;
using Microsoft.EntityFrameworkCore;
using mvc.Models;
using mvc.Models.Seeding;

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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            SeedingInicial.Seed(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(150);
        }

        public DbSet<Persona> Personas { get; set; } = null!;
        public DbSet<Actor> Actores { get; set; } = null!;
        public DbSet<Genero> Generos { get; set; } = null!;
        public DbSet<Pelicula> Peliculas { get; set; } = null!;
        public DbSet<Comentario> Comentarios { get; set; } = null!;
        public DbSet<PeliculaActor> PeliculasActores => Set<PeliculaActor>();



    }
    
}