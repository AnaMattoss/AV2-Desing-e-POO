using PerfumeStore.Domain.Entities;
using PerfumeStore.Domain.Interfaces;

namespace PerfumeStore.Application.Services;

public class ClienteService : IClienteService
{
    private readonly List<Cliente> _clientes = new();

    public ClienteService()
    {
        _clientes.Add(new Cliente(1, "Lucas", "lucas@gmail.com"));
    }

    public Cliente? ObterPorId(int id) => _clientes.FirstOrDefault(c => c.Id == id);
}