using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly SDbContext _context;

    public OwnersController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Owners>>> GetOwners()
    {
        return await _context.Owners.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Owners>> GetOwner(int id)
    {
        var owner = await _context.Owners.FindAsync(id);

        if (owner == null)
        {
            return NotFound();
        }

        return owner;
    }

    [HttpPost]
    public async Task<ActionResult<Owners>> PostOwner(Owners owner)
    {
        _context.Owners.Add(owner);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOwner), new { id = owner.Id }, owner);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOwner(int id, Owners owner)
    {
        if (id != owner.Id)
        {
            return BadRequest();
        }

        _context.Entry(owner).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!OwnerExists(id))
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
    public async Task<IActionResult> DeleteOwner(int id)
    {
        var owner = await _context.Owners.FindAsync(id);
        if (owner == null)
        {
            return NotFound();
        }

        _context.Owners.Remove(owner);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool OwnerExists(int id)
    {
        return _context.Owners.Any(e => e.Id == id);
    }
}
