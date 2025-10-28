using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceVision.Domain.Entities;

public class Pagamento
{
    public long Id { get; set; }

    public string NumeroDocumento { get; set; } = string.Empty;
    public DateTime DataCriado { get; set; } = DateTime.UtcNow;

    [ForeignKey(nameof(Empresa))]
    public long IdEmpresa { get; set; }
    public Empresa Empresa { get; set; } = null!;

    [ForeignKey(nameof(Banco))]
    public long? IdBanco { get; set; }
    public Banco? Banco { get; set; }

    [ForeignKey(nameof(Categoria))]
    public long? IdCategoria { get; set; }
    public CategoriaFinanceira? Categoria { get; set; }

    [ForeignKey(nameof(FormaPagamento))]
    public long? IdFormaPgto { get; set; }
    public FormaPagamento? FormaPagamento { get; set; }

    public ICollection<PagamentoParcela> Parcelas { get; set; } = new List<PagamentoParcela>();
}
