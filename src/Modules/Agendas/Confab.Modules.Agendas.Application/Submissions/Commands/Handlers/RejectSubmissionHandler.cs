﻿using Confab.Modules.Agendas.Application.Submissions.Exceptions;
using Confab.Modules.Agendas.Domain.Submissions.Repositories;
using Confab.Shared.Abstractions.Commands;
using Confab.Shared.Abstractions.Kernel;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Application.Submissions.Commands.Handlers
{
    public class RejectSubmissionHandler : ICommandHandler<RejectSubmission>
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IDomainEventDispatcher _domainEventDispatcher;

        public RejectSubmissionHandler(ISubmissionRepository submissionRepository, IDomainEventDispatcher domainEventDispatcher)
        {
            _submissionRepository = submissionRepository;
            _domainEventDispatcher = domainEventDispatcher;
        }

        public async Task HandlerAsync(RejectSubmission command)
        {
            var submission = await _submissionRepository.GetAsync(command.Id);

            if (submission is null)
            {
                throw new SubmissionNotFoundException(command.Id);
            }

            submission.Reject();

            await _submissionRepository.UpdateAsync(submission);
            await _domainEventDispatcher.DispatchAsync(submission.Events.ToArray());
        }
    }
}
