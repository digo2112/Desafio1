using DesafioDeltaFire.Controllers;
using DesafioDeltaFire.Models;
using DesafioDeltaFire.Repositories.Interfaces;
using DesafioDeltaFire.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestesDesafioDeltaFire.Controllers
{
    public class VendasControllerTests
    {
        private MockRepository _mockRepository;

        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<ICriarVendaService> _mockCriarVendaService;

        public VendasControllerTests()
        {
            _mockRepository = new MockRepository(MockBehavior.Loose);

            _mockUnitOfWork = _mockRepository.Create<IUnitOfWork>();
            _mockCriarVendaService = _mockRepository.Create<ICriarVendaService>();
        }

        private VendasController CreateVendasController()
        {
            return new VendasController(_mockUnitOfWork.Object, _mockCriarVendaService.Object);
        }

        [Fact]
        public async Task GetVendas_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var vendasController = CreateVendasController();
            var venda = new List<Venda>() { new Venda() };

            _mockUnitOfWork.Setup(x => x.VendaRepository.GetAllAsync()).ReturnsAsync(venda);

            // Act
            var result = await vendasController.GetVendas();

            // Assert
            Assert.IsAssignableFrom<IActionResult>(result);

            this._mockRepository.VerifyAll();
        }
    }
}