using PerfumeStore.Domain.Entities;

namespace PerfumeStore.Domain.Interfaces;

public interface ICarrinhoService
{
    void AdicionarItem(int produtoId, int quantidade);
    Carrinho ObterCarrinho();
    void LimparCarrinho();
}
