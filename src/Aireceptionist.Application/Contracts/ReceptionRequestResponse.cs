using System;
using Aireceptionist.Domain.Entities;

namespace Aireceptionist.Application.Contracts;

public sealed record ReceptionRequestResponse(
    Guid Id,
    string CallerName,
    string CallerNumber,
    string Message,
    DateTimeOffset ReceivedAt,
    ReceptionRequestStatus Status);
