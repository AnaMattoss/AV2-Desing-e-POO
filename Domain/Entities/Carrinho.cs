namespace PerfumeStore.Domain.Entities;

public class Carrinho
{
    private readonly List<ItemCarrinho> _itens = new();
    public IReadOnlyList<ItemCarrinho> Itens => _itens.AsReadOnly();

    public void AdicionarItem(Produto produto, int qtd)
    {
        produto.BaixarEstoque(qtd);
        _itens.Add(new ItemCarrinho(produto, qtd));
    }

    public decimal Total()
        => _itens.Sum(i => i.Subtotal());
        
    internal void LimparItens()
    {
        _itens.Clear();
    }
}
