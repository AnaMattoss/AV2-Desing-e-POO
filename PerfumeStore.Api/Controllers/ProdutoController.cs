using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Api.DTOs;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Api.Controllers;

[ApiController]
[Route("api/produtos")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutoController(IProdutoService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult Criar(ProdutoDTO dto)
    {
        var produto = _service.Criar(dto.Nome, dto.Preco, dto.Estoque);
        return Ok(produto);
    }

    [HttpGet]
    public IActionResult Listar()
        => Ok(_service.Listar());
}
