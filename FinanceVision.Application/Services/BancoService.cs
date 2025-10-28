using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class BancoService : IBancoService
{
    private readonly FinanceVisionDbContext _context;
    public BancoService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<Banco>> GetAllAsync() =>
        await _context.Banco.ToListAsync();

    public async Task<Banco?> GetByIdAsync(long id) =>
        await _context.Banco.FindAsync(id);

    public async Task AddAsync(Banco banco)
    {
        _context.Banco.Add(banco);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Banco banco)
    {
        _context.Banco.Update(banco);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var banco = await _context.Banco.FindAsync(id);
        if (banco != null)
        {
            _context.Banco.Remove(banco);
            await _context.SaveChangesAsync();
        }
    }
}
