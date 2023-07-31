using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Wallet.Api.Controllers;
using Wallet.Api.Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(BalanceController)));
builder.Services.AddDbContext<WalletDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});


app.MapDefaultControllerRoute();

app.Run();
