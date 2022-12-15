using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteHostException : ConfabException
    {
        public Guid Id { get; set; }

        public CannotDeleteHostException(Guid id) : base($"Host with ID: '{id}' cannot be deleted.")
        {
            Id = id;
        }
    }
}
