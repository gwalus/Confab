﻿using Confab.Modules.Agendas.Application.Submissions.Exceptions;
using Confab.Modules.Agendas.Domain.Submissions.Repositories;
using Confab.Shared.Abstractions.Commands;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Application.Submissions.Commands.Handlers
{
    public class ApproveSubmissionHandler : ICommandHandler<ApproveSubmission>
    {
        private readonly ISubmissionRepository _submissionRepository;

        public ApproveSubmissionHandler(ISubmissionRepository submissionRepository)
        {
            _submissionRepository = submissionRepository;
        }

        public async Task HandlerAsync(ApproveSubmission command)
        {
            var submission = await _submissionRepository.GetAsync(command.Id);

            if(submission is null)
            {
                throw new SubmissionNotFoundException(command.Id);
            }

            submission.Approve();

            await _submissionRepository.UpdateAsync(submission);
        }
    }
}