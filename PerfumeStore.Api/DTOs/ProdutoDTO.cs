namespace PerfumeStore.Api.DTOs;

public class ProdutoDTO
{
    public required string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}