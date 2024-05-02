using DesafioDeltaFire.Models;
using System.Threading.Tasks;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface IVendaService
    {
        Task RegistrarVendaAsync(Venda venda);
    }
}