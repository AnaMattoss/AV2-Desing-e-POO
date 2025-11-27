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

        //teste
        _clientes.Add(new Cliente("Lucas", "lucas@gmail.com"));
    }

    public Pedido Finalizar(int clienteId, string tipoPagamento)
    {
        var cliente = _clientes.First(c => c.Id == clienteId);
        var carrinho = _carrinho.ObterCarrinho();

        Pagamento pagamento = tipoPagamento.ToLower() switch
        {
            "pix" => new PagamentoPix(),
            "cartao" => new PagamentoCartao(),
            _ => throw new Exception("Tipo de pagamento inválido")
        };

        var pedido = new Pedido(cliente, carrinho, pagamento);

        pedido.GetType().GetProperty("Id")!.SetValue(pedido, _id++);

        return pedido;
    }
}
