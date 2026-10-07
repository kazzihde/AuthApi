using Microsoft.AspNetCore.Mvc;
using AuthApi.Models;
using System.Net.NetworkInformation;

namespace AuthApi.Controllers;

[ApiController]
[Route("todos")]
public class TodosController : ControllerBase
{
    static List<TodoItem> todoItems = new();

    [HttpGet]
    public IActionResult GetTodos()
    {
        return Ok(todoItems);
    }

    [HttpPost]
    public IActionResult PostTodos(TodoItem item)
    {
        item.Id = todoItems.Count == 0 ? 1 : todoItems.Max(t => t.Id) + 1;
        todoItems.Add(item);
        return Ok(item);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteTodos(int id)
    {
        for (int i = 0; i < todoItems.Count; i++)
        {
            var item = todoItems[i];
            if (item.Id == id)
            {
                todoItems.Remove(item);
                return NoContent();
            }
        }
        return NotFound();
    }
}