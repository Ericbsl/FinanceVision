using Microsoft.EntityFrameworkCore;
using FinanceVision.Infrastructure.Data;

namespace FinanceVision.Infrastructure.Factory;

public static class DbContextFactory
{
    public static DbContextOptions<FinanceVisionDbContext> Create(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<FinanceVisionDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return optionsBuilder.Options;
    }
}