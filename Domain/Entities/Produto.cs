namespace PerfumeStore.Domain.Entities;

public class Produto
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public decimal Preco { get; private set; }
    public int Estoque { get; private set; }

    public Produto(string nome, decimal preco, int estoque)
    {
        Nome = nome;
        Preco = preco;
        Estoque = estoque;
    }

    public void BaixarEstoque(int qtd)
    {
        if (qtd <= 0)
            throw new ArgumentException("Quantidade inválida.");

        if (qtd > Estoque)
            throw new InvalidOperationException("Estoque insuficiente.");

        Estoque -= qtd;
    }
}
