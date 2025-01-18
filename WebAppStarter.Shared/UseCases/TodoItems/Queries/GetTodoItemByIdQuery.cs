using MediatR;

namespace WebAppStarter.Shared.UseCases.TodoItems.Queries;

public record GetTodoItemByIdQuery : IRequest<TodoItemDto>
{
    public int Id { get; init; }
}
