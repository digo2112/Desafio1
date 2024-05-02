using Desafio1.Pagination;
using DesafioDeltaFire.Context;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioDeltaFire.Repositories
{

    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> GetClientesIsAtivoAsync(bool isAtivo)
        {
            return await _context.Cliente.Where(c => c.IsAtivo == isAtivo).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientesPorAniverssario(DateOnly data)
        {
            return await _context.Cliente.Where(c => c.DataNascimento == data).ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClientesPorCadastroAsync(DateOnly data)
        {
            return await _context.Cliente.Where(c => c.DataCadastro == data).ToListAsync();
        }


        //var clientes = _context.Cliente.AsQueryable();
        public async Task<PageList<Cliente>> GetClientesAsync(ClienteParameters clientesParameters)
        {
            var clientes = await GetAllAsync();
            return PageList<Cliente>.ToPagedList(clientes.AsQueryable(), clientesParameters.PageNumber, clientesParameters.PageSize);
        }


        public async Task<IEnumerable<Cliente>> GetClientesFiltroEstadoAsync(string estado)
        {
            return await _context.Cliente.Where(c => c.Estado == estado).ToListAsync();
        }

        public async Task<Cliente> GetClienteById(Guid id)
        {
            return await _context.Cliente.FindAsync(id);
        }

    }
}
