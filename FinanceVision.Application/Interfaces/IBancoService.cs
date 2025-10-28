using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface IBancoService
{
    Task<List<Banco>> GetAllAsync();
    Task<Banco?> GetByIdAsync(long id);
    Task AddAsync(Banco banco);
    Task UpdateAsync(Banco banco);
    Task DeleteAsync(long id);
}
