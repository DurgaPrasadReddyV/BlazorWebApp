using MediatR;
using WebAppStarter.Domain.Entities;
using WebAppStarter.Shared.TodoItems.Commands;

namespace WebAppStarter.UseCases.TodoItems.Commands;

public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateTodoItemCommand>
{
    ITodoItemRepository _todoItemRepository;

    public UpdateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task Handle(UpdateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var updatingEntity = new TodoItem
        {
            Title = request.Title,
        };

        await _todoItemRepository.UpdateTodoItemAsync(updatingEntity);
    }
}
