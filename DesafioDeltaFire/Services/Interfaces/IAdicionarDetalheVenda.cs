using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface IAdicionarDetalheVenda
    {
        Task<Venda> AdicionarDetalheVendas(DetalhesVendaDTO detalhesVendaDTO);
    }
}