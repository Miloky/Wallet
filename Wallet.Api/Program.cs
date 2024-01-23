using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Wallet.Api;
using Wallet.Api.Controllers;
using Wallet.Api.Domain;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var jwtBearerSettings = builder.Configuration.GetSection("JwtBearerSettings").Get<JwtBearerSettings>();
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
        options.Authority = jwtBearerSettings.Authority;
        options.Audience = jwtBearerSettings.Audience;
        options.RequireHttpsMetadata =jwtBearerSettings.RequireHttpsMetadata;
        options.TokenValidationParameters.ValidateIssuer = false;
        options.TokenValidationParameters.ValidTypes = jwtBearerSettings.ValidTypes;
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
