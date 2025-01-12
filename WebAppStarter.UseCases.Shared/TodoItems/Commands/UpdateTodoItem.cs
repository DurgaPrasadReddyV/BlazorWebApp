using MediatR;

namespace WebAppStarter.UseCases.Shared.TodoItems.Commands;

public record UpdateTodoItemCommand : IRequest
{
    public int Id { get; init; }

    public string? Title { get; init; }

    public bool Done { get; init; }
}