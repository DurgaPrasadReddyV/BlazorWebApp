using FluentValidation;
using WebAppStarter.Shared.TodoItems.Commands;

namespace WebAppStarter.UseCases.TodoItems.Commands;

public class CreateTodoItemCommandValidator : AbstractValidator<CreateTodoItemCommand>
{
    public CreateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
