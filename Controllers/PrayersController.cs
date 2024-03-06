using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PrayersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PrayersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Prayers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PrayerModel>>> GetPrayers()
    {
        return await _context.Prayers.ToListAsync();
    }

    // GET: api/Prayers/5
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

    // PUT: api/Prayers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // POST: api/Prayers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<PrayerModel>> PostPrayerModel(PrayerModel prayerModel)
    {
        _context.Prayers.Add(prayerModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPrayerModel", new { id = prayerModel.PrayerId }, prayerModel);
    }

    // DELETE: api/Prayers/5
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
