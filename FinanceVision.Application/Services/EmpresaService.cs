using FinanceVision.Application.Interfaces;
using FinanceVision.Domain.Entities;
using FinanceVision.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceVision.Application.Services;

public class EmpresaService : IEmpresaService
{
    private readonly FinanceVisionDbContext _context;
    public EmpresaService(FinanceVisionDbContext context)
    {
        _context = context;
    }

    public async Task<List<Empresa>> GetAllAsync() =>
        await _context.Empresa.ToListAsync();

    public async Task<Empresa?> GetByIdAsync(long id) =>
        await _context.Empresa.FindAsync(id);

    public async Task AddAsync(Empresa empresa)
    {
        _context.Empresa.Add(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Empresa empresa)
    {
        _context.Empresa.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var empresa = await _context.Empresa.FindAsync(id);
        if (empresa != null)
        {
            _context.Empresa.Remove(empresa);
            await _context.SaveChangesAsync();
        }
    }
}
