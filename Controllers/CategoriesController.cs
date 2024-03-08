using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oracap_App_API.Data;
using Oracap_App_API.Model;

namespace Oracap_App_API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryModel>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    [Authorize]
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

    [Authorize]
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

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<CategoryModel>> PostCategoryModel(CategoryModel categoryModel)
    {
        _context.Categories.Add(categoryModel);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategoryModel", new { id = categoryModel.CategoryId }, categoryModel);
    }

    [Authorize]
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
