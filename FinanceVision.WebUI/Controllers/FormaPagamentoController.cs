using FinanceVision.Application.Interfaces;
using FinanceVision.Application.ViewModels;
using FinanceVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceVision.WebUI.Controllers;

public class FormaPagamentoController : Controller
{
    private readonly IFormaPagamentoService _service;

    public FormaPagamentoController(IFormaPagamentoService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var formas = await _service.GetAllAsync();

        var model = formas.Select(f => new FormaPagamentoViewModel
        {
            Id = f.Id,
            Descricao = f.Descricao,
            PermiteParcelamento = f.PermiteParcelamento,
            DataCriado = f.DataCriado
        });

        return View(model);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(FormaPagamentoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = new FormaPagamento
        {
            Descricao = model.Descricao,
            PermiteParcelamento = model.PermiteParcelamento
        };

        await _service.AddAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var forma = await _service.GetByIdAsync(id);
        if (forma == null) return NotFound();

        var vm = new FormaPagamentoViewModel
        {
            Id = forma.Id,
            Descricao = forma.Descricao,
            PermiteParcelamento = forma.PermiteParcelamento
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(FormaPagamentoViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        await _service.UpdateAsync(new FormaPagamento
        {
            Id = vm.Id,
            Descricao = vm.Descricao,
            PermiteParcelamento = vm.PermiteParcelamento
        });

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Delete(long id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
