using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MSK.AbySalto.OMP.Infrastructure
{
    public class OMPContext(DbContextOptions<OMPContext> options) : IdentityDbContext(options)
    {
    }
}
