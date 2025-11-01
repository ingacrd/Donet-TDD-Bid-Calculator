namespace BidCalc.Core;

public sealed class AssociationFeeRule
{
    public decimal Compute(decimal basePrice)
    {
        if (basePrice <= 500m) return 5m;
        if (basePrice <= 1000m) return 10m;
        if (basePrice <= 3000m) return 15m;
        return 20m;
    }
}