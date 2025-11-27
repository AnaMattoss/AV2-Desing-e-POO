namespace PerfumeStore.Domain.Entities;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(int id, string nome, decimal preco, int estoque)
    {
        Id = id;
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void BaixarEstoque(int qtd)
    {
        if (qtd <= 0)
            throw new ArgumentException("Quantidade inv�lida.");

        if (qtd > Estoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        Estoque -= qtd;
    }
}
