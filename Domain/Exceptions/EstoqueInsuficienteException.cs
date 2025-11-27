namespace PerfumeStore.Domain.Exceptions;

public class EstoqueInsuficienteException : Exception
{
    public EstoqueInsuficienteException()
        : base("Estoque insuficiente.") { }
}
