using EDAS.Application.Dtos;
using EDAS.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EDAS.Infrastructure.Persitence
{
    public class EFRepository : IRepository
    {
        private readonly EnergyDistributionAnalysisSystemContext _context;

        public EFRepository(EnergyDistributionAnalysisSystemContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HistoricoClienteDto>> GetHistoricalCustomerAsync(DateTime fechaInicio, DateTime fechaFin, string tipoCliente)
        {
            return await _context.Consumos
                .Include(c => c.Fecha)
                .Include(c => c.Linea)
                .Include(c => c.Sector)
                .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin && x.Sector.Nombre == tipoCliente)
                .Select(x => new
                {
                    Consumo = x,
                    Perdida = _context.Perdida
                                .FirstOrDefault(p => p.LineaId == x.LineaId && p.FechaId == x.FechaId && p.SectorId == x.SectorId),
                    Costo = _context.Costos
                                .FirstOrDefault(c => c.LineaId == x.LineaId && c.FechaId == x.FechaId && c.SectorId == x.SectorId)
                })
                .Select(x => new HistoricoClienteDto
                {
                    Fecha = x.Consumo.Fecha.Fecha1,
                    Tramo = x.Consumo.Linea.Nombre,
                    Consumo = x.Consumo.Valor,
                    Perdidas = x.Perdida != null ? x.Perdida.Valor : 0,
                    Costo = x.Costo != null ? x.Costo.Valor : 0
                }).OrderBy(x => x.Tramo).ToListAsync();
        }


        public async Task<IEnumerable<HistoricoTramoDto>> GetHistoricalSegmentsAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Consumos
                .Include(c => c.Fecha)
                .Include(c => c.Linea)
                .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin)
                .GroupBy(x => x.Linea.Nombre)
                .Select(g => new HistoricoTramoDto
                {
                    Tramo = g.Key,
                    Consumo = g.Sum(x => x.Valor),
                    Perdidas = _context.Perdida
                        .Where(p => g.Select(x => x.LineaId).Contains(p.LineaId) &&
                                    g.Select(x => x.FechaId).Contains(p.FechaId))
                        .Sum(p => p.Valor),
                    Costo = _context.Costos
                        .Where(c => g.Select(x => x.LineaId).Contains(c.LineaId) &&
                                    g.Select(x => x.FechaId).Contains(c.FechaId))
                        .Sum(c => c.Valor)
                }).OrderBy(x => x.Tramo).ToListAsync();
        }

        public async Task<IEnumerable<TopTramosClienteDto>> GetTopSegmentsCustomerAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            return await _context.Consumos
                .Include(c => c.Fecha)
                .Include(c => c.Linea)
                .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin)
                .GroupBy(x => x.Linea.Nombre)
                .Select(g => new TopTramosClienteDto
                {
                    Tramo = g.Key,
                    Perdidas = _context.Perdida
                        .Where(p => g.Select(x => x.LineaId).Contains(p.LineaId) &&
                                    g.Select(x => x.FechaId).Contains(p.FechaId))
                        .Sum(p => p.Valor)
                })
                .OrderByDescending(x => x.Perdidas)
                .Take(20)
                .ToListAsync();
        }
    }
}
