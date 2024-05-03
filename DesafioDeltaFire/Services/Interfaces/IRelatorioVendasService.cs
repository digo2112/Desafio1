using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface IRelatorioVendasService
    {
        Task<IEnumerable<VendaDiaria>> GetVendasDiarias(DateOnly dia);

        Task<IEnumerable<VendaMensal>> GetVendasMensais(DateOnly mes);

   
    }
}