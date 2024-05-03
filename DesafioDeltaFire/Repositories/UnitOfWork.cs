using DesafioDeltaFire.Context;
using DesafioDeltaFire.Repositories.Interfaces;

namespace DesafioDeltaFire.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IProdutoRepository _produtoRepository;
        private IClienteRepository _clienteRepository;
        private IDetalhesVendaRepository _detalhesVendaRepository;
        private IVendaRepository _vendaRepository;

        public UnitOfWork()
        {
        }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository ??= new ProdutoRepository(_context);
            }
        }

        public IClienteRepository ClienteRepository
        {
            get
            {
                return _clienteRepository ??= new ClienteRepository(_context);
            }
        }

        public IDetalhesVendaRepository DetalhesVendaRepository
        {
            get
            {
                return _detalhesVendaRepository ??= new DetalhesVendaRepository(_context);
            }
        }

        public IVendaRepository VendaRepository
        {
            get
            {
                return _vendaRepository ??= new VendaRepository(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}