using PerfumeStore.Domain.Entities;

namespace PerfumeStore.Domain.Interfaces;

public interface IPedidoService
{
    Pedido Finalizar(int clienteId, string tipoPagamento);
}
