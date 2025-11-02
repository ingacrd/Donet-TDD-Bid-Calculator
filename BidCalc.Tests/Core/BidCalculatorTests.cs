using FluentAssertions;
using BidCalc.Core;

public class BidCalculatorTests
{
    [Theory]
    // price, type, basic, special, association, storage, total
    [InlineData(398, VehicleType.Common, 39.80, 7.96, 5, 100, 550.76)]
    [InlineData(501, VehicleType.Common, 50.00, 10.02, 10, 100, 671.02)]
    [InlineData(57,  VehicleType.Common, 10.00, 1.14, 5, 100, 173.14)]
    [InlineData(1800, VehicleType.Luxury, 180.00, 72.00, 15, 100, 2167.00)]
    [InlineData(1100, VehicleType.Common, 50.00, 22.00, 15, 100, 1287.00)]
    [InlineData(1000000, VehicleType.Luxury, 200.00, 40_000.00, 20, 100, 1040320.00)]
    public void Computes_full_bid_summary_and_total(
        decimal price, VehicleType type,
        decimal basic, decimal special, decimal association, decimal storage, decimal expectedTotal)
    {
        var calc = new BidCalculator(new object[] {
            new BasicBuyerFeeRule(), new SellersSpecialFeeRule(),
            new AssociationFeeRule(), new StorageFeeRule()
        });

        var result = calc.Calculate(price, type);

        result.BasePrice.Should().Be(price);
        result.Total.Should().Be(expectedTotal);

        result.Fees.Should()
            .ContainSingle(fee => fee.Name == "Basic buyer fee")
            .Which.Amount.Should().Be(basic);
        result.Fees.Should()
            .ContainSingle(fee => fee.Name == "Seller special fee")
            .Which.Amount.Should().Be(special);
        result.Fees.Should()
            .ContainSingle(fee => fee.Name == "Association fee")
            .Which.Amount.Should().Be(association);
        result.Fees.Should()
            .ContainSingle(fee => fee.Name == "Storage fee")
            .Which.Amount.Should().Be(storage);
    }
}
