using MediatR;

namespace WebAppStarter.UseCases.Shared.TodoItems.Commands;

public record DeleteTodoItemCommand(int Id) : IRequest;
