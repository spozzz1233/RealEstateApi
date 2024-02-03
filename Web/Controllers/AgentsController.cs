using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

[ApiController]
[Route("api/[controller]")]
public class AgentsController : ControllerBase
{
    private readonly SDbContext _context;

    public AgentsController(SDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agents>>> GetAgents()
    {
        return await _context.Agents.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Agents>> GetAgent(int id)
    {
        var agent = await _context.Agents.FindAsync(id);

        if (agent == null)
        {
            return NotFound();
        }

        return agent;
    }

    [HttpPost]
    public async Task<ActionResult<Agents>> PostAgent(Agents agent)
    {
        _context.Agents.Add(agent);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAgent), new { id = agent.Id }, agent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAgent(int id, Agents agent)
    {
        if (id != agent.Id)
        {
            return BadRequest();
        }

        _context.Entry(agent).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AgentExists(id))
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
    public async Task<IActionResult> DeleteAgent(int id)
    {
        var agent = await _context.Agents.FindAsync(id);
        if (agent == null)
        {
            return NotFound();
        }

        _context.Agents.Remove(agent);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AgentExists(int id)
    {
        return _context.Agents.Any(e => e.Id == id);
    }
}
