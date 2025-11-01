namespace BidCalc.Core;

public class SellersSpecialFeeRule
{
    private const decimal CommonRate = 0.02m;
    private const decimal LuxuryRate = 0.04m;
    public decimal Compute(decimal basePrice, VehicleType type)
    {
        return basePrice * (type == VehicleType.Luxury ? LuxuryRate : CommonRate);
    }
}