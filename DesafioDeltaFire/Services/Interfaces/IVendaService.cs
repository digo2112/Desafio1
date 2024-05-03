using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface IVendaService
    {
        Task RegistrarVendaAsync(Venda venda);
    }
}