using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace scaffolding_logueo.Data
{
    public class LogueoContext : IdentityDbContext
    {   
        public LogueoContext(DbContextOptions options) : base (options)
        {
            
        }
    }
}