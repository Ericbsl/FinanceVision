using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class PagamentoService : IPagamentoService
{
    private readonly FinanceVisionDbContext _context;
    public PagamentoService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<Pagamento>> GetAllAsync() =>
        await _context.Pagamento.ToListAsync();

    public async Task<Pagamento?> GetByIdAsync(long id) =>
        await _context.Pagamento.FindAsync(id);

    public async Task AddAsync(Pagamento pagamento)
    {
        _context.Entry(pagamento).State = EntityState.Added;

        if (pagamento.Empresa != null)
            _context.Entry(pagamento.Empresa).State = EntityState.Unchanged;
        if (pagamento.Banco != null)
            _context.Entry(pagamento.Banco).State = EntityState.Unchanged;
        if (pagamento.Categoria != null)
            _context.Entry(pagamento.Categoria).State = EntityState.Unchanged;
        if (pagamento.FormaPagamento != null)
            _context.Entry(pagamento.FormaPagamento).State = EntityState.Unchanged;

        if (pagamento.Parcelas != null && pagamento.Parcelas.Any())
        {
            foreach (var parcela in pagamento.Parcelas)
            {
                _context.Entry(parcela).State = EntityState.Added;
            }
        }

        await _context.Pagamento.AddAsync(pagamento);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(Pagamento pagamento)
    {
        _context.Pagamento.Update(pagamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var pagamento = await _context.Pagamento.FindAsync(id);
        if (pagamento != null)
        {
            _context.Pagamento.Remove(pagamento);
            await _context.SaveChangesAsync();
        }
    }
}
