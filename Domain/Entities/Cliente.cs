namespace PerfumeStore.Domain.Entities;

public class Cliente
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }

    public Cliente(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }
}
