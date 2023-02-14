﻿using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions
{
    public class EmptySubmissionDescriptionException : ConfabException
    {
        public Guid SubmissionId { get; set; }

        public EmptySubmissionDescriptionException(Guid submissionId)
            : base($"Submission with ID: '{submissionId}' defines empty description.")
            => SubmissionId = submissionId;
    }
}