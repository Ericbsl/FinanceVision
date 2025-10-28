using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.Interfaces;

public interface IFormaPagamentoService
{
    Task<List<FormaPagamento>> GetAllAsync();
    Task<FormaPagamento?> GetByIdAsync(long id);
    Task AddAsync(FormaPagamento formaPagamento);
    Task UpdateAsync(FormaPagamento formaPagamento);
    Task DeleteAsync(long id);
}
