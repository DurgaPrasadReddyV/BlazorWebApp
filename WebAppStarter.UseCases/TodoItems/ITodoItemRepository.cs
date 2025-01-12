using WebAppStarter.Domain.Entities;

namespace WebAppStarter.UseCases.TodoItems
{
    public interface ITodoItemRepository
    {
        Task<int> CreateTodoItemAsync(TodoItem entity);
        Task DeleteTodoItemAsync(int entityId);
        Task<List<TodoItem>> RetrieveAllTodoItemsAsync();
        Task<TodoItem?> RetrieveTodoItemByIdOrNullAsync(int id);
        Task UpdateTodoItemAsync(TodoItem entity);
    }
}