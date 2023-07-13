Para el scaffolding para la base de datos se utilizó el siguiente comando:

dotnet ef dbcontext scaffold "Server=DESKTOP-8OAHJGT;Database=BD_Nota_FHPA;Trusted_Connection=True; TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models


Para el identity se utilizó la siguiente librería
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 7.0.9