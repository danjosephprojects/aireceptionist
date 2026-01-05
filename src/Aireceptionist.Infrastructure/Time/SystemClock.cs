using System;
using Aireceptionist.Application.Common;

namespace Aireceptionist.Infrastructure.Time;

public sealed class SystemClock : IClock
{
    public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
}
