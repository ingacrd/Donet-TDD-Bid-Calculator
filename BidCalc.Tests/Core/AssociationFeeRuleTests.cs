using FluentAssertions;
using BidCalc.Core;

public class AssociationFeeRuleTests
{
    private readonly AssociationFeeRule _rule = new();

    [Theory]
    [InlineData(1, 5)]
    [InlineData(500, 5)]
    [InlineData(501, 10)]
    [InlineData(1000, 10)]
    [InlineData(1000.01, 15)]
    [InlineData(3000, 15)]
    [InlineData(3000.01, 20)]
    public void Returns_flat_fee_by_price_range(decimal price, decimal expected)
    {
        _rule.Compute(price).Should().Be(expected);
    }
}