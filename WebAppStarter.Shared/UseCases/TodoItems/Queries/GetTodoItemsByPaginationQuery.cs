using MediatR;
using WebAppStarter.Shared.Common;

namespace WebAppStarter.Shared.UseCases.TodoItems.Queries;

public record GetTodoItemsByPaginationQuery : IRequest<PaginatedResult<TodoItemBriefDto>>
{
    public string? SearchKeywords { get; set; }
    public int PageNumber { get; set; } = 0;
    public int PageSize { get; set; } = 15;
    public string OrderBy { get; set; } = "Id";
    public string SortDirection { get; set; } = "Descending";
}
