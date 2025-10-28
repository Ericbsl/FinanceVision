using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class CategoriaFinanceiraService : ICategoriaFinanceiraService
{
    private readonly FinanceVisionDbContext _context;
    public CategoriaFinanceiraService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<CategoriaFinanceira>> GetAllAsync() =>
        await _context.CategoriaFinanceira.ToListAsync();

    public async Task<CategoriaFinanceira?> GetByIdAsync(long id) =>
        await _context.CategoriaFinanceira.FindAsync(id);

    public async Task AddAsync(CategoriaFinanceira categoriaFinanceira)
    {
        _context.CategoriaFinanceira.Add(categoriaFinanceira);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CategoriaFinanceira categoriaFinanceira)
    {
        _context.CategoriaFinanceira.Update(categoriaFinanceira);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var categoriaFinanceira = await _context.CategoriaFinanceira.FindAsync(id);
        if (categoriaFinanceira != null)
        {
            _context.CategoriaFinanceira.Remove(categoriaFinanceira);
            await _context.SaveChangesAsync();
        }
    }
}
