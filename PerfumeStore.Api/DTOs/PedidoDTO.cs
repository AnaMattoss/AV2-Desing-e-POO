namespace PerfumeStore.Api.DTOs;

public class PedidoDTO
{
    public int ClienteId { get; set; }
    public required string TipoPagamento { get; set; } //cartao ou pix
}
