namespace PerfumeStore.Domain.Entities;

public class Carrinho
{
    public List<ItemCarrinho> Itens { get; private set; } = new();

    public void AdicionarItem(Produto produto, int qtd)
    {
        produto.BaixarEstoque(qtd);
        Itens.Add(new ItemCarrinho(produto, qtd));
    }

    public decimal Total()
        => Itens.Sum(i => i.Subtotal());
}
