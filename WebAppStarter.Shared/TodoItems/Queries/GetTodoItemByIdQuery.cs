using MediatR;

namespace WebAppStarter.Shared.TodoItems.Queries;

public record GetTodoItemByIdQuery : IRequest<TodoItemDto>
{
    public int Id { get; init; }
}
