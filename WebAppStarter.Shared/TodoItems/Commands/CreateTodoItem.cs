using MediatR;

namespace WebAppStarter.Shared.TodoItems.Commands;

public record CreateTodoItemCommand : IRequest<int>
{
    public string? Title { get; init; }
}
