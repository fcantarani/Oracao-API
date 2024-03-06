using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ViewTypesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ViewTypesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/ViewTypes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ViewTypeModel>>> GetViewTypes()
    {
        return await _context.ViewTypes.ToListAsync();
    }

    // GET: api/ViewTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ViewTypeModel>> GetViewTypeModel(int id)
    {
        var viewTypeModel = await _context.ViewTypes.FindAsync(id);

        if (viewTypeModel == null)
        {
            return NotFound();
        }

        return viewTypeModel;
    }

    // PUT: api/ViewTypes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutViewTypeModel(int id, ViewTypeModel viewTypeModel)
    {
        if (id != viewTypeModel.ViewTypeId)
        {
            return BadRequest();
        }

        _context.Entry(viewTypeModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ViewTypeModelExists(id))
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

    // POST: api/ViewTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<ViewTypeModel>> PostViewTypeModel(ViewTypeModel viewTypeModel)
    {
        _context.ViewTypes.Add(viewTypeModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetViewTypeModel", new { id = viewTypeModel.ViewTypeId }, viewTypeModel);
    }

    // DELETE: api/ViewTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteViewTypeModel(int id)
    {
        var viewTypeModel = await _context.ViewTypes.FindAsync(id);
        if (viewTypeModel == null)
        {
            return NotFound();
        }

        _context.ViewTypes.Remove(viewTypeModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ViewTypeModelExists(int id)
    {
        return _context.ViewTypes.Any(e => e.ViewTypeId == id);
    }
}
