using FluentAssertions;
using BidCalc.Core;

public class BasicBuyerFeeRuleTests
{
    private readonly BasicBuyerFeeRule _rule = new();

    [Theory]
    // Common: 10% with min 10, max 50
    [InlineData(43, VehicleType.Common, 10)]         
    [InlineData(314, VehicleType.Common, 31.4)]      
    [InlineData(1000, VehicleType.Common, 50)]       

    // Luxury: 10% with min 25, max 200
    [InlineData(100, VehicleType.Luxury, 25)]       
    [InlineData(1400, VehicleType.Luxury, 180)]      
    [InlineData(1000000, VehicleType.Luxury, 200)]   
    public void Computes_basic_buyer_fee_with_caps(decimal price, VehicleType type, decimal expected)
    {
        var amount = _rule.Compute(price, type);
        amount.Should().Be(expected);
    }
}
