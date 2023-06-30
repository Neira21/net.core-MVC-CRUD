"DefaultConnection": "Server=DESKTOP-8OAHJGT;Database=BD-PROYECTO2;Integrated Security=True; TrustServerCertificate=True"

Paso 2: Añadir dependencias:
 Microsoft.EntityFrameworkCore (para usar EF)
 Microsoft.EntityFrameworkCore.Design (para usar Migraciones de EF)
 Microsoft.EntityFrameworkCore.SqlServer (para usar SQL Server)
Paso 3: Definir la clase Context (y que herede DbContext)

Paso 5: Mantener la BD actualizada a través de las migraciones:
dotnet tool install --global dotnet-ef (para habilitar el comando dotnet ef)
dotnet ef migrations add [nombre de migración] (crea una migración)
dotnet ef database update (ejecuta las migraciones pendientes)


services.AddIdentity<IdentityUser, IdentityRole>()
 .AddEntityFrameworkStores<ClaseContext>()
 .AddDefaultTokenProviders();
app.UseAuthentication();


dotnet ef migrations add Inicial
dotnet ef remove migrations

dotnet ef database update
dotnet ef database drop
