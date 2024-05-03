using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services.Interfaces;

namespace DesafioDeltaFire.Services
{
    public class AdicionarDetalheVenda : IAdicionarDetalheVenda
    {
        private readonly IUnitOfWork _unitOfWork;
        // private IUnitOfWork _unitOfWork;

        public AdicionarDetalheVenda(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Venda> AdicionarDetalheVendas(DetalhesVendaDTO detalheVendaDTO)
        {
            // Recuperar a venda existente
            var venda = await _unitOfWork.VendaRepository.GetAsync(v => v.Id == detalheVendaDTO.VendaId);
            if (venda == null)
            {
                throw new Exception($"Venda com id {detalheVendaDTO.VendaId} não encontrada");
            }

            // Recuperar o produto
            var produto = await _unitOfWork.ProdutoRepository.GetAsync(p => p.Id == detalheVendaDTO.ProdutoId);
            if (produto == null)
            {
                throw new Exception($"Produto com id {detalheVendaDTO.ProdutoId} não encontrado");
            }

            // Verificar se a quantidade desejada é maior que a quantidade disponível
            if (detalheVendaDTO.Quantidade > produto.Estoque)
            {
                throw new Exception($"A quantidade desejada do produto {produto.Nome} excede a quantidade disponível em estoque.");
            }

            // Diminuir a quantidade de estoque do produto
            produto.Estoque -= detalheVendaDTO.Quantidade;

            // Atualizar o produto no banco de dados
            _unitOfWork.ProdutoRepository.Update(produto);

            // Criar o novo DetalheVenda
            var detalheVenda = new DetalhesVenda
            {
                ProdutoId = detalheVendaDTO.ProdutoId,
                Quantidade = detalheVendaDTO.Quantidade,
                ValorUnitario = produto.Preco,
                Total = produto.Preco * detalheVendaDTO.Quantidade
            };

            // Adicionar o novo DetalheVenda à Venda
            if (venda.DetalhesVenda == null)
            {
                venda.DetalhesVenda = new List<DetalhesVenda>();
            }
            venda.DetalhesVenda.Add(detalheVenda);

            // Recalcular o total da Venda
            venda.Total += detalheVenda.Total;

            // Salvar as alterações no banco de dados
            await _unitOfWork.CommitAsync();

            return venda;
        }
    }
}