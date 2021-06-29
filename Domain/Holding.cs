namespace Domain
{
    public class Holding
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public int SecurityId { get; set; }
        public double MarketValue { get; set; }
    }
}