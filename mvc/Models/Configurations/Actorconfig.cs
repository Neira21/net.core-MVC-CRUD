using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace mvc.Models.Configurations
{
    public class ActorConfig
    {
        public class PeliculaConfig : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(g=>g.FechaNacimiento).HasColumnType("date");
            builder.Property(g=>g.Fortuna).HasPrecision(18, 2);
        }
    }
    }
}