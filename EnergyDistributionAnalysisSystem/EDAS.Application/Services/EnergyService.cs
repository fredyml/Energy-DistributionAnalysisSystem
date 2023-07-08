using EDAS.Application.Dtos;
using EDAS.Application.Interfaces;

namespace EDAS.Application.Services
{
    public class EnergyService : IEnergyService
    {
        private readonly IRepository _repository;

        public EnergyService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<HistoricoClienteDto>> GetHistoricalCustomerAsync(DateTime fechaInicio, DateTime fechaFin, string tipoCliente)
        {
            return await _repository.GetHistoricalCustomerAsync(fechaInicio, fechaFin, tipoCliente);
        }

        public async Task<IEnumerable<HistoricoTramoDto>> GetHistoricalSegmentsAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _repository.GetHistoricalSegmentsAsync(fechaInicio, fechaFin);
        }

        public async Task<IEnumerable<TopTramosClienteDto>> GetTopSegmentsCustomerAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _repository.GetTopSegmentsCustomerAsync(fechaInicio, fechaFin);
        }
    }
}
