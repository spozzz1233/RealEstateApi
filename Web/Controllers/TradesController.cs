using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class TradesController : ControllerBase
{
    private readonly SDbContext _context;

    public TradesController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trades>>> GetTrades()
    {
        return await _context.Trades.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trades>> GetTrade(int id)
    {
        var trade = await _context.Trades.FindAsync(id);

        if (trade == null)
        {
            return NotFound();
        }

        return trade;
    }

    [HttpPost]
    public async Task<ActionResult<Trades>> PostTrade(Trades trade)
    {
        _context.Trades.Add(trade);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTrade), new { id = trade.Id }, trade);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrade(int id, Trades trade)
    {
        if (id != trade.Id)
        {
            return BadRequest();
        }

        _context.Entry(trade).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TradeExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrade(int id)
    {
        var trade = await _context.Trades.FindAsync(id);
        if (trade == null)
        {
            return NotFound();
        }

        _context.Trades.Remove(trade);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TradeExists(int id)
    {
        return _context.Trades.Any(e => e.Id == id);
    }
}
