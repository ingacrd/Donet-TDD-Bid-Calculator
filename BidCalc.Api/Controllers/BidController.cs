using BidCalc.Api.Dtos;
using BidCalc.Core;
using Microsoft.AspNetCore.Mvc;

namespace BidCalc.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BidController : ControllerBase
{
    private readonly BidCalculator _calculator;
    public BidController(BidCalculator calculator)
    {
        _calculator = calculator;
    } 

    [HttpGet("calculate")]
    [ProducesResponseType(typeof(BidCalculationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public ActionResult<BidCalculationResponse> Calculate([FromQuery] decimal? basePrice, [FromQuery] string? vehicleType)
    {
        // Validations
        if (basePrice is null || basePrice < 1m)
            return BadRequest("Query parameter 'basePrice' must be provided and >= 1.00.");

        var typeText = (vehicleType ?? string.Empty).Trim();
        if (!Enum.TryParse<VehicleType>(typeText, ignoreCase: true, out var vtype))
            return BadRequest("Query parameter 'vehicleType' must be 'Common' or 'Luxury'.");


        var summary = _calculator.Calculate(basePrice.Value, vtype);

        var resp = new BidCalculationResponse
        {
            BasePrice = summary.BasePrice,
            VehicleType = vtype.ToString(),
            Total = summary.Total,
            Fees = summary.Fees
                .Select(f => new FeeDto { Name = f.Name, Amount = f.Amount })
                .ToList()
        };

        return Ok(resp);
    }
}
