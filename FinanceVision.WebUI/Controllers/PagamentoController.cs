using FinanceVision.Application.Interfaces;
using FinanceVision.Application.ViewModels;
using FinanceVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceVision.WebUI.Controllers;

public class PagamentoController : Controller
{
    private readonly IPagamentoService _service;
    private readonly IEmpresaService _empresaService;
    private readonly IBancoService _bancoService;
    private readonly ICategoriaFinanceiraService _categoriaService;
    private readonly IFormaPagamentoService _formaService;

    public PagamentoController(
        IPagamentoService service,
        IEmpresaService empresaService,
        IBancoService bancoService,
        ICategoriaFinanceiraService categoriaService,
        IFormaPagamentoService formaService)
    {
        _service = service;
        _empresaService = empresaService;
        _bancoService = bancoService;
        _categoriaService = categoriaService;
        _formaService = formaService;
    }

    public async Task<IActionResult> Index()
    {
        var pagamentos = await _service.GetAllAsync();

        var model = pagamentos.Select(p => new PagamentoViewModel
        {
            Id = p.Id,
            NumeroDocumento = p.NumeroDocumento,
            IdEmpresa = p.IdEmpresa,
            IdBanco = p.IdBanco,
            IdCategoria = p.IdCategoria,
            IdFormaPgto = p.IdFormaPgto,
            Parcelas = p.Parcelas.Select(x => new PagamentoParcelaViewModel
            {
                Id = x.Id,
                NumeroParcela = x.NumeroParcela,
                ValorParcela = x.ValorParcela,
                DataVencimento = x.DataVencimento,
                DataPagamento = x.DataPagamento,
                ValorPago = x.ValorPago,
                Desconto = x.Desconto,
                Juros = x.Juros,
                Multa = x.Multa,
                CodBarra = x.CodBarra,
                IdPagamento = x.IdPagamento ?? 0
            }).ToList()
        }).ToList();

        return View(model);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Empresas = await _empresaService.GetAllAsync();
        ViewBag.Bancos = await _bancoService.GetAllAsync();
        ViewBag.Categorias = await _categoriaService.GetAllAsync();
        ViewBag.FormasPagamento = await _formaService.GetAllAsync();

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(PagamentoViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Empresas = await _empresaService.GetAllAsync();
            ViewBag.Bancos = await _bancoService.GetAllAsync();
            ViewBag.Categorias = await _categoriaService.GetAllAsync();
            ViewBag.FormasPagamento = await _formaService.GetAllAsync();
            return View(model);
        }

        Console.WriteLine($"IdEmpresa recebido: {model.IdEmpresa}");
        Console.WriteLine($"IdBanco recebido: {model.IdBanco}");
        Console.WriteLine($"IdCategoria recebido: {model.IdCategoria}");
        Console.WriteLine($"IdFormaPgto recebido: {model.IdFormaPgto}");

        var entity = new Pagamento
        {
            NumeroDocumento = model.NumeroDocumento,
            IdEmpresa = model.IdEmpresa,
            IdBanco = model.IdBanco,
            IdCategoria = model.IdCategoria,
            IdFormaPgto = model.IdFormaPgto,
            Parcelas = model.Parcelas?.Select(x => new PagamentoParcela
            {
                NumeroParcela = x.NumeroParcela,
                ValorParcela = x.ValorParcela,
                DataVencimento = x.DataVencimento,
                DataPagamento = x.DataPagamento,
                ValorPago = x.ValorPago,
                Desconto = x.Desconto,
                Juros = x.Juros,
                Multa = x.Multa,
                CodBarra = x.CodBarra
            }).ToList() ?? new List<PagamentoParcela>()
        };

        Console.WriteLine($"Inserindo Pagamento com IdEmpresa: {entity.IdEmpresa}");

        await _service.AddAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var pagamento = await _service.GetByIdAsync(id);
        if (pagamento == null) return NotFound();

        ViewBag.Empresas = await _empresaService.GetAllAsync();
        ViewBag.Bancos = await _bancoService.GetAllAsync();
        ViewBag.Categorias = await _categoriaService.GetAllAsync();
        ViewBag.FormasPagamento = await _formaService.GetAllAsync();

        var vm = new PagamentoViewModel
        {
            Id = pagamento.Id,
            NumeroDocumento = pagamento.NumeroDocumento,
            IdEmpresa = pagamento.IdEmpresa,
            IdBanco = pagamento.IdBanco,
            IdCategoria = pagamento.IdCategoria,
            IdFormaPgto = pagamento.IdFormaPgto,
            Parcelas = pagamento.Parcelas.Select(x => new PagamentoParcelaViewModel
            {
                Id = x.Id,
                NumeroParcela = x.NumeroParcela,
                ValorParcela = x.ValorParcela,
                DataVencimento = x.DataVencimento,
                DataPagamento = x.DataPagamento,
                ValorPago = x.ValorPago,
                Desconto = x.Desconto,
                Juros = x.Juros,
                Multa = x.Multa,
                CodBarra = x.CodBarra,
                IdPagamento = x.IdPagamento ?? 0
            }).ToList()
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PagamentoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Empresas = await _empresaService.GetAllAsync();
            ViewBag.Bancos = await _bancoService.GetAllAsync();
            ViewBag.Categorias = await _categoriaService.GetAllAsync();
            ViewBag.FormasPagamento = await _formaService.GetAllAsync();
            return View(vm);
        }

        var entity = new Pagamento
        {
            Id = vm.Id,
            NumeroDocumento = vm.NumeroDocumento,
            IdEmpresa = vm.IdEmpresa,
            IdBanco = vm.IdBanco,
            IdCategoria = vm.IdCategoria,
            IdFormaPgto = vm.IdFormaPgto,
            Parcelas = vm.Parcelas?.Select(x => new PagamentoParcela
            {
                Id = x.Id,
                NumeroParcela = x.NumeroParcela,
                ValorParcela = x.ValorParcela,
                DataVencimento = x.DataVencimento,
                DataPagamento = x.DataPagamento,
                ValorPago = x.ValorPago,
                Desconto = x.Desconto,
                Juros = x.Juros,
                Multa = x.Multa,
                CodBarra = x.CodBarra,
                IdPagamento = x.IdPagamento
            }).ToList() ?? new List<PagamentoParcela>()
        };

        await _service.UpdateAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
