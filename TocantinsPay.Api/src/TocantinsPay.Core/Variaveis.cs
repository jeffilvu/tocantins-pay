namespace TocantinsPay.Core
{
    public static class Variaveis
    {
        public static class Geral
        {
            public static string ENV = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") 
                ?? throw new ArgumentNullException("O ambiente deve ser informado");
        }
    }
}
