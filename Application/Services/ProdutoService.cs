using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos = new();
    private int _id = 1;

    public Produto Criar(string nome, decimal preco, int estoque)
    {
        var produto = new Produto(_id++, nome, preco, estoque);
        _produtos.Add(produto);
        return produto;
    }
    
    public Produto? ObterPorId(int id)
    {
        return _produtos.FirstOrDefault(p => p.Id == id);
    }

    public List<Produto> Listar() => _produtos;
}
