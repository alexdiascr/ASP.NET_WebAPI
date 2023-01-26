using Elmah.Io.Extensions.Logging;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLogginConfigration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "7cbb4a934b2f4b998dd74d78e4b24960";
                o.LogId = new Guid("812568fe-1183-4ba3-8c66-8258fab30eb3");
            });


            ////Adicionando os logs que são injetados manualmente
            //services.AddLogging(builder =>
            //{
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "7cbb4a934b2f4b998dd74d78e4b24960";
            //        o.LogId = new Guid("812568fe-1183-4ba3-8c66-8258fab30eb3");
            //    });

            //    //LogLevel.Warning - Somente logs importante
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);
            //});

            return services;
        }


        public static IApplicationBuilder UseLogginConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();

            return app;
        }
    }
}
