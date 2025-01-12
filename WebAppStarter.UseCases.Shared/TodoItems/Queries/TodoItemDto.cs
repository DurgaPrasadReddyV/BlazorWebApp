using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppStarter.UseCases.Shared.TodoItems.Queries
{
    public class TodoItemDto
    {
        public int? Id { get; set; }

        public string? Title { get; set; }

        public bool? IsCompleted { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CompletedDate { get; set; }
    }
}
