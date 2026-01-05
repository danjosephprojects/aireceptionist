namespace Aireceptionist.Application.Contracts;

public sealed record CreateReceptionRequestRequest(
    string CallerName,
    string CallerNumber,
    string Message);
