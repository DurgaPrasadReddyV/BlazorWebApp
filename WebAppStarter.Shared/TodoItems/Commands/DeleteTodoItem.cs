using MediatR;

namespace WebAppStarter.Shared.TodoItems.Commands;

public record DeleteTodoItemCommand(int Id) : IRequest;
