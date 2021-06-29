namespace Domain
{
    public class Inventory
    {
        public int Id { get; set; }
        public int PortfolioId { get; set; }
        public string PortfolioName { get; set; }
        public string Security { get; set; }
        public string Sector { get; set; }
        public double MarketValue { get; set; }
    }
}