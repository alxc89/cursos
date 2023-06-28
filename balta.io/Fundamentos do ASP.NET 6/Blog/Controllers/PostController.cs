using Blog.Data;
using Blog.Models;
using Blog.ViewModels;
using Blog.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers;
[ApiController]
public class PostController : ControllerBase
{
    [HttpGet("v1/posts")]
    public async Task<IActionResult> GetAsync([FromServices] BlogDataContext context, [FromQuery] int page = 0, [FromQuery] int pageSize = 25)
    {
        try
        {
            var count = await context.Posts.AsNoTracking().CountAsync();
            var posts = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Author)
                    .ThenInclude(user => user.Roles)
                .Select(post => new ListPostsViewModels
                {
                    Id = post.Id,
                    Title = post.Title,
                    Slug = post.Slug,
                    LastUpdateDate = post.LastUpdateDate,
                    Category = post.Category.Name,
                    Author = $"{post.Author.Name} ({post.Author.Email})"
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToListAsync();
            return Ok(new ResultViewModel<dynamic>(new
            {
                total = count,
                page,
                pageSize,
                posts
            }
            ));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("Falha interna no servidor"));
        }
    }
    [HttpGet("v1/post/{id:int}")]
    public async Task<IActionResult> DetailsAsync([FromServices] BlogDataContext context, [FromRoute] int id)
    {
        try
        {
            var post = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Author)
                    .ThenInclude(user => user.Roles)
                .Include(x => x.Category)
                .FirstOrDefaultAsync();
            if (post == null)
                return NotFound(new ResultViewModel<string>("Conteúdo não encontrado!"));
            return Ok(new ResultViewModel<Post>(post));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("Falha interna no servidor"));
        }
    }
    [HttpGet("v1/posts/{categoriy}")]
    public async Task<IActionResult> GetByCategory([FromServices] BlogDataContext context,
        [FromRoute] string category,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25)
    {
        try
        {
            var count = await context.Posts.AsNoTracking().CountAsync();
            var posts = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Where(post => post.Category.Slug == category)
                .Select(post => new ListPostsViewModels
                {
                    Id = post.Id,
                    Title = post.Title,
                    Slug = post.Slug,
                    LastUpdateDate = post.LastUpdateDate,
                    Category = post.Category.Name,
                    Author = $"{post.Author.Name} ({post.Author.Email})"
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();

            return Ok(new ResultViewModel<dynamic>(new
            {
                total = count,
                page,
                pageSize,
                posts
            }));
        }
        catch
        {
            return StatusCode(500, new ResultViewModel<List<Category>>("Falha interna no servidor"));
        }
    }
}