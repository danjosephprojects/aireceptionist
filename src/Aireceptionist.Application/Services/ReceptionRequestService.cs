using System;
using System.Threading;
using System.Threading.Tasks;
using Aireceptionist.Application.Common;
using Aireceptionist.Application.Contracts;
using Aireceptionist.Application.Interfaces;
using Aireceptionist.Domain.Entities;

namespace Aireceptionist.Application.Services;

public sealed class ReceptionRequestService : IReceptionRequestService
{
    private readonly IReceptionRequestRepository _repository;
    private readonly IClock _clock;

    public ReceptionRequestService(IReceptionRequestRepository repository, IClock clock)
    {
        _repository = repository;
        _clock = clock;
    }

    public async Task<ReceptionRequestResponse> CreateAsync(
        CreateReceptionRequestRequest request,
        CancellationToken cancellationToken)
    {
        var entity = new ReceptionRequest(
            Guid.NewGuid(),
            request.CallerName,
            request.CallerNumber,
            request.Message,
            _clock.UtcNow);

        await _repository.AddAsync(entity, cancellationToken);

        return new ReceptionRequestResponse(
            entity.Id,
            entity.CallerName,
            entity.CallerNumber,
            entity.Message,
            entity.ReceivedAt,
            entity.Status);
    }
}
