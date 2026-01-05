using System.Threading;
using System.Threading.Tasks;
using Aireceptionist.Application.Contracts;

namespace Aireceptionist.Application.Interfaces;

public interface IReceptionRequestService
{
    Task<ReceptionRequestResponse> CreateAsync(
        CreateReceptionRequestRequest request,
        CancellationToken cancellationToken);
}
