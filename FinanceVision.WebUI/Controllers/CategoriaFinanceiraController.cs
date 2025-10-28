using FinanceVision.Application.Interfaces;
using FinanceVision.Application.ViewModels;
using FinanceVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceVision.WebUI.Controllers;

public class CategoriaFinanceiraController : Controller
{
    private readonly ICategoriaFinanceiraService _service;

    public CategoriaFinanceiraController(ICategoriaFinanceiraService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var categorias = await _service.GetAllAsync();
        var model = categorias.Select(c => new CategoriaFinanceiraViewModel
        {
            Id = c.Id,
            NomeCategoria = c.NomeCategoria,
            Tipo = c.Tipo,
            Descricao = c.Descricao,
            DataCriado = c.DataCriado
        });
        return View(model);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CategoriaFinanceiraViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        await _service.AddAsync(new CategoriaFinanceira
        {
            NomeCategoria = model.NomeCategoria,
            Tipo = model.Tipo,
            Descricao = model.Descricao
        });

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var categoria = await _service.GetByIdAsync(id);
        if (categoria == null) return NotFound();

        var model = new CategoriaFinanceiraViewModel
        {
            Id = categoria.Id,
            NomeCategoria = categoria.NomeCategoria,
            Tipo = categoria.Tipo,
            Descricao = categoria.Descricao
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(CategoriaFinanceiraViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        await _service.UpdateAsync(new CategoriaFinanceira
        {
            Id = model.Id,
            NomeCategoria = model.NomeCategoria,
            Tipo = model.Tipo,
            Descricao = model.Descricao
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
