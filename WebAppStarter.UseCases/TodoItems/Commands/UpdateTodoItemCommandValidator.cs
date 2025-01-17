﻿using FluentValidation;
using WebAppStarter.Shared.UseCases.TodoItems.Commands;

namespace WebAppStarter.UseCases.TodoItems.Commands;

public class UpdateTodoItemCommandValidator : AbstractValidator<UpdateTodoItemCommand>
{
    public UpdateTodoItemCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
