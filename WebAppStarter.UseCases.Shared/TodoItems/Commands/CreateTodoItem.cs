using MediatR;

namespace WebAppStarter.UseCases.Shared.TodoItems.Commands;

public record CreateTodoItemCommand : IRequest<int>
{
    public int ListId { get; init; }

    public string? Title { get; init; }
}
