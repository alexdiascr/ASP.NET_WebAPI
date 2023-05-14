using DevIO.Api.Configuration;
using DevIO.Data.Context;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionando suporte a Diversos arquivos de configuração por ambiente.
builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();


// Adicionando suporte a User Secrets
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// *** Configurando serviços no container ***

// ConfigureServices
builder.Services.AddDbContext<MeuDbContext>(optios =>
    {
        optios.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });

// Extension Method de configuração do Identity
builder.Services.AddIdentityConfig(builder.Configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiConfig();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerConfig();

//builder.Services.AddLogginConfigration(builder.Configuration);

//builder.Services.AddHealthChecks();

// Extension Method de resolução de DI
builder.Services.ResolveDependencies();

var app = builder.Build();
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


app.UseApiConfig(app.Environment);

app.UseSwaggerConfig(apiVersionDescriptionProvider);

//app.UseLogginConfiguration();

app.MapControllers();

app.Run();
