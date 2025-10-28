namespace FinanceVision.Domain.Entities;

public class Banco
{
    
    public long Id { get; set; }
    public string NomeBanco { get; set; } = string.Empty;
    public string Agencia { get; set; } = string.Empty;
    public string Conta { get; set; } = string.Empty;
    public string? TipoConta { get; set; }
    public string? Titular { get; set; }
    public string? CnpjCpfTitular { get; set; }
    public DateTime DataCriado { get; set; } = DateTime.UtcNow;
    
}