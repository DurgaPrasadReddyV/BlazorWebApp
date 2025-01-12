using FluentValidation;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.UseCases.TodoItems.Queries;

public class GetTodoItemByIdQueryValidator : AbstractValidator<GetTodoItemsByPaginationQuery>
{
    public GetTodoItemByIdQueryValidator()
    {
    }
}
