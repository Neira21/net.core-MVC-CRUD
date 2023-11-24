dotnet migrations

<!-- borrar basee de datos -->
dotnet ef database drop

<!-- crear nueva migración -->
dotnet ef migrations add NombreMigracion

<!-- eliminar última migración creada -->
dotnet ef migrations remove

<!-- crear/actualizar basee de datos -->
dotnet ef database update

<!-- Herramientas de Entity Framework Core -->
dotnet tool update --global dotnet-ef

<!-- Entity Framework con identity-->
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

<!-- Librerias -->
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.SqlServer

<!-- borrar basee de datos -->



<!-- Actualizar columnas de la tabla useraspnetcore -->

protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Usuario>(EntityTypeBuilder => {
                EntityTypeBuilder.ToTable("Usuarios");
                EntityTypeBuilder.Property(p => p.Nombre).HasMaxLength(50).HasDefaultValue(0);
                EntityTypeBuilder.Property(p => p.Mensaje).HasMaxLength(100).IsRequired();
            });
        }