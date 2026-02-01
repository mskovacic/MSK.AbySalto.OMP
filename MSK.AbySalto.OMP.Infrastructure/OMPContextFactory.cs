using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MSK.AbySalto.OMP.Infrastructure
{
    public class OMPContextFactory : IDesignTimeDbContextFactory<OMPContext>
    {
        public OMPContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<OMPContext>();
            optionsBuilder.UseNpgsql("webshopdb");

            return new OMPContext(optionsBuilder.Options);
        }
    }
}
