using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly List<Produto> _produtos = new();
    private int _id = 1;

    public ProdutoService()
    {
        // Produtos iniciais para teste
        Criar("Perfume Chanel No 5", 299.90m, 10);
        Criar("Perfume Dior Sauvage", 259.90m, 5);
    }

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
