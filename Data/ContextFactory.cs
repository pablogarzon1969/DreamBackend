using Data.Context;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class ContextFactory : IDesignTimeDbContextFactory<ContextDB>
    {
        public ContextDB CreateDbContext(string[] args)
        {
            return new ContextDB();
        }
    }
}