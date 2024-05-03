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

        public async Task<IEnumerable<VendaDiaria>> GetVendasDiarias(DateOnly inicio, DateOnly fim)
        {
            var vendas = await _vendaRepository.GetVendasPorData(inicio.ToDateTime(TimeOnly.MinValue), fim.ToDateTime(TimeOnly.MinValue));

            var vendasDiarias = vendas
                .GroupBy(v => v.DataVenda.Date)
                .Select(g => new VendaDiaria
                {
                    Data = g.Key,
                    TotalVendas = g.Sum(v => v.Total)
                });

            return vendasDiarias;
        }

        public async Task<IEnumerable<VendaMensal>> GetVendasMensais(int mes)
        {
            var vendas = await _vendaRepository.GetVendasPorMes(mes);

            var vendasMensais = vendas
                .GroupBy(v => new { v.DataVenda.Year, v.DataVenda.Month })
                .Select(g => new VendaMensal
                {
                    Ano = g.Key.Year,
                    Mes = g.Key.Month,
                    TotalVendas = g.Sum(v => v.Total)
                });

            return vendasMensais;
        }

        public async Task<IEnumerable<ProdutoMaisVendido>> GetProdutosMaisVendidos(DateOnly inicio, DateOnly fim)
        {
            // Convert DateOnly to DateTime
            var inicioDateTime = inicio.ToDateTime(TimeOnly.MinValue);
            var fimDateTime = fim.ToDateTime(TimeOnly.MaxValue);

            // Obter todas as vendas que ocorreram entre as datas de início e fim
            var vendas = await _vendaRepository.GetVendasPorData(inicioDateTime, fimDateTime);

            // Agrupar os detalhes da venda por produto e calcular a quantidade total vendida de cada produto
            var produtosMaisVendidos = vendas
                .SelectMany(v => v.DetalhesVenda)
                .GroupBy(dv => dv.ProdutoId)
                .Select(g => new ProdutoMaisVendido
                {
                    ProdutoId = g.Key,
                    Quantidade = g.Sum(dv => dv.Quantidade)
                })
                .OrderByDescending(p => p.Quantidade)
                .ToList(); // Convert to list

            return produtosMaisVendidos;
        }

        public async Task<IEnumerable<ProdutoMenosVendido>> GetProdutosMenosVendidos(DateOnly inicio, DateOnly fim)
        {
            // Convert DateOnly to DateTime
            var inicioDateTime = inicio.ToDateTime(TimeOnly.MinValue);
            var fimDateTime = fim.ToDateTime(TimeOnly.MaxValue);

            var vendas = await _vendaRepository.GetVendasPorData(inicioDateTime, fimDateTime);

            var produtosMenosVendidos = vendas
                .SelectMany(v => v.DetalhesVenda)
                .GroupBy(dv => dv.ProdutoId)
                .Select(g => new ProdutoMenosVendido
                {
                    Id = g.Key,
                    Quantidade = g.Sum(dv => dv.Quantidade)
                })
                .OrderBy(p => p.Quantidade)
                .ToList(); // Convert to list

            return produtosMenosVendidos;
        }
    }
}