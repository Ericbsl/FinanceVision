using System.ComponentModel.DataAnnotations;

namespace FinanceVision.Application.ViewModels;

public class BancoViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O nome do banco é obrigatório.")]
    [StringLength(100)]
    public string NomeBanco { get; set; } = string.Empty;

    [Required(ErrorMessage = "A agência é obrigatória.")]
    [StringLength(10)]
    public string Agencia { get; set; } = string.Empty;

    [Required(ErrorMessage = "A conta é obrigatória.")]
    [StringLength(20)]
    public string Conta { get; set; } = string.Empty;

    [StringLength(20)]
    public string? TipoConta { get; set; }

    [StringLength(150)]
    public string? Titular { get; set; }

    [RegularExpression(@"^\d{11}$|^\d{14}$", ErrorMessage = "CPF ou CNPJ inválido.")]
    public string? CnpjCpfTitular { get; set; }

    public DateTime DataCriado { get; set; } = DateTime.UtcNow;
}
