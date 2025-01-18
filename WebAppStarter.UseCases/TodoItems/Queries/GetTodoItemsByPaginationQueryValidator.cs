using FluentValidation;
using WebAppStarter.Shared.UseCases.TodoItems.Queries;

namespace WebAppStarter.UseCases.TodoItems.Queries;

public class GetTodoItemsByPaginationQueryValidator : AbstractValidator<GetTodoItemsByPaginationQuery>
{
    public GetTodoItemsByPaginationQueryValidator()
    {
    }
}
