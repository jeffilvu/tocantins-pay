namespace TocantinsPay.Core.Entities;

public class Cofrinho
{
    public Guid Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Saldo { get; set; }

    public decimal? Meta { get; set; }

    public Guid CarteiraId { get; set; }
}
