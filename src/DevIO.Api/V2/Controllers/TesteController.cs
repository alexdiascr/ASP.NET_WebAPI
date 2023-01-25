using DevIO.Api.Controllers;
using DevIO.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.V2.Controllers
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/teste")]
    public class TesteController : MainController
    {
        private readonly ILogger _logger;

        public TesteController(INotificador notificador, 
                               IUser appUser, 
                               ILogger logger) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {
            #region Utilizado para ambiente desenvolvimento
            _logger.LogTrace("Log de Trace");
            _logger.LogDebug("Log de Debug");
            #endregion

            //Nada de importante, mas que é interessante registrar
            _logger.LogInformation("Log de Informação"); 
            //Não é um erro, mas não deveria acontecer ex: 504
            _logger.LogWarning("Log de Aviso");
            //Erro mesmo
            _logger.LogError("Log de Erro");
            //Ameaça a saúde da aplicação
            _logger.LogCritical("Log de Problema Critico");

            return "Sou a V2";
        }
    }
}
