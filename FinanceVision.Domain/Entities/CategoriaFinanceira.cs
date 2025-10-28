namespace FinanceVision.Domain.Entities;

public class CategoriaFinanceira
{
    public long Id { get; set; }
    public string NomeCategoria { get; set; } = string.Empty;
    public string Tipo { get; set; } = "DESPESA";
    public string? Descricao { get; set; }
    public DateTime DataCriado { get; set; } = DateTime.UtcNow;

}
