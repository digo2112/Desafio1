using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface ICriarVendaService
    {
        Task<Venda> CriarVenda(VendaDTO vendaDTO);
    }
}