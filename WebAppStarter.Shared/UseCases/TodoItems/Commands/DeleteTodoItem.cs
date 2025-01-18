using MediatR;

namespace WebAppStarter.Shared.UseCases.TodoItems.Commands;

public record DeleteTodoItemCommand(int Id) : IRequest;
