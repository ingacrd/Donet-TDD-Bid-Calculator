namespace BidCalc.Core;

public sealed class StorageFeeRule
{
    public decimal Compute(decimal basePrice)
    {
        return 100m;
    }
}