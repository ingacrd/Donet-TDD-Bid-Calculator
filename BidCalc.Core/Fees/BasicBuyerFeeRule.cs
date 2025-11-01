namespace BidCalc.Core;

public class BasicBuyerFeeRule
{
    public decimal Compute(decimal basePrice, VehicleType type)
    {
        var baseFee = basePrice * 0.10m;

        if (type == VehicleType.Common)  return Limit(baseFee, 10m, 50m);
        if (type == VehicleType.Luxury)  return Limit(baseFee, 25m, 200m);
        return baseFee;

    }

    private static decimal Limit(decimal value, decimal min, decimal max)
    {
        return value < min ? min : (value > max ? max : value);
    }   
    
}