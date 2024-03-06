using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryModel>> GetCategoryModel(int id)
    {
        var categoryModel = await _context.Categories.FindAsync(id);

        if (categoryModel == null)
        {
            return NotFound();
        }

        return categoryModel;
    }

    // PUT: api/Categories/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategoryModel(int id, CategoryModel categoryModel)
    {
        if (id != categoryModel.CategoryId)
        {
            return BadRequest();
        }

        _context.Entry(categoryModel).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryModelExists(id))
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

    // POST: api/Categories
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CategoryModel>> PostCategoryModel(CategoryModel categoryModel)
    {
        _context.Categories.Add(categoryModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategoryModel", new { id = categoryModel.CategoryId }, categoryModel);
    }

    // DELETE: api/Categories/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategoryModel(int id)
    {
        var categoryModel = await _context.Categories.FindAsync(id);
        if (categoryModel == null)
        {
            return NotFound();
        }

        _context.Categories.Remove(categoryModel);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoryModelExists(int id)
    {
        return _context.Categories.Any(e => e.CategoryId == id);
    }
}
