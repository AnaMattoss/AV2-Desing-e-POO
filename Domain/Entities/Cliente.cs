namespace PerfumeStore.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
    }
}
