using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Inventories;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class InventoriesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> GetAllCurrentInventories()
        {
            return Ok(await Mediator.Send(new List.Query()));
        }

        [HttpGet("portfolioId")]
        public async Task<ActionResult<List<Inventory>>> GetAllCurrentInventoriesByPortfolioId(int portfolioId)
        {
            return Ok(await Mediator.Send(new Details.Query{ PortfolioId = portfolioId}));
        }
    }
}