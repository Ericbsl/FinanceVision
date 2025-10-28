using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceVision.Domain.Entities;

public class PagamentoParcela
{
    public long Id { get; set; }
    public int NumeroParcela { get; set; }
    public decimal ValorParcela { get; set; }
    public DateTime DataVencimento { get; set; }
    public DateTime? DataPagamento { get; set; }

    public decimal ValorPago { get; set; }
    public decimal Desconto { get; set; }
    public decimal Juros { get; set; }
    public decimal Multa { get; set; }

    public int? CodBarra { get; set; }

    [ForeignKey(nameof(Pagamento))]
    public long? IdPagamento { get; set; }
    public Pagamento? Pagamento { get; set; }
}
