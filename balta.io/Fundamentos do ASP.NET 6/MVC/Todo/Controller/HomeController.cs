using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controller
{
    [ApiController]
    [Route("api/{controller}")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices] AppDbContext context)
            => Ok(context.todoModels.ToList());

        [HttpGet("{id:int}")]
        public IActionResult GetById([FromRoute] int id, [FromServices] AppDbContext context)
        {
            var todos = context.todoModels.FirstOrDefault(x => x.Id == id);
            if (todos == null)
                return NotFound();
            return Ok(todos);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            context.todoModels.Add(todo);
            context.SaveChanges();
            return Created($"/{todo.Id}", todo);
        }

        [HttpPut("{id}")]
        public IActionResult Put([FromRoute] int id, [FromBody] TodoModel todo, [FromServices] AppDbContext context)
        {
            TodoModel model = context.todoModels.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return NotFound();
            model.Title = todo.Title;
            model.Done = todo.Done;
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id, [FromServices] AppDbContext context)
        {
            TodoModel model = context.todoModels.FirstOrDefault(x => x.Id == id);
            if (model == null)
                return NotFound();
            context.todoModels.Remove(model);
            context.SaveChanges();
            return NoContent();
        }
    }
}