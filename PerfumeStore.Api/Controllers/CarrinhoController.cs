using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Api.DTOs;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Api.Controllers;

[ApiController]
[Route("api/carrinho")]
public class CarrinhoController : ControllerBase
{
    private readonly ICarrinhoService _service;

    public CarrinhoController(ICarrinhoService service)
    {
        _service = service;
    }

    [HttpPost("adicionar")]
    public IActionResult Adicionar(ItemCarrinhoDTO dto)
    {
        _service.AdicionarItem(dto.ProdutoId, dto.Quantidade);
        return Ok("Item adicionado.");
    }

    [HttpGet]
    public IActionResult VerCarrinho()
        => Ok(_service.ObterCarrinho());
}
