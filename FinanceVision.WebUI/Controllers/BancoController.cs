using FinanceVision.Application.Interfaces;
using FinanceVision.Application.ViewModels;
using FinanceVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceVision.WebUI.Controllers;

public class BancoController : Controller
{
    private readonly IBancoService _service;

    public BancoController(IBancoService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var bancos = await _service.GetAllAsync();

        var model = bancos.Select(b => new BancoViewModel
        {
            Id = b.Id,
            NomeBanco = b.NomeBanco,
            Agencia = b.Agencia,
            Conta = b.Conta,
            TipoConta = b.TipoConta,
            Titular = b.Titular,
            CnpjCpfTitular = b.CnpjCpfTitular,
            DataCriado = b.DataCriado
        });

        return View(model);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(BancoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var entity = new Banco
        {
            NomeBanco = model.NomeBanco,
            Agencia = model.Agencia,
            Conta = model.Conta,
            TipoConta = model.TipoConta,
            Titular = model.Titular,
            CnpjCpfTitular = model.CnpjCpfTitular
        };

        await _service.AddAsync(entity);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var banco = await _service.GetByIdAsync(id);
        if (banco == null) return NotFound();

        var model = new BancoViewModel
        {
            Id = banco.Id,
            NomeBanco = banco.NomeBanco,
            Agencia = banco.Agencia,
            Conta = banco.Conta,
            TipoConta = banco.TipoConta,
            Titular = banco.Titular,
            CnpjCpfTitular = banco.CnpjCpfTitular
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(BancoViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _service.UpdateAsync(new Banco
        {
            Id = model.Id,
            NomeBanco = model.NomeBanco,
            Agencia = model.Agencia,
            Conta = model.Conta,
            TipoConta = model.TipoConta,
            Titular = model.Titular,
            CnpjCpfTitular = model.CnpjCpfTitular
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
