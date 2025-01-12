using MediatR;
using WebAppStarter.Domain.Entities;
using WebAppStarter.Shared.TodoItems.Commands;

namespace WebAppStarter.UseCases.TodoItems.Commands;

public class CreateTodoItemCommandHandler : IRequestHandler<CreateTodoItemCommand, int>
{
    ITodoItemRepository _todoItemRepository;

    public CreateTodoItemCommandHandler(ITodoItemRepository todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    public async Task<int> Handle(CreateTodoItemCommand request, CancellationToken cancellationToken)
    {
        var entity = new TodoItem
        {
            Title = request.Title,
        };

        int entityId = await _todoItemRepository.CreateTodoItemAsync(entity);
        return entityId;
    }
}
