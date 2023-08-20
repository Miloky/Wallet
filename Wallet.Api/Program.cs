using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Wallet.Api;
using Wallet.Api.Controllers;
using Wallet.Api.Domain;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationsAssembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(BalanceController)));
builder.Services.AddDbContext<WalletDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7050";
        options.Audience = "weatherapi";

        options.TokenValidationParameters.ValidTypes = new[] { "at+jwt" };
    });


builder.Services.AddIdentityServer(options =>
    {
        options.Events.RaiseErrorEvents = true;
        options.Events.RaiseFailureEvents = true;
        options.Events.RaiseInformationEvents = true;
        options.Events.RaiseSuccessEvents = true;
    })
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            o => o.MigrationsAssembly(migrationsAssembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
            o => o.MigrationsAssembly(migrationsAssembly));
    })
    .AddTestUsers(Config.Users);
    //.AddInMemoryClients(Config.Clients)
    //.AddInMemoryApiResources(Config.ApiResources)
    //.AddInMemoryApiScopes(Config.ApiScopes)
    //.AddInMemoryIdentityResources(Config.IdentityResources);

var app = builder.Build();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

Config.InitializeDatabase(app);

app.UseStaticFiles();
app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();


app.MapDefaultControllerRoute();

app.Run();
