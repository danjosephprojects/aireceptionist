using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Aireceptionist.Application.Interfaces;
using Aireceptionist.Domain.Entities;

namespace Aireceptionist.Infrastructure.Persistence;

public sealed class InMemoryReceptionRequestRepository : IReceptionRequestRepository
{
    private readonly ConcurrentDictionary<Guid, ReceptionRequest> _storage = new();

    public Task AddAsync(ReceptionRequest request, CancellationToken cancellationToken)
    {
        _storage[request.Id] = request;
        return Task.CompletedTask;
    }

    public Task<ReceptionRequest?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        _storage.TryGetValue(id, out var request);
        return Task.FromResult(request);
    }
}
