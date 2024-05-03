using Desafio1.Pagination;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Repositories.Interfaces
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> GetClientesIsAtivoAsync(bool isAtivo);

        Task<IEnumerable<Cliente>> GetClientesPorAniverssario(DateOnly data);

        Task<IEnumerable<Cliente>> GetClientesPorCadastroAsync(DateOnly data);

        Task<PageList<Cliente>> GetClientesAsync(ClienteParameters ClientesParameters);

        Task<IEnumerable<Cliente>> GetClientesFiltroEstadoAsync(string estado);

        // Adicione os métodos que você precisa para atualizar um Cliente
        Task<Cliente> GetClienteById(Guid id);

        // Cliente UpdateCliente(Cliente Cliente);
    }
}