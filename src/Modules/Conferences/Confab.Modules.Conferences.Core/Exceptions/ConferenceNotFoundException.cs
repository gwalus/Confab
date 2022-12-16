using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Conferences.Core.Exceptions
{
    internal class ConferenceNotFoundException : ConfabException
    {
        public Guid Id { get; set; }

        public ConferenceNotFoundException(Guid id) : base($"Conference with ID: '{id}' was not found.")
        {
            Id = id;
        }
    }
}
