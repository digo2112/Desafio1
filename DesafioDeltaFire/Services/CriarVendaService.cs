using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services.Interfaces;

namespace DesafioDeltaFire.Services
{
    public class CriarVendaService : ICriarVendaService
    {

        private readonly IUnitOfWork _unitOfWork;

        public CriarVendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Venda> CriarVenda(VendaDTO vendaDTO)
        {
            var venda = new Venda
            {
                ClienteId = vendaDTO.ClienteId,
                DataVenda = vendaDTO.DataVenda,
                NotaFiscal = vendaDTO.NotaFiscal,
                DetalhesVenda = new List<DetalhesVenda>()
            };

            decimal total = 0;

            foreach (var detalhesVendaDTO in vendaDTO.DetalhesVenda)
            {
                var produto = await _unitOfWork.ProdutoRepository.GetAsync(p => p.Id == detalhesVendaDTO.ProdutoId);
                if (produto == null)
                {
                    throw new Exception($"Produto com id {detalhesVendaDTO.ProdutoId} não encontrado");
                }

                // Verificar se a quantidade desejada é maior que a quantidade disponível
                if (detalhesVendaDTO.Quantidade > produto.Estoque)
                {
                    throw new Exception($"A quantidade desejada do produto {produto.Nome} excede a quantidade disponível em estoque.");
                }

                // Diminuir a quantidade de estoque do produto
                produto.Estoque -= detalhesVendaDTO.Quantidade;

                // Atualizar o produto no banco de dados
                _unitOfWork.ProdutoRepository.Update(produto);
                var detalhesVenda = new DetalhesVenda
                {
                    ProdutoId = detalhesVendaDTO.ProdutoId,
                    Quantidade = detalhesVendaDTO.Quantidade,
                    ValorUnitario = produto.Preco,
                    Total = produto.Preco * detalhesVendaDTO.Quantidade
                };

                total += detalhesVenda.Total;

                venda.DetalhesVenda.Add(detalhesVenda);
            }

            venda.Total = total;

            _unitOfWork.VendaRepository.Create(venda);
            await _unitOfWork.CommitAsync();

            return venda;
        }
    }
}
