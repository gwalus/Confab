﻿using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions
{
    public class MissingSubmissionSpeakersException : ConfabException
    {
        public Guid SubmissionId { get; set; }

        public MissingSubmissionSpeakersException(Guid submissionId)
            : base($"Submission with ID: '{submissionId}' has missing speakers.")
            => SubmissionId = submissionId;
    }
}