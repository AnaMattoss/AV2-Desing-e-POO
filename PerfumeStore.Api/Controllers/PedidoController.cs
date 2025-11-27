using Microsoft.AspNetCore.Mvc;
using PerfumeStore.Api.DTOs;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Api.Controllers;

[ApiController]
[Route("api/pedidos")]
public class PedidoController : ControllerBase
{
    private readonly IPedidoService _service;

    public PedidoController(IPedidoService service)
    {
        _service = service;
    }

    [HttpPost("finalizar")]
    public IActionResult Finalizar(PedidoDTO dto)
    {
        var pedido = _service.Finalizar(dto.ClienteId, dto.TipoPagamento);
        return Ok(pedido);
    }
}
