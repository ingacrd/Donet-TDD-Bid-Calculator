namespace BidCalc.Api.Dtos;

public class FeeDto
{
    public string Name { get; set; } = "";
    public decimal Amount { get; set; }
}

public class BidCalculationResponse
{
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; } = "";
    public List<FeeDto> Fees { get; set; } = new List<FeeDto>();
    public decimal Total { get; set; }
}
