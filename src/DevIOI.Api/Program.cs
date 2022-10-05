using DevIO.Api.Configuration;
using DevIO.Data.Context;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// ConfigureServices
builder.Services.AddDbContext<MeuDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
    options.AddPolicy("Development",
        builder =>
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.ResolveDependencies();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


// Construção da APP
// Realizando o buid das configurações que resultará na App
// Essa linha precisa sempre ficar por ultimo na configuracao dos servicos
var app = builder.Build();
//var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}



#region Configurando o request dos serviços no pipeline
// Configure the HTTP request pipeline.
// Daqui para baixo e conteudo que vinha dentro do metodo Configure() na antiga Startup.cs
// Aqui se configura comportamentos do request dentro do pipeline
// Ativando a pagina de erros caso seja ambiente de desenvolvimento
if (builder.Environment.IsDevelopment())
{
    //app.UseCors("Development");
    app.UseDeveloperExceptionPage();
}
else
{
    //app.UseExceptionHandler("/Home/Error");
    //app.UseDeveloperExceptionPage();

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("Development");

// Redirecionamento para HTTPs
app.UseHttpsRedirection();

//usa arquivos locais, por exemplo, os que estão na pasta wwwroot na lib
// Uso de arquivos estáticos (ex. CSS, JS)
app.UseStaticFiles();

// Adicionando suporte a rota
//app.UseRouting();

//app.UseMvc();

// Autenticacao e autorização (Identity)
app.UseAuthorization();
app.UseAuthentication();


app.MapControllers();

app.Run();

#endregion