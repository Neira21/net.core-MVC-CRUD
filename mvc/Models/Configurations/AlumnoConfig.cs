using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mvc.Models.Configurations
{
    public class AlumnoConfig : IEntityTypeConfiguration<Alumno>
    {
        public void Configure(EntityTypeBuilder<Alumno> builder)
        {
            builder.Property(g=>g.Contraseña).HasMaxLength(20).IsRequired();
            builder.Property(g=>g.Usuario).HasMaxLength(50).IsRequired();
        }
    }
}