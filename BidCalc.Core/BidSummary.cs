namespace BidCalc.Core;
public record BidSummary(
    decimal BasePrice,
    VehicleType VehicleType,
    IReadOnlyList<FeeLine> Fees,
    decimal Total
);