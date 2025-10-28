using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface ICategoriaFinanceiraService
{
    Task<List<CategoriaFinanceira>> GetAllAsync();
    Task<CategoriaFinanceira?> GetByIdAsync(long id);
    Task AddAsync(CategoriaFinanceira categoriaFinanceira);
    Task UpdateAsync(CategoriaFinanceira categoriaFinanceira);
    Task DeleteAsync(long id);
}
