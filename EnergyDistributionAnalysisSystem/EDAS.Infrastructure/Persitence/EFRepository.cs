using EDAS.Application.Dtos;
using EDAS.Application.Interfaces;
using EDAS.Infrastructure.Persitence;
using Microsoft.EntityFrameworkCore;

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
            .Include(c => c.Tramo)
            .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin)
            .Select(x => new HistoricoClienteDto
            {
                Fecha = x.Fecha.Fecha1.Value,
                Tramo = x.Tramo.Nombre,
                Consumo = x.Residencial ?? 0m,
                Perdidas = _context.Perdida
                    .FirstOrDefault(p => p.TramoId == x.TramoId && p.FechaId == x.FechaId) != null
                        ? _context.Perdida
                            .FirstOrDefault(p => p.TramoId == x.TramoId && p.FechaId == x.FechaId).Residencial.GetValueOrDefault()
                        : 0m,
                Costo = _context.Costos
                    .FirstOrDefault(c => c.TramoId == x.TramoId && c.FechaId == x.FechaId) != null
                        ? _context.Costos
                            .FirstOrDefault(c => c.TramoId == x.TramoId && c.FechaId == x.FechaId).Residencial.GetValueOrDefault()
                        : 0m
            }).OrderBy(x => x.Tramo).ToListAsync();
    }



    public async Task<IEnumerable<HistoricoTramoDto>> GetHistoricalSegmentsAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        return await _context.Consumos
            .Include(c => c.Fecha)
            .Include(c => c.Tramo)
            .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin)
            .GroupBy(x => x.Tramo.Nombre)
            .Select(g => new HistoricoTramoDto
            {
                Tramo = g.Key,
                Consumo = g.Sum(x => x.Residencial + x.Comercial + x.Industrial) ?? 0m,
                Perdidas = _context.Perdida
                    .Where(p => g.Select(x => x.TramoId).Contains(p.TramoId) &&
                                g.Select(x => x.FechaId).Contains(p.FechaId))
                    .Sum(p => p.Residencial + p.Comercial + p.Industrial) ?? 0m,
                Costo = _context.Costos
                    .Where(c => g.Select(x => x.TramoId).Contains(c.TramoId) &&
                                g.Select(x => x.FechaId).Contains(c.FechaId))
                    .Sum(c => c.Residencial + c.Comercial + c.Industrial) ?? 0m
            }).OrderBy(x => x.Tramo).ToListAsync();
    }

    public async Task<IEnumerable<TopTramosClienteDto>> GetTopSegmentsCustomerAsync(DateTime fechaInicio, DateTime fechaFin)
    {
        return await _context.Consumos
            .Include(c => c.Fecha)
            .Include(c => c.Tramo)
            .Where(x => x.Fecha.Fecha1 >= fechaInicio && x.Fecha.Fecha1 <= fechaFin)
            .GroupBy(x => x.Tramo.Nombre)
            .Select(g => new TopTramosClienteDto
            {
                Tramo = g.Key,
                Perdidas = _context.Perdida
                    .Where(p => g.Select(x => x.TramoId).Contains(p.TramoId) &&
                                g.Select(x => x.FechaId).Contains(p.FechaId))
                    .Sum(p => p.Residencial + p.Comercial + p.Industrial) ?? 0m
            })
            .OrderByDescending(x => x.Perdidas)
            .Take(20)
            .ToListAsync();
    }
}
