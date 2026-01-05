using System;
using System.Threading;
using System.Threading.Tasks;
using Aireceptionist.Domain.Entities;

namespace Aireceptionist.Application.Interfaces;

public interface IReceptionRequestRepository
{
    Task AddAsync(ReceptionRequest request, CancellationToken cancellationToken);
    Task<ReceptionRequest?> GetAsync(Guid id, CancellationToken cancellationToken);
}
