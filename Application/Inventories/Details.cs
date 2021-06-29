using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Inventories
{
    public class Details
    {
        public class Query : IRequest<List<Inventory>>
        {
            public int PortfolioId { get; set; }
        }

        public class Handler : IRequestHandler<Query, List<Inventory>>
        {
            private readonly DataContext __context;
            public Handler(DataContext context)
            {
                __context = context;

            }

            public async Task<List<Inventory>> Handle(Query request, CancellationToken cancellationToken)
            {
                
                var portfolios = await __context.Portfolios.Where(x => x.PortfolioId.Equals(request.PortfolioId)).ToListAsync();
                var securities = await __context.Securities.ToListAsync();
                var holdings = await __context.Holdings.ToListAsync();

                // Join them all. 
                var currentHoldings = (from holding in holdings
                                    join portfolio in portfolios on holding.PortfolioId equals portfolio.PortfolioId
                                    join security in securities on holding.SecurityId equals security.SecurityId
                                    select new Inventory
                                    {
                                        Id = holding.Id,
                                        PortfolioId = portfolio.PortfolioId,
                                        PortfolioName = portfolio.PortfolioName,
                                        Sector = security.Sector,
                                        Security = security.SecurityName,
                                        MarketValue = holding.MarketValue
                                    }).ToList();
                return currentHoldings;
            }
        }
    }
}