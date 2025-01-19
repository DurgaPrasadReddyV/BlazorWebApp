using AutoMapper;
using MediatR;
using WebAppStarter.Shared.Common;
using WebAppStarter.Shared.UseCases.TodoItems.Queries;

namespace WebAppStarter.UseCases.TodoItems.Queries;

public class GetTodoItemsByPaginationQueryHandler : IRequestHandler<GetTodoItemsByPaginationQuery, PaginatedResult<TodoItemBriefDto>>
{
    private readonly IMapper _mapper;
    private readonly ITodoItemRepository _todoItemRepository;

    public GetTodoItemsByPaginationQueryHandler(IMapper mapper, ITodoItemRepository todoItemRepository)
    {
        _mapper = mapper;
        _todoItemRepository = todoItemRepository;
    }

    public async Task<PaginatedResult<TodoItemBriefDto>> Handle(GetTodoItemsByPaginationQuery request, CancellationToken cancellationToken)
    {
        var todoItems = await _todoItemRepository.RetrieveAllTodoItemsAsync();
        var todoItemsDto = _mapper.Map<List<TodoItemBriefDto>>(todoItems);
        return new PaginatedResult<TodoItemBriefDto>(todoItemsDto, todoItems.Count, 1, 15);
    }
}
