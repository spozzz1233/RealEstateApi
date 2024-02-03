using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/real-estate")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly SDbContext _context;

        public RealEstateController(SDbContext context)
        {
            _context = context;
        }

        // GET: api/real-estate
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RealEstateResponse>>> GetRealEstates()
        {
            var realEstates = await _context.RealEstates
                .Join(_context.Trades,
                      re => re.Id,
                      trade => trade.EstateID,
                      (re, trade) => new { RealEstate = re, Trade = trade })
                .Join(_context.Addresses,
                      joined => joined.RealEstate.AddressId,
                      address => address.Id,
                      (joined, address) => new RealEstateResponse
                      {
                          Address = new Addresses
                          {
                              City = address.City,
                              Street = address.Street,
                              HouseNumber = address.HouseNumber,
                              FlatNumber = address.FlatNumber
                          },
                          Price = joined.Trade.Price,
                          TypeOfEstate = joined.RealEstate.TypeOfEstate
                      })
                .ToListAsync();

            return Ok(realEstates);
        }

        public class RealEstateResponse
        {
            public Addresses Address { get; set; }
            public decimal Price { get; set; }
            public string TypeOfEstate { get; set; }
        }
    }
}
