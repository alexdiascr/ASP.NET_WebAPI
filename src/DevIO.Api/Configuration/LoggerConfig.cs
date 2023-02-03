using DevIO.Api.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLogginConfigration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "7cbb4a934b2f4b998dd74d78e4b24960";
                o.LogId = new Guid("812568fe-1183-4ba3-8c66-8258fab30eb3");
            });

            //services.AddHealthChecks()
            //    .AddElmahIoPublisher(o =>
            //    {
            //        o.ApiKey = "7cbb4a934b2f4b998dd74d78e4b24960";
            //        o.LogId = new Guid("812568fe-1183-4ba3-8c66-8258fab30eb3");
            //        o.HeartbeatId = "API Fornecedores";
            //    })
            //    .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
            //    .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSQL");

            //services.AddHealthChecksUI()
            //    .AddSqlServerStorage(configuration.GetConnectionString("DefaultConnection"));

            return services;
        }

        public static IApplicationBuilder UseLogginConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
