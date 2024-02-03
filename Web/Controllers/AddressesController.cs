using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class AddressesController : ControllerBase
{
    private readonly SDbContext _context;

    public AddressesController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Addresses>>> GetAddresses()
    {
        return await _context.Addresses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Addresses>> GetAddress(int id)
    {
        var address = await _context.Addresses.FindAsync(id);

        if (address == null)
        {
            return NotFound();
        }

        return address;
    }

    [HttpPost]
    public async Task<ActionResult<Addresses>> PostAddress(Addresses address)
    {
        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAddress), new { id = address.Id }, address);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAddress(int id, Addresses address)
    {
        if (id != address.Id)
        {
            return BadRequest();
        }

        _context.Entry(address).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AddressExists(id))
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
    public async Task<IActionResult> DeleteAddress(int id)
    {
        var address = await _context.Addresses.FindAsync(id);
        if (address == null)
        {
            return NotFound();
        }

        _context.Addresses.Remove(address);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AddressExists(int id)
    {
        return _context.Addresses.Any(e => e.Id == id);
    }
}
