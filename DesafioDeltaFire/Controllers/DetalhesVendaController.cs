using DesafioDeltaFire.Controllers;
using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services;
using DesafioDeltaFire.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("api/[controller]")]
public class DetalhesVendasController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAdicionarDetalheVenda _adicionarDetalheVenda;
    private readonly ILogger<DetalhesVendasController> _logger;

    public DetalhesVendasController(IUnitOfWork unitOfWork, IAdicionarDetalheVenda adicionarDetalheVenda, ILogger<DetalhesVendasController> logger)
    {
        _unitOfWork = unitOfWork;
        _adicionarDetalheVenda = adicionarDetalheVenda;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetDetalhesVendas()
    {
        var detalhesVendas = await _unitOfWork.DetalhesVendaRepository.GetAllAsync();

        _logger.LogCritical("HttpGet");

        return Ok(detalhesVendas);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDetalhesVenda(Guid id)
    {
        var detalhesVenda = await _unitOfWork.DetalhesVendaRepository.GetAsync(dv => dv.Id == id);

        if (detalhesVenda == null)
        {
            return NotFound();
        }
        _logger.LogCritical("[HttpGet(\"{id}\")]");


        return Ok(detalhesVenda);
    }

    [HttpPost]
    public async Task<ActionResult<Venda>> PostDetalhesVenda(DetalhesVendaDTO detalhesVendaDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var venda = await _adicionarDetalheVenda.AdicionarDetalheVendas(detalhesVendaDTO);
        _logger.LogCritical("[HttpPost]");

        // Retornar a venda atualizada
        return CreatedAtAction(nameof(VendasController.GetVenda), "Vendas", new { id = venda.Id }, venda);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDetalhesVenda(Guid id, UpdateDetalhesVendaDTO detalhesVendaDTO)
    {
        if (id != detalhesVendaDTO.Id)
        {
            return BadRequest();
        }

        var detalhesVenda = new DetalhesVenda
        {
            Id = detalhesVendaDTO.Id,
            ProdutoId = detalhesVendaDTO.ProdutoId,
            Quantidade = detalhesVendaDTO.Quantidade
        };

        _unitOfWork.DetalhesVendaRepository.Update(detalhesVenda);
        await _unitOfWork.CommitAsync();

        _logger.LogCritical("[HttpPut]");
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDetalhesVenda(Guid id)
    {
        var detalhesVenda = await _unitOfWork.DetalhesVendaRepository.GetAsync(dv => dv.Id == id);

        if (detalhesVenda == null)
        {
            return NotFound();
        }

        _unitOfWork.DetalhesVendaRepository.Delete(detalhesVenda);
        await _unitOfWork.CommitAsync();
        _logger.LogCritical("[HttpDelete(\"{id}\")]");
        return NoContent();
    }
}
