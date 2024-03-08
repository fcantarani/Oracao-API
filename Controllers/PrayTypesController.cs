using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PrayTypesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrayTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrayTypeModel>>> GetPrayTypes()
    {
        return await _context.PrayTypes.ToListAsync();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<PrayTypeModel>> GetPrayTypeModel(int id)
    {
        var prayTypeModel = await _context.PrayTypes.FindAsync(id);

        if (prayTypeModel == null)
        {
            return NotFound();
        }

        return prayTypeModel;
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPrayTypeModel(int id, PrayTypeModel prayTypeModel)
    {
        if (id != prayTypeModel.PrayTypeId)
        {
            return BadRequest();
        }

        _context.Entry(prayTypeModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrayTypeModelExists(id))
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

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<PrayTypeModel>> PostPrayTypeModel(PrayTypeModel prayTypeModel)
    {
        _context.PrayTypes.Add(prayTypeModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrayTypeModel", new { id = prayTypeModel.PrayTypeId }, prayTypeModel);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrayTypeModel(int id)
    {
        var prayTypeModel = await _context.PrayTypes.FindAsync(id);
        if (prayTypeModel == null)
        {
            return NotFound();
        }

        _context.PrayTypes.Remove(prayTypeModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PrayTypeModelExists(int id)
    {
        return _context.PrayTypes.Any(e => e.PrayTypeId == id);
    }
}
