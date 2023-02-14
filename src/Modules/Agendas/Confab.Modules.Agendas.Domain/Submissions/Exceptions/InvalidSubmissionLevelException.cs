﻿using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions
{
    public class InvalidSubmissionLevelException : ConfabException
    {
        public Guid SubmissionId { get; set; }

        public InvalidSubmissionLevelException(Guid submissionId)
            : base($"Submission with ID: '{submissionId}' defines invalid level.")
            => SubmissionId = submissionId;
    }
}