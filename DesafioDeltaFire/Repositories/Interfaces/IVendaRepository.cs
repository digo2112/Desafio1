using Desafio1.Pagination;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Repositories.Interfaces
{

    public interface IVendaRepository : IRepository<Venda>
    {


        Task<IEnumerable<Venda>> GetVendasPorData(DateTime inicio, DateTime fim);
        Task<IEnumerable<Venda>> GetVendasPorNota(int nota);

        Task<PageList<Venda>> GetVendasAsync(VendaParameters VendasParameters);
        Task<IEnumerable<Venda>> GetVendasCliente(Cliente cliente);
        Task<IEnumerable<Venda>> GetVendasPorMes(int mes);
        Task<IEnumerable<Venda>> GetVendasPorAno(int ano);




        // Adicione os métodos que você precisa para atualizar um Venda
        Task<Venda> GetVendaById(Guid id);
        // Venda UpdateVenda(Venda Venda);
    }
}
