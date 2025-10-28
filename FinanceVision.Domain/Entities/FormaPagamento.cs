namespace FinanceVision.Domain.Entities;

public class FormaPagamento
{
    public long Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public bool PermiteParcelamento { get; set; }
    public DateTime DataCriado { get; set; } = DateTime.UtcNow;

}
