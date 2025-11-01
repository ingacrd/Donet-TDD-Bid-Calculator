using FluentAssertions;
using BidCalc.Core;

public class SellersSpecialFeeRuleTests
{
    private readonly SellersSpecialFeeRule _rule = new();

    [Theory]
    //Common: 2% of the vehicle price
    [InlineData(398, VehicleType.Common, 7.96)]    
    [InlineData(501, VehicleType.Common, 10.02)]
    [InlineData(1100, VehicleType.Common, 22)]   
     
    // Luxury: 4% of the vehicle price
    [InlineData(1800, VehicleType.Luxury, 72)]     
    [InlineData(1_000_000, VehicleType.Luxury, 40_000)]
    public void Computes_sellers_special_fee_percentage(decimal price, VehicleType type, decimal expected)
    {
        _rule.Compute(price, type).Should().Be(expected);
    }
}
