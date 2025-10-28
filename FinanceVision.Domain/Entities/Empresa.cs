namespace FinanceVision.Domain.Entities;

public class Empresa
{
    public long Id { get; set; }
    public string NomeRazaoSocial { get; set; } = string.Empty;
    public string? NomeFantasia { get; set; }
    public string Cnpj { get; set; } = string.Empty;
    public string? InscricaoEstadual { get; set; }
    public string? Email { get; set; }
    public DateTime DataCriado { get; set; } = DateTime.UtcNow;

}
