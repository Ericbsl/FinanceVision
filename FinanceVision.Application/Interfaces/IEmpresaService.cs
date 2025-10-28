using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface IEmpresaService
{
    Task<List<Empresa>> GetAllAsync();
    Task<Empresa?> GetByIdAsync(long id);
    Task AddAsync(Empresa empresa);
    Task UpdateAsync(Empresa empresa);
    Task DeleteAsync(long id);
}
