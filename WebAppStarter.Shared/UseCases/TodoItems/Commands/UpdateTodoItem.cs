using MediatR;

namespace WebAppStarter.Shared.UseCases.TodoItems.Commands;

public record UpdateTodoItemCommand : IRequest
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public bool Done { get; set; }
}