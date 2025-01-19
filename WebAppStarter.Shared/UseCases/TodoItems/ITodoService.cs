using OneOf;
using OneOf.Types;
using WebAppStarter.Shared.Common;
using WebAppStarter.Shared.UseCases.TodoItems.Commands;
using WebAppStarter.Shared.UseCases.TodoItems.Queries;

namespace WebAppStarter.Shared.UseCases.TodoItems;
public interface ITodoService
{
    Task<OneOf<PaginatedResult<TodoItemBriefDto>, HttpValidationProblemDetails, ProblemDetails>> GetByPaginationAsync(GetTodoItemsByPaginationQuery getTodoItemsByPaginationQuery);
    Task<OneOf<TodoItemDto, HttpValidationProblemDetails, ProblemDetails>> GetAsync(int id);
    Task<OneOf<int, HttpValidationProblemDetails, ProblemDetails>> AddAsync(CreateTodoItemCommand createTodoItemCommand);
    Task<OneOf<None, HttpValidationProblemDetails, ProblemDetails>> UpdateAsync(UpdateTodoItemCommand updateTodoItemCommand);
    Task<OneOf<None, HttpValidationProblemDetails, ProblemDetails>> DeleteAsync(DeleteTodoItemCommand deleteTodoItemCommand);    
}

