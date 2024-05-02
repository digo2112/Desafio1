using DesafioDeltaFire.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioDeltaFire.Services.Interfaces
{
    public interface IRelatorioVendasService
    {
        Task<IEnumerable<VendaDiaria>> GetVendasDiarias(DateOnly inicio, DateOnly fim);
        Task<IEnumerable<VendaMensal>> GetVendasMensais(int mes);
        Task<IEnumerable<ProdutoMaisVendido>> GetProdutosMaisVendidos(DateOnly inicio, DateOnly fim);
        Task<IEnumerable<ProdutoMenosVendido>> GetProdutosMenosVendidos(DateOnly inicio, DateOnly fim);
    }
}