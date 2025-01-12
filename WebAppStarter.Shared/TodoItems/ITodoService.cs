using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.Shared.TodoItems;
public interface ITodoService
{
    IEnumerable<TodoItemDto> GetAllAsync();
    TodoItemDto GetAsync(long id);
    Task AddAsync(TodoItemDto todoItem);
    Task UpdateAsync(TodoItemDto todoItem);
    Task DeleteAsync(TodoItemDto todoItem);
}

