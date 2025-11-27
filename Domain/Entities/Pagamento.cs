namespace PerfumeStore.Domain.Entities;

public abstract class Pagamento
{
    public decimal Valor { get; protected set; }
    public abstract bool Processar();
}

public class PagamentoPix : Pagamento
{
    public override bool Processar() => true;
}

public class PagamentoCartao : Pagamento
{
    public override bool Processar() => true;
}
