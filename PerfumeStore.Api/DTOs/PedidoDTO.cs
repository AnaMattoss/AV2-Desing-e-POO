namespace PerfumeStore.Api.DTOs;

public class PedidoDTO
{
    public int ClienteId { get; set; }
    public string TipoPagamento { get; set; } // "cartao" ou "pix"
}
