using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using FinanceVision.Infrastructure.Data;

namespace FinanceVision.Infrastructure.Factory
{
    public class DesignTimeFinanceVisionDbContextFactory : IDesignTimeDbContextFactory<FinanceVisionDbContext>
    {
        public FinanceVisionDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost;Database=financevision;Trusted_Connection=True;TrustServerCertificate=True;";

            var options = DbContextFactory.Create(connectionString);
            
            return new FinanceVisionDbContext(options);
        }
    }
}
