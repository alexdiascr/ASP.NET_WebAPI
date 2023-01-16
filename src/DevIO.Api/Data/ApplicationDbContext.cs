using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //quando se tem mais de um contexto é importante dexiar explicito no DbContextOptions qual contexto é
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
