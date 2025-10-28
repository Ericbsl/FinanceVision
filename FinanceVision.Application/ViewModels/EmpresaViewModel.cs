using System.ComponentModel.DataAnnotations;

namespace FinanceVision.Application.ViewModels;

public class EmpresaViewModel
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O nome/razão social é obrigatório.")]
    [StringLength(150)]
    public string NomeRazaoSocial { get; set; } = string.Empty;

    [StringLength(150)]
    public string? NomeFantasia { get; set; }

    [Required]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "CNPJ inválido.")]
    public string Cnpj { get; set; } = string.Empty;

    [StringLength(20)]
    public string? InscricaoEstadual { get; set; }

    [EmailAddress(ErrorMessage = "E-mail inválido.")]
    [StringLength(100)]
    public string? Email { get; set; }

    public DateTime DataCriado { get; set; } = DateTime.UtcNow;
}
