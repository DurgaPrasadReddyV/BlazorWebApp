using MediatR;

namespace WebAppStarter.UseCases.Shared.TodoItems.Queries;

public record GetTodoItemsByPaginationQuery : IRequest<List<TodoItemBriefDto>>
{
}
