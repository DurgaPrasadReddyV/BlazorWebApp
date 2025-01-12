using MediatR;

namespace WebAppStarter.UseCases.Shared.TodoItems.Queries;

public record GetTodoItemByIdQuery : IRequest<TodoItemDto>
{
}
