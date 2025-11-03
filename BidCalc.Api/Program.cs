using BidCalc.Core;

var builder = WebApplication.CreateBuilder(args);

// 1) Add CORS policy (dev-only, restrict to Vite origin)
const string DevCors = "DevCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(DevCors, policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",  
                "https://localhost:5173"  
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services to the container.

builder.Services.AddControllers();

// Core DI
builder.Services.AddScoped<IFeeRule, BasicBuyerFeeRule>();
builder.Services.AddScoped<IFeeRule, SellersSpecialFeeRule>();
builder.Services.AddScoped<IFeeRule, AssociationFeeRule>();
builder.Services.AddScoped<IFeeRule, StorageFeeRule>();
builder.Services.AddScoped<BidCalculator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(DevCors);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }