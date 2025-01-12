using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using WebAppStarter.Shared.TodoItems;
using WebAppStarter.Shared.TodoItems.Queries;

namespace WebAppStarter.Services
{
    public class ServerTodoService : ITodoService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;

        public ServerTodoService(IAuthorizationService authorizationService,
             AuthenticationStateProvider authenticationStateProvider,
             NavigationManager navigationManager)
        {
            _authorizationService = authorizationService;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
        }

        public Task AddAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TodoItemDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public TodoItemDto GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TodoItemDto todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
