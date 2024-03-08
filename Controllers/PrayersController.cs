using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class PrayersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrayersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrayerModel>>> GetPrayers()
    {
        return await _context.Prayers.ToListAsync();
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<PrayerModel>> GetPrayerModel(int id)
    {
        var prayerModel = await _context.Prayers.FindAsync(id);

        if (prayerModel == null)
        {
            return NotFound();
        }

        return prayerModel;
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPrayerModel(int id, PrayerModel prayerModel)
    {
        if (id != prayerModel.PrayerId)
        {
            return BadRequest();
        }

        _context.Entry(prayerModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PrayerModelExists(id))
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
    public async Task<ActionResult<PrayerModel>> PostPrayerModel(PrayerModel prayerModel)
    {
        _context.Prayers.Add(prayerModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrayerModel", new { id = prayerModel.PrayerId }, prayerModel);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePrayerModel(int id)
    {
        var prayerModel = await _context.Prayers.FindAsync(id);
        if (prayerModel == null)
        {
            return NotFound();
        }

        _context.Prayers.Remove(prayerModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PrayerModelExists(int id)
    {
        return _context.Prayers.Any(e => e.PrayerId == id);
    }
}
