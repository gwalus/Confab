using Confab.Shared.Abstractions;
using System;

namespace Confab.Shared.Infrastructure.Time
{
    internal class UtcClock : IClock
    {
        public DateTime CurrentDate() => DateTime.UtcNow;
    }
}