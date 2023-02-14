using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions
{
    public class InvalidSubmissionStatusException : ConfabException
    {
        public Guid SubmissionId { get; set; }

        public InvalidSubmissionStatusException(Guid submissionId, string desiredStatus, string currectStatus)
            : base($"Cannot change status of submission with ID: '{submissionId}' from {currectStatus} to {desiredStatus}.")
            => SubmissionId = submissionId;
    }
}