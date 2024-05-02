using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services.Interfaces;

namespace DesafioDeltaFire.Services
{

    public class VendaService : IVendaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public VendaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task RegistrarVendaAsync(Venda venda)
        {
           

                foreach (var detalheVenda in venda.DetalhesVenda)
                {
                    var produto = await _unitOfWork.ProdutoRepository.GetProdutoById(detalheVenda.Produto.Id);
                    produto.Estoque -= detalheVenda.Quantidade;
                    _unitOfWork.ProdutoRepository.Update(produto);

                    detalheVenda.ValorUnitario = produto.Preco;
                    detalheVenda.Total = produto.Preco * detalheVenda.Quantidade;
                }

                venda.Total = venda.DetalhesVenda.Sum(dv => dv.Total);

                // Defina a nota da venda aqui
                //venda.NotaFiscal = // insira a lógica para calcular a nota aqui

                await _unitOfWork.CommitAsync();
            
           
        }
    }
}
