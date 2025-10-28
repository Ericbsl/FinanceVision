using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class FormaPagamentoService : IFormaPagamentoService
{
    private readonly FinanceVisionDbContext _context;
    public FormaPagamentoService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<FormaPagamento>> GetAllAsync() =>
        await _context.FormaPagamento.ToListAsync();

    public async Task<FormaPagamento?> GetByIdAsync(long id) =>
        await _context.FormaPagamento.FindAsync(id);

    public async Task AddAsync(FormaPagamento formaPagamento)
    {
        _context.FormaPagamento.Add(formaPagamento);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FormaPagamento formaPagamento)
    {
        _context.FormaPagamento.Update(formaPagamento);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var formaPagamento = await _context.FormaPagamento.FindAsync(id);
        if (formaPagamento != null)
        {
            _context.FormaPagamento.Remove(formaPagamento);
            await _context.SaveChangesAsync();
        }
    }
}
