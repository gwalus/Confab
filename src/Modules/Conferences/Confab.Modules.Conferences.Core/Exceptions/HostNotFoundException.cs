using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class HostNotFoundException : ConfabException
    {
        public Guid Id { get; set; }

        public HostNotFoundException(Guid id) : base($"Host with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
