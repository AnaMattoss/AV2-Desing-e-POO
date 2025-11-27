using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class CarrinhoService : ICarrinhoService
{
    private readonly Carrinho _carrinho = new();
    private readonly IProdutoService _produtoService;

    public CarrinhoService(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    public void AdicionarItem(int produtoId, int qtd)
    {
        var produto = _produtoService.Listar().First(x => x.Id == produtoId);
        _carrinho.AdicionarItem(produto, qtd);
    }

    public Carrinho ObterCarrinho() => _carrinho;
}
