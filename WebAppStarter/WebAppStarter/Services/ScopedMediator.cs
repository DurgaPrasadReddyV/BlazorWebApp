using MediatR;
using System.Runtime.CompilerServices;

namespace WebAppStarter.Services;

public class ScopedMediator : IScopedMediator
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ScopedMediator(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<TResponse> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            TResponse response = await mediator.Send(request, cancellationToken);

            return response;
        }
    }

    public async Task Send<TRequest>(TRequest request, CancellationToken cancellationToken = default)
        where TRequest : IRequest
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Send(request, cancellationToken);
        }
    }

    public async Task<object?> Send(object request, CancellationToken cancellationToken = default)
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            object? response = await mediator.Send(request, cancellationToken);

            return response;
        }
    }

    public async Task Publish<TNotification>(
        TNotification notification,
        CancellationToken cancellationToken = default)
        where TNotification : INotification
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Publish(notification, cancellationToken);
        }
    }

    public async Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            await mediator.Publish(notification, cancellationToken);
        }
    }

    public async IAsyncEnumerable<TResponse> CreateStream<TResponse>(
        IStreamRequest<TResponse> request,
        [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            IAsyncEnumerable<TResponse> items = mediator.CreateStream(request, cancellationToken);

            await foreach (TResponse item in items)
            {
                yield return item;
            }
        }
    }

    public async IAsyncEnumerable<object?> CreateStream(
        object request,
        [EnumeratorCancellation]
            CancellationToken cancellationToken = default)
    {
        AsyncServiceScope scope = _scopeFactory.CreateAsyncScope();
        await using (scope.ConfigureAwait(false))
        {
            IMediator mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            IAsyncEnumerable<object?> items = mediator.CreateStream(request, cancellationToken);

            await foreach (object? item in items)
            {
                yield return item;
            }
        }
    }
}