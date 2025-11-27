using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos = new();
    private int _id = 1;

    public Produto Criar(string nome, decimal preco, int estoque)
    {
        var produto = new Produto(nome, preco, estoque);
        produto.GetType().GetProperty("Id")!.SetValue(produto, _id++);
        _produtos.Add(produto);
        return produto;
    }

    public List<Produto> Listar() => _produtos;
}
