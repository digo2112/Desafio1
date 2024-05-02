using DesafioDeltaFire.DTOs;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services;
using DesafioDeltaFire.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DesafioDeltaFire.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class VendasController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICriarVendaService _criarVendaService;
        private readonly ILogger<DetalhesVendasController> _logger;

        //public VendasController(IUnitOfWork unitOfWork, CriarVendaService criarVendaService)
        public VendasController(IUnitOfWork unitOfWork, ICriarVendaService criarVendaService)
        {
            _unitOfWork = unitOfWork;
            _criarVendaService = criarVendaService;

        }

        [HttpGet]
        public async Task<IActionResult> GetVendas()
        {
            var vendas = await _unitOfWork.VendaRepository.GetAllAsync();
            _logger.LogCritical("HttpGet");
            return Ok(vendas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVenda(Guid id)
        {
            var venda = await _unitOfWork.VendaRepository.GetAsync(v => v.Id == id);

            if (venda == null)
            {
                return NotFound();
            }
            _logger.LogCritical("[HttpGet(\"{id}\")]");
            return Ok(venda);
        }



        [HttpPost]
        public async Task<IActionResult> CreateVenda(VendaDTO vendaDTO)
        {
            var venda = await _criarVendaService.CriarVenda(vendaDTO);
            _logger.LogCritical("[HttpPost]");
            return CreatedAtAction(nameof(GetVenda), new { id = venda.Id }, venda);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(Guid id, Venda venda)
        {
            if (id != venda.Id)
            {
                return BadRequest();
            }

            _unitOfWork.VendaRepository.Update(venda);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpPut(\"{id}\")]");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(Guid id)
        {
            var venda = await _unitOfWork.VendaRepository.GetAsync(v => v.Id == id);

            if (venda == null)
            {
                return NotFound();
            }

            _unitOfWork.VendaRepository.Delete(venda);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpDelete(\"{id}\")]");
            return Ok(venda);
        }
    }

}
