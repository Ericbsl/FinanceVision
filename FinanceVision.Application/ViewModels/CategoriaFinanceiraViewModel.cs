using System.ComponentModel.DataAnnotations;

namespace FinanceVision.Application.ViewModels;

public class CategoriaFinanceiraViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(100)]
    public string NomeCategoria { get; set; } = string.Empty;

    [Required]
    [RegularExpression("^(DESPESA|RECEITA)$", ErrorMessage = "Tipo deve ser DESPESA ou RECEITA.")]
    public string Tipo { get; set; } = "DESPESA";

    [StringLength(255)]
    public string? Descricao { get; set; }

    public DateTime DataCriado { get; set; } = DateTime.UtcNow;
}
