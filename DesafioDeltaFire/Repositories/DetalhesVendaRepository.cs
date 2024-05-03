using Desafio1.Pagination;
using DesafioDeltaFire.Context;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDeltaFire.Repositories
{
    public class DetalhesVendaRepository : Repository<DetalhesVenda>, IDetalhesVendaRepository
    {
        public DetalhesVendaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<PageList<DetalhesVenda>> GetDetalhesVendasAsync(DetalhesVendaParameters detalhesVendasParameters)
        {
            var detalhesVendas = await GetAllAsync();
            return PageList<DetalhesVenda>.ToPagedList(detalhesVendas.AsQueryable(), detalhesVendasParameters.PageNumber, detalhesVendasParameters.PageSize);
        }

        public async Task<IEnumerable<DetalhesVenda>> GetDetalhesVendasCliente(Cliente cliente)
        {
            return await _context.DetalhesVenda.Where(dv => dv.Id == cliente.Id).ToListAsync();
        }

        public async Task<DetalhesVenda> GetDetalhesVendaById(Guid id)
        {
            return await _context.DetalhesVenda.FindAsync(id);
        }
    }
}