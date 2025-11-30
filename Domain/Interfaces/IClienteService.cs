using PerfumeStore.Domain.Entities;

namespace PerfumeStore.Domain.Interfaces;

public interface IClienteService
{
    Cliente? ObterPorId(int id);
}