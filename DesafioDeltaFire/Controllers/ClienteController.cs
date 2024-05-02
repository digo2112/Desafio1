using DesafioDeltaFire.Context;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioDeltaFire.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ClienteController> _logger;

        public ClienteController(IUnitOfWork unitOfWork, ILogger<ClienteController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _unitOfWork.ClienteRepository.GetAllAsync();
            _logger.LogCritical("HttpGet");
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }
            _logger.LogCritical("[HttpGet(\"{id}\")]");

            return Ok(cliente);
        }

        [ApiController]
        [Route("[controller]")]
        public class ClientesController : ControllerBase
        {
            private readonly AppDbContext _context;

            public ClientesController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet("{id}/historico-vendas")]
            public async Task<ActionResult<IEnumerable<Venda>>> GetHistoricoVendas(Guid id)
            {
                var cliente = await _context.Cliente
                    .Include(c => c.HistoricoVendas)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (cliente == null)
                {
                    return NotFound();
                }
               
                return Ok(cliente.HistoricoVendas);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            var createdCliente = _unitOfWork.ClienteRepository.Create(cliente);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpPost]");
            return CreatedAtAction(nameof(GetCliente), new { id = createdCliente.Id }, createdCliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(Guid id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ClienteRepository.Update(cliente);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpPut(\"{id}\")]");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var cliente = await _unitOfWork.ClienteRepository.GetAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _unitOfWork.ClienteRepository.Delete(cliente);
            await _unitOfWork.CommitAsync();
            _logger.LogCritical("[HttpDelete(\"{id}\")]");
            return NoContent();
        }
    }
}