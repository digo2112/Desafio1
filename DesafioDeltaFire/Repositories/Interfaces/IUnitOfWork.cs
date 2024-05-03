namespace DesafioDeltaFire.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProdutoRepository ProdutoRepository { get; }
        IClienteRepository ClienteRepository { get; }
        IDetalhesVendaRepository DetalhesVendaRepository { get; }
        IVendaRepository VendaRepository { get; }

        Task CommitAsync();
    }
}