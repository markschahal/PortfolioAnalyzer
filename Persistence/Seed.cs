using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Portfolios != null && !context.Portfolios.Any())
            {
                var portfolios = new List<Portfolio>
                {
                    new Portfolio
                    {
                        PortfolioId = 12,
                        PortfolioName = "AJ Industirals"
                    }, 
                    new Portfolio
                    {
                        PortfolioId = 34,
                        PortfolioName = "Karna Association"
                    }
                };                             
                await context.Portfolios.AddRangeAsync(portfolios);
            }

            if (context.Securities != null && !context.Securities.Any())
            {
                var securities = new List<Security>
                {
                    new Security
                    {
                        SecurityId = 444,
                        SecurityName = "Tesla Inc",
                        Sector = "Automobile"
                    },
                    new Security
                    {
                        SecurityId = 555,
                        SecurityName = "T-Mobile Inc",
                        Sector = "Communications"
                    },
                    new Security
                    {
                        SecurityId = 888,
                        SecurityName = "Zoom",
                        Sector = "Technology"
                    }
                };
                await context.Securities.AddRangeAsync(securities);
            }
            
            if (context.Holdings != null && !context.Holdings.Any())
            {            
                var holdings = new List<Holding>
                {
                    new Holding
                    {
                        PortfolioId = 12,
                        SecurityId = 444,
                        MarketValue = 90000000                                                                                
                    },
                    new Holding
                    {
                        PortfolioId = 12,
                        SecurityId = 555,
                        MarketValue = 30000000
                    },
                    new Holding
                    {
                        PortfolioId = 34,
                        SecurityId = 555,
                        MarketValue = 100000000
                    },
                    new Holding
                    {
                        PortfolioId = 34,
                        SecurityId = 888,
                        MarketValue = 1000000
                    }
                };
                await context.Holdings.AddRangeAsync(holdings);
            }
            
            await context.SaveChangesAsync();
        }
    }
}