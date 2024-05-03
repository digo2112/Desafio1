using Desafio1.Pagination;
using DesafioDeltaFire.Models;

namespace DesafioDeltaFire.Repositories.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id);

        Task<IEnumerable<Produto>> GetProdutosPorFornecedorAsync(int id);

        Task<IEnumerable<Produto>> GetProdutosPorValidadeAsync(DateOnly data);

        Task<IEnumerable<Produto>> GetProdutosPorCadastroAsync(DateOnly inicio, DateOnly fim);

        Task<PageList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters);

        Task<PageList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtosFiltroParams);

        // Adicione os métodos que você precisa para atualizar um produto
        Task<Produto> GetProdutoById(Guid id);

        // Produto UpdateProduto(Produto produto);
    }
}