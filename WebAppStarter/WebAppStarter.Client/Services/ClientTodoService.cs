using WebAppStarter.Shared.TodoItems;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.Client.Services
{
    public class ClientTodoService : ITodoService
    {
        public Task AddAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TodoItemDto GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
