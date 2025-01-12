using MediatR;
using WebAppStarter.Shared.TodoItems.Commands;

namespace WebAppStarter.UseCases.TodoItems.Commands;

public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteTodoItemCommand>
{
    ITodoItemRepository _todoItemRepository;

    public DeleteTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task Handle(DeleteTodoItemCommand request, CancellationToken cancellationToken)
    {
        await _todoItemRepository.DeleteTodoItemAsync(request.Id);
    }
}
