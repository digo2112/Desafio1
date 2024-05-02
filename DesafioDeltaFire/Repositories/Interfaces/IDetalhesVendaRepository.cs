using Desafio1.Pagination;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Repositories.Interfaces
{
    public interface IDetalhesVendaRepository : IRepository<DetalhesVenda>
    {
        /*
        Task<IEnumerable<DetalhesVenda>> GetDetalhesVendasPorData(DateTime data);
        Task<IEnumerable<DetalhesVenda>> GetDetalhesVendasPorNota(int nota);
        */
        Task<PageList<DetalhesVenda>> GetDetalhesVendasAsync(DetalhesVendaParameters DetalhesVendasParameters);
        Task<IEnumerable<DetalhesVenda>> GetDetalhesVendasCliente(Cliente cliente);


        // Adicione os métodos que você precisa para atualizar um DetalhesVenda
        Task<DetalhesVenda> GetDetalhesVendaById(Guid id);
        //  DetalhesVenda UpdateDetalhesVenda(DetalhesVenda DetalhesVenda);

    }
}
