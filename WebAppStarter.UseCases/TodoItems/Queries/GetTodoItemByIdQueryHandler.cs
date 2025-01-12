using AutoMapper;
using MediatR;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.UseCases.TodoItems.Queries;

public class GetTodoItemByIdQueryHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemDto>
{
    private readonly IMapper _mapper;
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemByIdQueryHandler(IMapper mapper, ITodoItemRepository todoItemRepository)
    {
        _mapper = mapper;
        _todoItemRepository = todoItemRepository;
    }

    public async Task<TodoItemDto> Handle(GetTodoItemByIdQuery request, CancellationToken cancellationToken)
    {
        var todoItem = await _todoItemRepository.RetrieveTodoItemByIdOrNullAsync(request.Id);
        return _mapper.Map<TodoItemDto>(todoItem);
    }
}
