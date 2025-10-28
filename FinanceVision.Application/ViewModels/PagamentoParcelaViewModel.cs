using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinanceVision.Domain.Entities;

namespace FinanceVision.Application.ViewModels;

public class PagamentoParcelaViewModel
{
    public long Id { get; set; }

    [Required]
    public int NumeroParcela { get; set; }

    [Required]
    [Range(0.01, 999999999, ErrorMessage = "Valor da parcela deve ser maior que zero.")]
    public decimal ValorParcela { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime DataVencimento { get; set; }

    [DataType(DataType.Date)]
    public DateTime? DataPagamento { get; set; }

    [Required]
    public decimal ValorPago { get; set; }
    [Required]
    public decimal Desconto { get; set; }
    [Required]
    public decimal Juros { get; set; }
    [Required]
    public decimal Multa { get; set; }

    public int? CodBarra { get; set; }

    [Required]
    public long IdPagamento { get; set; }
}
