using Blog.Data;
using Blog.Extensions;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context, [FromServices] IMemoryCache cache)
        {
            try
            {
                var categories = cache.GetOrCreate("CategoriesCache", entry => {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1);
                    return GetGategories(context);
                });
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return StatusCode(500, new ResultViewModel<List<Category>>("Não foi possível incluir a categoria"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return StatusCode(500, new ResultViewModel<List<Category>>("Falha interna no servidor"));
            }
        }

        private List<Category> GetGategories(BlogDataContext context)
        {
            return context.Categories.ToList();
        }

        [HttpGet("v2/categories")]
        public IActionResult Get2([FromServices] BlogDataContext context)
        {
            var categories = context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("v1/categories/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context
                    .Categories
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));
                return Ok(new ResultViewModel<Category>(category));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync([FromBody] EditorCategoryViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = new Category { Id = 0, Name = model.Name, Slug = model.Slug.ToLower() };

                if (!ModelState.IsValid)
                    return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();
                return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possível incluir a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpPut("v1/categories/{id}")]
        public async Task<IActionResult> PutAsync([FromRoute] int id, [FromBody] EditorCategoryViewModel model, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context
                                .Categories
                                .FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

                category.Name = model.Name;
                category.Slug = model.Slug;
                context.Categories.Update(category);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Category>("Não foi possível alterar a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }

        [HttpDelete("v1/categories/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id, [FromServices] BlogDataContext context)
        {
            try
            {
                var category = await context
                        .Categories
                        .FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));

                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return StatusCode(500, new ResultViewModel<Category>("Não foi possível exluir a categoria"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Category>("Falha interna no servidor"));
            }
        }
    }
}