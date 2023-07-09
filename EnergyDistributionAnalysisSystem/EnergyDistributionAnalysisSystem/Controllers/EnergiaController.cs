using EDAS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace EDAS.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyController : ControllerBase
    {
        private readonly IEnergyService _energyService;

        public EnergyController(IEnergyService energyService)
        {
            _energyService = energyService;
        }

        /// <summary>
        /// Get historical segments data within a specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the historical data.</param>
        /// <param name="endDate">The end date of the historical data.</param>
        /// <returns>The historical segments data.</returns>
        [HttpGet("historical-segments")]
        public async Task<IActionResult> GetHistoricalSegments([FromQuery][Required] DateTime startDate, [FromQuery][Required] DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _energyService.GetHistoricalSegmentsAsync(startDate, endDate);
            return Ok(data);
        }

        /// <summary>
        /// Get historical customer data within a specified date range and customer type.
        /// </summary>
        /// <param name="startDate">The start date of the historical data.</param>
        /// <param name="endDate">The end date of the historical data.</param>
        /// <param name="customerType">The type of customer.</param>
        /// <returns>The historical customer data.</returns>
        [HttpGet("historical-customer")]
        public async Task<IActionResult> GetHistoricalCustomer([FromQuery][Required] DateTime startDate, [FromQuery][Required] DateTime endDate, [FromQuery] string customerType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _energyService.GetHistoricalCustomerAsync(startDate, endDate, customerType);
            return Ok(data);
        }

        /// <summary>
        /// Get top segments for a specific customer within a specified date range.
        /// </summary>
        /// <param name="startDate">The start date of the historical data.</param>
        /// <param name="endDate">The end date of the historical data.</param>
        /// <returns>The top segments for the customer.</returns>
        [HttpGet("top-segments-customer")]
        public async Task<IActionResult> GetTopSegmentsCustomer([FromQuery][Required] DateTime startDate, [FromQuery][Required] DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var data = await _energyService.GetTopSegmentsCustomerAsync(startDate, endDate);
            return Ok(data);
        }
    }
}
