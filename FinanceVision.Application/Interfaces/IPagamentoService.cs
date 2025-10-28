using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface IPagamentoService
{
    Task<List<Pagamento>> GetAllAsync();
    Task<Pagamento?> GetByIdAsync(long id);
    Task AddAsync(Pagamento pagamento);
    Task UpdateAsync(Pagamento pagamento);
    Task DeleteAsync(long id);
}
