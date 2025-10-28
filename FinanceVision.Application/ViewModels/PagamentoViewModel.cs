using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.ViewModels;

public class PagamentoViewModel
{
    public long Id { get; set; }

    [Required]
    [StringLength(50)]
    public string NumeroDocumento { get; set; } = string.Empty;

    [Required]
    public long IdEmpresa { get; set; }

    public long? IdBanco { get; set; }
    public long? IdCategoria { get; set; }
    public long? IdFormaPgto { get; set; }

    public List<PagamentoParcelaViewModel> Parcelas { get; set; } = new();
}
