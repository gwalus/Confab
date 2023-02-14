﻿using Confab.Shared.Abstractions.Exceptions;
using System;

namespace Confab.Modules.Agendas.Domain.Submissions.Exceptions
{
    public class EmptySubmissionTitleException : ConfabException
    {
        public Guid SubmissionId { get; set; }

        public EmptySubmissionTitleException(Guid submissionId) 
            : base($"Submission with ID: '{submissionId}' defines empty title.")
            => SubmissionId = submissionId;
    }
}