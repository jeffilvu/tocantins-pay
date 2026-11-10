namespace TocantinsPay.Core.Models.InputModels
{
    public class BaseClienteInputModel(string nomeCompleto, string email, string telefone)
    {
        public string NomeCompleto { get; } = nomeCompleto;

        public string Email { get; } = email;

        public string Telefone { get; } = telefone;
    }
}
