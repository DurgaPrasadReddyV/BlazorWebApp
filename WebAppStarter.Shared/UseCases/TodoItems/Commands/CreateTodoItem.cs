using MediatR;

namespace WebAppStarter.Shared.UseCases.TodoItems.Commands;

public record CreateTodoItemCommand : IRequest<int>
{
    public string? Title { get; set; }
}
