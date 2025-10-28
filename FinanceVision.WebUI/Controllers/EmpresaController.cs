using FinanceVision.Application.Interfaces;
using FinanceVision.Application.ViewModels;
using FinanceVision.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FinanceVision.WebUI.Controllers;

public class EmpresaController : Controller
{
    private readonly IEmpresaService _service;

    public EmpresaController(IEmpresaService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var empresas = await _service.GetAllAsync();
        return View(empresas.Select(q => new EmpresaViewModel
        {
            Id = q.Id,
            NomeRazaoSocial = q.NomeRazaoSocial,
            NomeFantasia = q.NomeFantasia,
            Cnpj = q.Cnpj,
            InscricaoEstadual = q.InscricaoEstadual,
            Email = q.Email,
            DataCriado = q.DataCriado
        }));
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(EmpresaViewModel c)
    {
        if (!ModelState.IsValid) return View(c);

        await _service.AddAsync(new Empresa
        {
            NomeRazaoSocial = c.NomeRazaoSocial,
            NomeFantasia = c.NomeFantasia,
            Cnpj = c.Cnpj,
            InscricaoEstadual = c.InscricaoEstadual,
            Email = c.Email
        });

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var empresa = await _service.GetByIdAsync(id);
        if (empresa == null) return NotFound();

        var vm = new EmpresaViewModel
        {
            Id = empresa.Id,
            NomeRazaoSocial = empresa.NomeRazaoSocial,
            NomeFantasia = empresa.NomeFantasia,
            Cnpj = empresa.Cnpj,
            InscricaoEstadual = empresa.InscricaoEstadual,
            Email = empresa.Email
        };

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmpresaViewModel vm)
    {
        if (!ModelState.IsValid) return View(vm);

        await _service.UpdateAsync(new Empresa
        {
            Id = vm.Id,
            NomeRazaoSocial = vm.NomeRazaoSocial,
            NomeFantasia = vm.NomeFantasia,
            Cnpj = vm.Cnpj,
            InscricaoEstadual = vm.InscricaoEstadual,
            Email = vm.Email
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
