using System.Security.Claims;
using brokenaccesscontrol.Models;
using brokenaccesscontrol.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace brokenaccesscontrol.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoItemController : ControllerBase
{

    private readonly ILogger<ToDoItemController> _logger;

    public ToDoItemController(ILogger<ToDoItemController> logger)
    {
        _logger = logger;
    }   

    // GET: api/ToDoItem
    [HttpGet]
    public async Task<IEnumerable<TodoItem>> GetToDoItems()
    {
        return await TodoItemRepository.GetToDoItems();
    }

    // // // GET: api/ToDoItem/5
    // [HttpGet("{id}")]
    // [Authorize(Roles = "admin")]
    // public async Task<dynamic> GetToDoItemModel(int id)
    // {
    //     // var toDoItemModel = await _context.ToDoItems.FindAsync(id);

    //     // if (toDoItemModel == null)
    //     // {
    //     //     return NotFound();
    //     // }

    //     return new {
    //         Id = "asdfasdf",
    //         Name = "asdfasdf",
    //         Description = "asdfasdf",
    //         Teste = ((ClaimsIdentity)User.Identity).FindFirst("UserId").Value
    //     };
    // }




    // // PUT: api/ToDoItem/5
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutToDoItemModel(int id, ToDoItemModel toDoItemModel)
    // {
    //     if (id != toDoItemModel.ItemId)
    //     {
    //         return BadRequest();
    //     }

    //     _context.Entry(toDoItemModel).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!ToDoItemModelExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }

    //     return NoContent();
    // }

    // // POST: api/ToDoItem
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPost]
    // public async Task<ActionResult<ToDoItemModel>> PostToDoItemModel(ToDoItemModel toDoItemModel)
    // {
    //     _context.ToDoItems.Add(toDoItemModel);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction("GetToDoItemModel", new { id = toDoItemModel.ItemId }, toDoItemModel);
    // }

    // // DELETE: api/ToDoItem/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteToDoItemModel(int id)
    // {
    //     var toDoItemModel = await _context.ToDoItems.FindAsync(id);
    //     if (toDoItemModel == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.ToDoItems.Remove(toDoItemModel);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

    // private bool ToDoItemModelExists(int id)
    // {
    //     return _context.ToDoItems.Any(e => e.ItemId == id);
    // }  
}