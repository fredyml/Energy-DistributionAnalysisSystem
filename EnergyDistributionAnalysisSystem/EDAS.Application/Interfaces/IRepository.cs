using EDAS.Application.Dtos;

namespace EDAS.Application.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<HistoricoTramoDto>> GetHistoricalSegmentsAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<IEnumerable<HistoricoClienteDto>> GetHistoricalCustomerAsync(DateTime fechaInicio, DateTime fechaFin, string tipoCliente);
        Task<IEnumerable<TopTramosClienteDto>> GetTopSegmentsCustomerAsync(DateTime fechaInicio, DateTime fechaFin);
    }
}
