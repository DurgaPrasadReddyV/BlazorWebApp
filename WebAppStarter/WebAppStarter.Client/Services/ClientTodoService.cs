using OneOf;
using OneOf.Types;
using WebAppStarter.Shared.Common;
using WebAppStarter.Shared.UseCases.TodoItems;
using WebAppStarter.Shared.UseCases.TodoItems.Commands;
using WebAppStarter.Shared.UseCases.TodoItems.Queries;

namespace WebAppStarter.Client.Services
{
    public class ClientTodoService : ITodoService
    {
        public Task<OneOf<int, HttpValidationProblemDetails, ProblemDetails>> AddAsync(CreateTodoItemCommand createTodoItemCommand)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<None, HttpValidationProblemDetails, ProblemDetails>> DeleteAsync(DeleteTodoItemCommand deleteTodoItemCommand)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<PaginatedResult<TodoItemBriefDto>, HttpValidationProblemDetails, ProblemDetails>> GetByPaginationAsync(GetTodoItemsByPaginationQuery getTodoItemsByPaginationQuery)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<TodoItemDto, HttpValidationProblemDetails, ProblemDetails>> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OneOf<None, HttpValidationProblemDetails, ProblemDetails>> UpdateAsync(UpdateTodoItemCommand updateTodoItemCommand)
        {
            throw new NotImplementedException();
        }
    }
}
