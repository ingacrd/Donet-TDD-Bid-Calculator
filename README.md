# .NET Bid Calculator (Backend Only)

Minimal, clean MVP backend for the a Bid Calculation challenge.  
Stack: **.NET 8**, ASP.NET Core Web API (Controllers), xUnit tests.

> Frontend is **not** included in this repository.

## Requirements
- .NET SDK 8.0+
- (Optional) Visual Studio Code or Visual Studio 2022

## Projects
- `BidCalc.Api` – Web API (Swagger enabled in Development)
- `BidCalc.Core` – Domain & calculation logic
- `BidCalc.Tests` – Unit tests for Core

## Run
```bash
dotnet restore
dotnet build
dotnet run --project .\BidCalc.Api\BidCalc.Api.csproj
