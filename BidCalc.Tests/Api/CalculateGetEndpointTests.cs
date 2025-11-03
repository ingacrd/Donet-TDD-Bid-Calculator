using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

public class CalculateGetEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public CalculateGetEndpointTests(WebApplicationFactory<Program> factory)
        => _client = factory.CreateClient();

    [Fact]
    public async Task Get_Calculate_Returns_ExpectedSummary_For_Common_1000()
    {
        var resp = await _client.GetAsync("/api/bid/calculate?basePrice=1000&vehicleType=Common");
        resp.StatusCode.Should().Be(HttpStatusCode.OK);

        var dto = await resp.Content.ReadFromJsonAsync<BidCalculationResponseDto>();
        dto.Should().NotBeNull();
        dto.BasePrice.Should().Be(1000m);
        dto.VehicleType.Should().Be("Common");
        dto.Total.Should().Be(1180m);

        dto.Fees.Should().ContainSingle(f => f.Name == "Basic buyer fee")
            .Which.Amount.Should().Be(50m);
        dto.Fees.Should().ContainSingle(f => f.Name == "Seller special fee")
            .Which.Amount.Should().Be(20m);
        dto.Fees.Should().ContainSingle(f => f.Name == "Association fee")
            .Which.Amount.Should().Be(10m);
        dto.Fees.Should().ContainSingle(f => f.Name == "Storage fee")
            .Which.Amount.Should().Be(100m);
    }

    [Theory]
    [InlineData("0", "Common")]          // invalid price
    [InlineData("-5", "Luxury")]         // invalid price
    [InlineData("1000", "Unknown")]      // invalid type
    [InlineData("", "Common")]           // missing basePrice
    [InlineData("1000", "")]             // missing vehicleType
    public async Task Get_Calculate_InvalidInput_Returns400(string price, string type)
    {
        var url = $"/api/bid/calculate?basePrice={price}&vehicleType={type}";
        var resp = await _client.GetAsync(url);
        resp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }

}

// DTOs 
public record BidCalculationResponseDto(
    decimal BasePrice, string VehicleType, FeeDto[] Fees, decimal Total);
public record FeeDto(string Name, decimal Amount);
