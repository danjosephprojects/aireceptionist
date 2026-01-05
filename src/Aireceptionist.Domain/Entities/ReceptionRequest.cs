using System;

namespace Aireceptionist.Domain.Entities;

public sealed class ReceptionRequest
{
    public ReceptionRequest(Guid id, string callerName, string callerNumber, string message, DateTimeOffset receivedAt)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Id cannot be empty.", nameof(id));
        }

        CallerName = string.IsNullOrWhiteSpace(callerName)
            ? throw new ArgumentException("Caller name is required.", nameof(callerName))
            : callerName.Trim();
        CallerNumber = string.IsNullOrWhiteSpace(callerNumber)
            ? throw new ArgumentException("Caller number is required.", nameof(callerNumber))
            : callerNumber.Trim();
        Message = string.IsNullOrWhiteSpace(message)
            ? throw new ArgumentException("Message is required.", nameof(message))
            : message.Trim();
        ReceivedAt = receivedAt;
        Id = id;
        Status = ReceptionRequestStatus.Pending;
    }

    public Guid Id { get; }
    public string CallerName { get; }
    public string CallerNumber { get; }
    public string Message { get; }
    public DateTimeOffset ReceivedAt { get; }
    public ReceptionRequestStatus Status { get; private set; }

    public void MarkCompleted()
    {
        Status = ReceptionRequestStatus.Completed;
    }
}
