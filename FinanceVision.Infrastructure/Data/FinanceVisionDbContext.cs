using FinanceVision.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Infrastructure.Data;

public class FinanceVisionDbContext : DbContext
{
    public FinanceVisionDbContext(DbContextOptions<FinanceVisionDbContext> options) : base(options) { }

    public DbSet<Empresa> Empresa => Set<Empresa>();

    public DbSet<Banco> Banco => Set<Banco>();

    public DbSet<CategoriaFinanceira> CategoriaFinanceira => Set<CategoriaFinanceira>();

    public DbSet<FormaPagamento> FormaPagamento => Set<FormaPagamento>();

    public DbSet<Pagamento> Pagamento => Set<Pagamento>();

    public DbSet<PagamentoParcela> PagamentoParcela => Set<PagamentoParcela>();
}
