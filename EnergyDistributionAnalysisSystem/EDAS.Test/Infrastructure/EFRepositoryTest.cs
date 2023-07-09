using EDAS.Domain.Models;
using EDAS.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;
namespace EDAS.Test
{
    public class EFRepositoryTest
    {
        private readonly DateTime _startDate = new DateTime(2010, 1, 1);
        private readonly DateTime _endDate = new DateTime(2010, 1, 3);
        [Fact]
        public void TestGetHistoricalCustomerAsync()
        {
           
            using (var context = CreateContext())
            {
                SeedDatabase(context);
                var repository = new EFRepository(context);
                
                var result = repository.GetHistoricalCustomerAsync(_startDate, _endDate, "Residencial").Result;
                
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
        [Fact]
        public void TestGetHistoricalSegmentsAsync()
        {
            
            using (var context = CreateContext())
            {
                SeedDatabase(context);
                var repository = new EFRepository(context);
                
                var result = repository.GetHistoricalSegmentsAsync(_startDate, _endDate).Result;
               
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }
        [Fact]
        public void TestGetTopSegmentsCustomerAsync()
        { 
            using (var context = CreateContext())
            {
                SeedDatabase(context);
                var repository = new EFRepository(context);
                
                var result = repository.GetTopSegmentsCustomerAsync(_startDate, _endDate).Result;
               
                Assert.NotNull(result);
                Assert.NotEmpty(result);
            }
        }

        private EnergyDistributionAnalysisSystemContext CreateContext()
        {
            var databaseName = Guid.NewGuid().ToString();
            var options = new DbContextOptionsBuilder<EnergyDistributionAnalysisSystemContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
            return new EnergyDistributionAnalysisSystemContext(options);
        }
        private void SeedDatabase(EnergyDistributionAnalysisSystemContext context)
        {
            var fecha1 = new Fecha { FechaId = 1, Fecha1 = _startDate };
            var fecha2 = new Fecha { FechaId = 2, Fecha1 = _startDate.AddDays(1) };
            var fecha3 = new Fecha { FechaId = 3, Fecha1 = _endDate };
            context.Fechas.AddRange(new List<Fecha> { fecha1, fecha2, fecha3 });
            var linea1 = new Linea { LineaId = 1, Nombre = "Tramo1" };
            context.Lineas.Add(linea1);
            var sector1 = new Sector { SectorId = 1, Nombre = "Residencial" };
            context.Sectors.Add(sector1);
            context.Consumos.Add(new Consumo { Fecha = fecha1, Linea = linea1, Sector = sector1, Valor = 100 });
            context.Consumos.Add(new Consumo { Fecha = fecha2, Linea = linea1, Sector = sector1, Valor = 200 });
            context.Consumos.Add(new Consumo { Fecha = fecha3, Linea = linea1, Sector = sector1, Valor = 300 });
            context.Costos.Add(new Costo { Fecha = fecha1, Linea = linea1, Sector = sector1, Valor = 50 });
            context.Costos.Add(new Costo { Fecha = fecha2, Linea = linea1, Sector = sector1, Valor = 100 });
            context.Costos.Add(new Costo { Fecha = fecha3, Linea = linea1, Sector = sector1, Valor = 150 });
            context.Perdida.Add(new Perdidum { Fecha = fecha1, Linea = linea1, Sector = sector1, Valor = 10 });
            context.Perdida.Add(new Perdidum { Fecha = fecha2, Linea = linea1, Sector = sector1, Valor = 20 });
            context.Perdida.Add(new Perdidum { Fecha = fecha3, Linea = linea1, Sector = sector1, Valor = 30 });
            context.SaveChanges();
        }
    }
}