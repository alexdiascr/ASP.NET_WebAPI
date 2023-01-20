namespace DevIO.Api.Extensions
{
    public class AppSettings
    {
        //Chave de criptografia
        public string Secrect { get; set; }

        //Quantas horas até o token perder a validade
        public int ExpiracaoHoras { get; set; }

        //Nome da aplicação que emite
        public string Emissor { get; set; }

        //Em quais urls que o token é válido
        public string ValidoEm { get; set; }
    }
}
