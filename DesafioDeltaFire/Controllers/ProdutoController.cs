using Desafio1.Pagination;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services;
using DesafioDeltaFire.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Globalization;

namespace DesafioDeltaFire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRelatorioVendasService _relatorioVendasService;
        private readonly ILogger<Produto> _logger;

        public ProdutosController(IUnitOfWork unitOfWork, IRelatorioVendasService relatorioVendasService, ILogger<Produto> logger)
        {
            _unitOfWork = unitOfWork;
            _relatorioVendasService = relatorioVendasService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<PageList<Produto>>> GetProdutos([FromQuery] ProdutosParameters produtosParameters)
        {
            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosAsync(produtosParameters);
            _logger.LogCritical("[HttpGet]");
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> GetProduto(Guid id)
        {
            var produto = await _unitOfWork.ProdutoRepository.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }
            _logger.LogCritical(" [HttpGet({id})]");
            return Ok(produto);
        }

        [HttpGet("por-categoria/{id}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosPorCategoria(int id)
        {
            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosPorCategoriaAsync(id);
            _logger.LogCritical("[HttpGet(\"por-categoria/{id}\")]");
            return Ok(produtos);
        }

        [HttpGet("por-fornecedor/{id}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosPorFornecedor(int id)
        {
            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosPorFornecedorAsync(id);
            _logger.LogCritical("[HttpGet(por-fornecedor/{id})]");
            return Ok(produtos);
        }

        [HttpGet("por-validade/{data}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosPorValidade(DateTime data)
        {
            // Convert DateTime to DateOnly
            var dateOnly = DateOnly.FromDateTime(data);

            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosPorValidadeAsync(dateOnly);
            _logger.LogCritical("[HttpGet(por-validade/{data})]");
            return Ok(produtos);
        }

        [HttpGet("por-cadastro/{inicio}/{fim}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosPorCadastro(
          [FromRoute, SwaggerParameter("Data de início do cadastro dos produtos no formato yyyy-MM-dd", Required = true)] string inicio,
          [FromRoute, SwaggerParameter("Data de fim do cadastro dos produtos no formato yyyy-MM-dd", Required = true)] string fim)
        {
            if (!DateOnly.TryParseExact(inicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedInicio))
            {
                return BadRequest("Data de início inválida. Use o formato yyyy-MM-dd.");
            }

            if (!DateOnly.TryParseExact(fim, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedFim))
            {
                return BadRequest("Data de fim inválida. Use o formato yyyy-MM-dd.");
            }

            var produtos = await _unitOfWork.ProdutoRepository.GetProdutosPorCadastroAsync(parsedInicio, parsedFim);
            _logger.LogCritical("[HttpGet(por-cadastro/{inicio}/{fim})]");
            return Ok(produtos);
        }

        

        [HttpPost]
        public async Task<ActionResult<Produto>> CreateProduto(Produto produto)
        {
            _unitOfWork.ProdutoRepository.Create(produto);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpPost({id})]");
            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduto(Guid id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProdutoRepository.Update(produto);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpPut({id})]");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(Guid id)
        {
            var produto = await _unitOfWork.ProdutoRepository.GetProdutoById(id);

            if (produto == null)
            {
                return NotFound();
            }

            _unitOfWork.ProdutoRepository.Delete(produto);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpDelete({id})]");
            return NoContent();
        }
    }
}