namespace PerfumeStore.Domain.Entities;

public class Pedido
{
    public int Id { get; private set; }
    public Cliente Cliente { get; private set; }
    public Carrinho Carrinho { get; private set; }
    public Pagamento Pagamento { get; private set; }
    public decimal TotalFinal { get; private set; }

    public Pedido(int id, Cliente cliente, Carrinho carrinho, Pagamento pagamento)
    {
        Id = id;
        Cliente = cliente;
        Carrinho = carrinho;
        Pagamento = pagamento;

        TotalFinal = carrinho.Total();
        pagamento.DefinirValor(TotalFinal);

        pagamento.Processar();
    }
}
