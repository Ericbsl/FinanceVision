using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class PagamentoParcelaService : IPagamentoParcelaService
{
    private readonly FinanceVisionDbContext _context;
    public PagamentoParcelaService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<PagamentoParcela>> GetAllAsync() =>
        await _context.PagamentoParcela.ToListAsync();

    public async Task<PagamentoParcela?> GetByIdAsync(long id) =>
        await _context.PagamentoParcela.FindAsync(id);

    public async Task AddAsync(PagamentoParcela pagamentoParcela)
    {
        _context.PagamentoParcela.Add(pagamentoParcela);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PagamentoParcela pagamentoParcela)
    {
        _context.PagamentoParcela.Update(pagamentoParcela);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var pagamentoParcela = await _context.PagamentoParcela.FindAsync(id);
        if (pagamentoParcela != null)
        {
            _context.PagamentoParcela.Remove(pagamentoParcela);
            await _context.SaveChangesAsync();
        }
    }
}
