using PerfumeStore.Domain.Entities;

namespace PerfumeStore.Domain.Interfaces;

public interface IProdutoService
{
    Produto Criar(string nome, decimal preco, int estoque);
    List<Produto> Listar();
    Produto? ObterPorId(int id);
}
