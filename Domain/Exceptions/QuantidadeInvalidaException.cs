namespace PerfumeStore.Domain.Exceptions;

public class QuantidadeInvalidaException : Exception
{
    public QuantidadeInvalidaException()
        : base("Quantidade inválida.") { }
}
