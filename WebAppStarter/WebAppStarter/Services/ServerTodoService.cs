using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components;
using WebAppStarter.Shared.Authentication;
using MediatR;
using WebAppStarter.UseCases.TodoItems.Commands;
using WebAppStarter.Shared.UseCases.TodoItems.Commands;
using WebAppStarter.Domain.Entities;
using WebAppStarter.Shared.UseCases.TodoItems;
using WebAppStarter.Shared.UseCases.TodoItems.Queries;
using OneOf;
using WebAppStarter.Shared.Common;
using OneOf.Types;

namespace WebAppStarter.Services
{
    public class ServerTodoService : ITodoService
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly NavigationManager _navigationManager;
        private readonly IScopedMediator _mediator;

        public ServerTodoService(IAuthorizationService authorizationService,
             AuthenticationStateProvider authenticationStateProvider,
             NavigationManager navigationManager,
             IScopedMediator mediator)
        {
            _authorizationService = authorizationService;
            _authenticationStateProvider = authenticationStateProvider;
            _navigationManager = navigationManager;
            _mediator = mediator;
        }

        public async Task<OneOf<int, Shared.Common.HttpValidationProblemDetails, ProblemDetails>> AddAsync(CreateTodoItemCommand createTodoItemCommand)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!((await _authorizationService.AuthorizeAsync(authenticationState.User, AuthorizationPolicies.CanCreateTodoItem())).Succeeded))
            {
                _navigationManager.NavigateTo("AccessDenied");
                return 0;
            }

            return await _mediator.Send(createTodoItemCommand);
        }

        public async Task<OneOf<None, Shared.Common.HttpValidationProblemDetails, ProblemDetails>> DeleteAsync(DeleteTodoItemCommand deleteTodoItemCommand)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!((await _authorizationService.AuthorizeAsync(authenticationState.User, AuthorizationPolicies.CanDeleteTodoItem())).Succeeded))
            {
                _navigationManager.NavigateTo("AccessDenied");
            }

            await _mediator.Send(deleteTodoItemCommand);
            return new None();
        }

        public async Task<OneOf<IEnumerable<TodoItemBriefDto>, Shared.Common.HttpValidationProblemDetails, ProblemDetails>> GetAllAsync()
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!((await _authorizationService.AuthorizeAsync(authenticationState.User, AuthorizationPolicies.CanViewTodoItem())).Succeeded))
            {
                _navigationManager.NavigateTo("AccessDenied");
                return new List<TodoItemBriefDto>();
            }

           return await _mediator.Send(new GetTodoItemsByPaginationQuery());
        }

        public async Task<OneOf<TodoItemDto, Shared.Common.HttpValidationProblemDetails, ProblemDetails>> GetAsync(int id)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!((await _authorizationService.AuthorizeAsync(authenticationState.User, AuthorizationPolicies.CanViewTodoItem())).Succeeded))
            {
                _navigationManager.NavigateTo("AccessDenied");
                return new TodoItemDto();
            }

            return await _mediator.Send(new GetTodoItemByIdQuery() { Id = id});
        }

        public async Task<OneOf<None, Shared.Common.HttpValidationProblemDetails, ProblemDetails>> UpdateAsync(UpdateTodoItemCommand updateTodoItemCommand)
        {
            var authenticationState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            if (!((await _authorizationService.AuthorizeAsync(authenticationState.User, AuthorizationPolicies.CanUpdateTodoItem())).Succeeded))
            {
                _navigationManager.NavigateTo("AccessDenied");
            }

            await _mediator.Send(updateTodoItemCommand);
            return new None();
        }
    }
}
