namespace PerfumeStore.Domain.Entities;

public class ItemCarrinho
{
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }

    public ItemCarrinho(Produto produto, int quantidade)
    {
        Produto = produto;
        Quantidade = quantidade;
    }

    public decimal Subtotal() => Produto.Preco * Quantidade;
}
