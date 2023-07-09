using EDAS.Application.Dtos;
using EDAS.Application.Interfaces;
using Moq;

namespace EDAS.Application.Services.Tests
{
    public class EnergyServiceTests
    {
        private readonly DateTime _startDate = new DateTime(2010, 1, 1);
        private readonly DateTime _endDate = new DateTime(2010, 1, 3);

        [Fact]
        public async Task GetHistoricalCustomerAsync_ShouldReturnDataFromRepository()
        {
            
            IEnumerable<HistoricoClienteDto> expectedData = new List<HistoricoClienteDto>
            {
                new HistoricoClienteDto { Fecha = _startDate, Tramo = "Tramo 1", Consumo = 100, Perdidas = 10, Costo = 50 },
                new HistoricoClienteDto { Fecha = _startDate.AddDays(1), Tramo = "Tramo 2", Consumo = 200, Perdidas = 20, Costo = 100 }
            };

            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => r.GetHistoricalCustomerAsync(_startDate, _endDate, "Residencial")).ReturnsAsync(expectedData);

            EnergyService energyService = new EnergyService(repositoryMock.Object);

            
            IEnumerable<HistoricoClienteDto> result = await energyService.GetHistoricalCustomerAsync(_startDate, _endDate, "Residencial");

            
            Assert.Equal(expectedData, result);
            repositoryMock.Verify(r => r.GetHistoricalCustomerAsync(_startDate, _endDate, "Residencial"), Times.Once);
        }

        [Fact]
        public async Task GetHistoricalSegmentsAsync_ShouldReturnDataFromRepository()
        {
            
            IEnumerable<HistoricoTramoDto> expectedData = new List<HistoricoTramoDto>
            {
                new HistoricoTramoDto { Tramo = "Tramo 1", Consumo = 100, Perdidas = 10, Costo = 50 },
                new HistoricoTramoDto { Tramo = "Tramo 2", Consumo = 200, Perdidas = 20, Costo = 100 }
            };

            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => r.GetHistoricalSegmentsAsync(_startDate, _endDate)).ReturnsAsync(expectedData);

            EnergyService energyService = new EnergyService(repositoryMock.Object);

            
            IEnumerable<HistoricoTramoDto> result = await energyService.GetHistoricalSegmentsAsync(_startDate, _endDate);

            
            Assert.Equal(expectedData, result);
            repositoryMock.Verify(r => r.GetHistoricalSegmentsAsync(_startDate, _endDate), Times.Once);
        }

        [Fact]
        public async Task GetTopSegmentsCustomerAsync_ShouldReturnDataFromRepository()
        {
            
            IEnumerable<TopTramosClienteDto> expectedData = new List<TopTramosClienteDto>
            {
                new TopTramosClienteDto { Tramo = "Tramo 1", Perdidas = 10 },
                new TopTramosClienteDto { Tramo = "Tramo 2", Perdidas = 20 }
            };

            Mock<IRepository> repositoryMock = new Mock<IRepository>();
            repositoryMock.Setup(r => r.GetTopSegmentsCustomerAsync(_startDate, _endDate)).ReturnsAsync(expectedData);

            EnergyService energyService = new EnergyService(repositoryMock.Object);

            
            IEnumerable<TopTramosClienteDto> result = await energyService.GetTopSegmentsCustomerAsync(_startDate, _endDate);

           
            Assert.Equal(expectedData, result);
            repositoryMock.Verify(r => r.GetTopSegmentsCustomerAsync(_startDate, _endDate), Times.Once);
        }
    }
}
