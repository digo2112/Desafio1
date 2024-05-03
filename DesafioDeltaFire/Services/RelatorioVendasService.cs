using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services.Interfaces;

namespace DesafioDeltaFire.Services
{
    public class RelatorioVendasService : IRelatorioVendasService
    {
        private readonly IVendaRepository _vendaRepository;

        public RelatorioVendasService(IVendaRepository vendaRepository)
        {
            _vendaRepository = vendaRepository;
        }

        public async Task<IEnumerable<VendaDiaria>> GetVendasDiarias(DateOnly dia)
        {
            var inicioDoDia = dia.ToDateTime(TimeOnly.MinValue);
            var fimDoDia = dia.ToDateTime(TimeOnly.MaxValue);
            var vendas = await _vendaRepository.GetVendasPorData(inicioDoDia, fimDoDia);

            var vendasDiarias = vendas
                .GroupBy(v => v.DataVenda.Date)
                .Select(g => new VendaDiaria
                {
                    Data = g.Key,
                    TotalVendas = g.Count()
                });

            return vendasDiarias;
        }

        public async Task<IEnumerable<VendaMensal>> GetVendasMensais(DateOnly mes)
        {
            var inicioDoMes = new DateOnly(mes.Year, mes.Month, 1).ToDateTime(TimeOnly.MinValue);
            var fimDoMes = inicioDoMes.AddMonths(1).AddTicks(-1);

            var vendas = await _vendaRepository.GetVendasPorData(inicioDoMes, fimDoMes);

            var vendasMensais = vendas
                .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month })
                .Select(g => new VendaMensal
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    TotalVendas = g.Count()
                });

            return vendasMensais;
        }

       

    }
}