using AutoMapper;
using MediatR;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.UseCases.TodoItems.Queries;

public class GetTodoItemsByPaginationQueryHandler : IRequestHandler<GetTodoItemsByPaginationQuery, List<TodoItemBriefDto>>
{
    private readonly IMapper _mapper;
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemsByPaginationQueryHandler(IMapper mapper, ITodoItemRepository todoItemRepository)
    {
        _mapper = mapper;
        _todoItemRepository = todoItemRepository;
    }

    public async Task<List<TodoItemBriefDto>> Handle(GetTodoItemsByPaginationQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _todoItemRepository.RetrieveAllTodoItemsAsync();
        return _mapper.Map<List<TodoItemBriefDto>>(todoItems);
    }
}
