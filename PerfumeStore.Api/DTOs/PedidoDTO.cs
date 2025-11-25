namespace PerfumeStore.Api.DTOs;

public class PedidoDTO
{
    public int ClienteId { get; set; }
    public int TipoPagamento { get; set; } //Forma de pagamento seria cartão ou pix
}