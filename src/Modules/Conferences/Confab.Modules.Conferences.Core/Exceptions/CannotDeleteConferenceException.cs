using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class CannotDeleteConferenceException : ConfabException
    {
        public Guid Id { get; set; }

        public CannotDeleteConferenceException(Guid id) : base($"Conference with ID: '{id}' cannot be deleted.")
        {
            Id = id;
        }
    }
}
