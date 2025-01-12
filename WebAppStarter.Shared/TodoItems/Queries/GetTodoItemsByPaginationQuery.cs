using MediatR;

namespace WebAppStarter.Shared.TodoItems.Queries;

public record GetTodoItemsByPaginationQuery : IRequest<List<TodoItemBriefDto>>
{
}
