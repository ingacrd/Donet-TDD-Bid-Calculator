using FluentAssertions;
using Xunit;
using BidCalc.Core;

public class StorageFeeRuleTests
{
    [Theory]
    [InlineData(57)]
    [InlineData(398)]
    [InlineData(3000)]
    public void Always_100(decimal price)
    {
        new StorageFeeRule().Compute(price).Should().Be(100m);
    }
}
