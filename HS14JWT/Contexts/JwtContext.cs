using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HS14JWT.Contexts;

public class JwtContext:IdentityDbContext
{
    public JwtContext(DbContextOptions<JwtContext>options): base (options)  

    {
        
    }



}
