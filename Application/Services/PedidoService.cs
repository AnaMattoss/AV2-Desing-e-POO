using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly ICarrinhoService _carrinhoService;
    private readonly IClienteService _clienteService;
    private int _id = 1;

    public PedidoService(ICarrinhoService carrinhoService, IClienteService clienteService)
    {
        _carrinhoService = carrinhoService;
        _clienteService = clienteService;
    }

    public Pedido Finalizar(int clienteId, string tipoPagamento)
    {
        var cliente = _clienteService.ObterPorId(clienteId);
        if (cliente == null)
            throw new ArgumentException("Cliente não encontrado.");
            
        var carrinho = _carrinhoService.ObterCarrinho();
        if (!carrinho.Itens.Any())
            throw new InvalidOperationException("Carrinho vazio.");

        Pagamento pagamento = tipoPagamento.ToLower() switch
        {
            "pix" => new PagamentoPix(),
            "cartao" => new PagamentoCartao(),
            _ => throw new ArgumentException("Tipo de pagamento inválido")
        };

        var pedido = new Pedido(_id++, cliente, carrinho, pagamento);
        _carrinhoService.LimparCarrinho();
        return pedido;
    }
}