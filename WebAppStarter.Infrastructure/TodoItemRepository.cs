using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;
using WebAppStarter.Domain.Entities;
using WebAppStarter.UseCases.TodoItems;

namespace WebAppStarter.Infrastructure
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ILogger<TodoItemRepository> _logger;
        private readonly List<TodoItem> _todoItems = new();
        private int _idCounter = 0;

        public TodoItemRepository(ILogger<TodoItemRepository> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<TodoItem>> RetrieveAllTodoItemsAsync()
        {
            try
            {
                List<TodoItem> result = _todoItems;
                await Task.CompletedTask;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving to-do items from repository.");
                throw;
            }
        }

        public async Task<TodoItem?> RetrieveTodoItemByIdOrNullAsync(int id)
        {
            ArgumentOutOfRangeException.ThrowIfLessThanOrEqual(id, 0);

            try
            {
                TodoItem? result = _todoItems.Where(x => x.Id == id).FirstOrDefault();

                await Task.CompletedTask;

                if (result is null)
                {
                    _logger.LogWarning("No to-do items with Id {id} found in repository.", id);
                    return null;
                }

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving to-do item Id {id} from repository.", id);
                throw;
            }
        }

        public async Task<int> CreateTodoItemAsync(TodoItem entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            try
            {
                entity.Id = _idCounter;
                entity.CreatedDate = DateTime.UtcNow;
                _todoItems.Add(entity); 
                _idCounter++;
                await Task.CompletedTask;
                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to insert a new to-do item.");
                throw;
            }
        }

        public async Task UpdateTodoItemAsync(TodoItem entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            try
            {
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to update to-do item Id {id}.", entity.Id);
                throw;
            }
        }

        public async Task DeleteTodoItemAsync(int entityId)
        {
            try
            {
                _todoItems.RemoveAt(entityId);
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to delete to-do item Id {id}.", entityId);
                throw;
            }
        }
    }
}
