using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppStarter.Domain.Entities;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.UseCases.Mappings
{
    public class TodoItemProfile : Profile
    {
        public TodoItemProfile()
        {
            CreateMap<TodoItem, TodoItemDto>();
            CreateMap<TodoItem, TodoItemBriefDto>();
        }
    }
}
