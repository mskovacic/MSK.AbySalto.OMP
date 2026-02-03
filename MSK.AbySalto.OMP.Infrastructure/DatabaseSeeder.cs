using Microsoft.EntityFrameworkCore;

namespace MSK.AbySalto.OMP.Infrastructure
{
    public static class DatabaseHelper
    {
        public static async Task InitializeAsync(OMPContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
