using System;

namespace Aireceptionist.Application.Common;

public interface IClock
{
    DateTimeOffset UtcNow { get; }
}
