using Desafio1.Pagination;
using DesafioDeltaFire.Context;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDeltaFire.Repositories
{
    public class VendaRepository : Repository<Venda>, IVendaRepository
    {
        public VendaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Venda>> GetVendasPorData(DateTime inicio, DateTime fim)
        {
            return await _context.Venda.Where(v => v.DataVenda >= inicio && v.DataVenda <= fim).ToListAsync();
        }
        public async Task<IEnumerable<Venda>> GetVendasPorNota(int nota)
        {
            return await _context.Venda.Where(v => v.NotaFiscal == nota).ToListAsync();
        }

        public async Task<PageList<Venda>> GetVendasAsync(VendaParameters vendasParameters)
        {
            var vendas = await GetAllAsync();
            return PageList<Venda>.ToPagedList(vendas.AsQueryable(), vendasParameters.PageNumber, vendasParameters.PageSize);
        }

        public async Task<IEnumerable<Venda>> GetVendasCliente(Cliente cliente)
        {
            return await _context.Venda.Where(v => v.Id == cliente.Id).ToListAsync();
        }

        public async Task<Venda> GetVendaById(Guid id)
        {
            return await _context.Venda.FindAsync(id);
        }

        public async Task<IEnumerable<Venda>> GetVendasPorMes(int mes)
        {
            return await _context.Venda.Where(v => v.DataVenda.Month == mes).ToListAsync();
        }

        public async Task<IEnumerable<Venda>> GetVendasPorAno(int ano)
        {
            return await _context.Venda.Where(v => v.DataVenda.Year == ano).ToListAsync();
        }
    }
}