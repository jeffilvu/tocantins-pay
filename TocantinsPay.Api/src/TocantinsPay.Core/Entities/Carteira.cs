namespace TocantinsPay.Core.Entities;

public class Carteira
{
    public Carteira()
    {
        
    }

    public Carteira(Guid clienteId)
    {
        Id = Guid.NewGuid();
        Saldo = 0;
        Conta = GerarNumeroConta();
        Agencia = "0001";
        ClienteId = clienteId;
    }

    public Guid Id { get; }
     
    public decimal Saldo { get; private set; }

    public string Conta { get; }

    public string Agencia { get; }

    public Guid ClienteId { get; }

    private static string GerarNumeroConta()
    {
        var random = new Random();

        int numeroConta = random.Next(10000000, 99999999);

        int digito = random.Next(0, 10);

        return $"{numeroConta}-{digito}";
    }

    public void AtualizarSaldo(decimal novoSaldo)
    {
        Saldo = novoSaldo;
    }
}
