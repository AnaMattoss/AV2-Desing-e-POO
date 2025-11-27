using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class PedidoService : IPedidoService
{
    private readonly ICarrinhoService _carrinho;
    private readonly List<Cliente> _clientes = new();
    private int _id = 1;

    public PedidoService(ICarrinhoService carrinho)
    {
        _carrinho = carrinho;

        // Cliente de teste
        _clientes.Add(new Cliente(1, "Lucas", "lucas@gmail.com"));
    }

    public Pedido Finalizar(int clienteId, string tipoPagamento)
    {
        var cliente = _clientes.FirstOrDefault(c => c.Id == clienteId);
        if (cliente == null)
            throw new ArgumentException("Cliente não encontrado.");
            
        var carrinho = _carrinho.ObterCarrinho();
        if (!carrinho.Itens.Any())
            throw new InvalidOperationException("Carrinho vazio.");

        Pagamento pagamento = tipoPagamento.ToLower() switch
        {
            "pix" => new PagamentoPix(),
            "cartao" => new PagamentoCartao(),
            _ => throw new ArgumentException("Tipo de pagamento inválido")
        };

        var pedido = new Pedido(_id++, cliente, carrinho, pagamento);
        return pedido;
    }
}