namespace WebApplication1.Models
{
    public class Cotacao
    {
        public decimal cotacaoCompra { get; set; }
        public decimal cotacaoVenda { get; set; }
        public string dataHoraCotacao { get; set; }

        public string? tipoBoletim { get; set; }
    }
}
