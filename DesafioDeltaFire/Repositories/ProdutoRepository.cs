using Desafio1.Pagination;
using DesafioDeltaFire.Context;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DesafioDeltaFire.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorCategoriaAsync(int id)
        {
            return _context.Produtos != null
                ? await _context.Produtos.Where(p => p.Categoria == id).ToListAsync()
                : new List<Produto>();
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorFornecedorAsync(int fornecedor)
        {
            return _context.Produtos != null
                ? await _context.Produtos.Where(p => p.Fornecedor == fornecedor).ToListAsync()
                : new List<Produto>();
        }

        public async Task<PageList<Produto>> GetProdutosAsync(ProdutosParameters produtosParameters)
        {
            var produtos = await GetAllAsync();
            return PageList<Produto>.ToPagedList(produtos.AsQueryable(), produtosParameters.PageNumber, produtosParameters.PageSize);
        }

        public async Task<PageList<Produto>> GetProdutosFiltroPrecoAsync(ProdutosFiltroPreco produtosFiltroParams)
        {
            var produtos = await GetAllAsync();

            if (produtosFiltroParams.Preco.HasValue)
            {
                if (produtosFiltroParams.PrecoCriterio == "maior")
                {
                    produtos = produtos.Where(p => p.Preco > produtosFiltroParams.Preco.Value);
                }
                else if (produtosFiltroParams.PrecoCriterio == "menor")
                {
                    produtos = produtos.Where(p => p.Preco < produtosFiltroParams.Preco.Value);
                }
                else if (produtosFiltroParams.PrecoCriterio == "igual")
                {
                    produtos = produtos.Where(p => p.Preco == produtosFiltroParams.Preco.Value);
                }
            }

            return PageList<Produto>.ToPagedList(produtos.AsQueryable(), produtosFiltroParams.PageNumber, produtosFiltroParams.PageSize);
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorValidadeAsync(DateOnly data)
        {
            // Retorna produtos cuja data de validade é igual à data fornecida
            return await _context.Produtos.Where(p => p.DataValidade == data).ToListAsync();
        }

        public async Task<IEnumerable<Produto>> GetProdutosPorCadastroAsync(DateOnly inicio, DateOnly fim)
        {
            // Retorna produtos cuja data de cadastro está entre as datas de início e fim fornecidas
            return await _context.Produtos.Where(p => p.DataCadastro >= inicio && p.DataCadastro <= fim).ToListAsync();
        }

        public async Task<Produto> GetProdutoById(Guid id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }
    }
}