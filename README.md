# .NET Bid Calculator (Backend Only)

Minimal, clean MVP backend for a Bid Calculation technical challenge, built to showcase:

- **Good coding practices** (SOLID, clean architecture, small focused classes)
- **Test-Driven Development (TDD)** – Core logic designed and driven by unit tests
- A clean separation between **API**, **domain logic**, and **tests**

> The frontend (Vue 3 + TypeScript) lives in a **separate repository** and consumes this API.

## Live Demo

- **Frontend (Vue 3 + TypeScript):**  
  https://bidcalculatorvue.netlify.app/
  
- **Backend Swagger UI (.NET 8 API):**  
  https://bidcalc-api-ingaru-e6b2ejd2agf8haed.canadacentral-01.azurewebsites.net/swagger/index.html

## What the backend does

The API exposes a single, focused endpoint that **calculates the final bid amount for a vehicle** based on:

- A **base price**
- A **vehicle type** (`Common` or `Luxury`)
- A set of **fee rules** (buyer fee, seller fee, association fee, storage fee, etc.)

## Tech stack

- **Language:** C# / .NET 8
- **Framework:** ASP.NET Core Web API (Controllers)
- **Testing:** xUnit, FluentAssertions
- **Architecture:**
  - `BidCalc.Core` – domain model and calculation logic
  - `BidCalc.Api` – HTTP API, DI, DTOs, CORS, Swagger
  - `BidCalc.Tests` – unit and API tests


## Run locally

### Requirements
- .NET SDK 8.0+
- (Optional) Visual Studio Code or Visual Studio 2022

### Steps

Clone the repo:

```bash
git clone https://github.com/ingacrd/Donet-TDD-Bid-Calculator.git
cd Donet-TDD-Bid-Calculator
```
Restore, build and run:

```bash
dotnet restore
dotnet build
dotnet run --project .\BidCalc.Api\BidCalc.Api.csproj
```

Open Swagger locally:

```bash
https://localhost:7xxx/swagger/index.html
```

Example request (GET):
```bash
https://localhost:7xxx/api/bid/calculate?basePrice=1000&vehicleType=Common
```

Response (example):
```bash

{
  "basePrice": 1000.0,
  "vehicleType": "Common",
  "fees": [
    { "name": "Basic buyer fee", "amount": 50.0 },
    { "name": "Seller special fee", "amount": 20.0 },
    { "name": "Association fee", "amount": 10.0 },
    { "name": "Storage fee", "amount": 100.0 }
  ],
  "total": 1180.0
}
```