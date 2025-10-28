using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface IPagamentoParcelaService
{
    Task<List<PagamentoParcela>> GetAllAsync();
    Task<PagamentoParcela?> GetByIdAsync(long id);
    Task AddAsync(PagamentoParcela pagamentoParcela);
    Task UpdateAsync(PagamentoParcela pagamentoParcela);
    Task DeleteAsync(long id);
}
