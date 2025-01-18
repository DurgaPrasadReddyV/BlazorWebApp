using MediatR;

namespace WebAppStarter.Shared.UseCases.TodoItems.Queries;

public record GetTodoItemsByPaginationQuery : IRequest<List<TodoItemBriefDto>>
{
}
