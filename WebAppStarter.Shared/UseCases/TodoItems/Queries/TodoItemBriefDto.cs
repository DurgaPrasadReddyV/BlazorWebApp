﻿namespace WebAppStarter.Shared.UseCases.TodoItems.Queries;

public class TodoItemBriefDto
{
    public int? Id { get; set; }

    public string? Title { get; set; }

    public bool? IsCompleted { get; set; }

}
