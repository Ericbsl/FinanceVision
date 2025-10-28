using System.ComponentModel.DataAnnotations;

namespace FinanceVision.Application.ViewModels;

public class FormaPagamentoViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Descricao { get; set; } = string.Empty;

    [Required]
    public bool PermiteParcelamento { get; set; }

    public DateTime DataCriado { get; set; } = DateTime.UtcNow;
}
