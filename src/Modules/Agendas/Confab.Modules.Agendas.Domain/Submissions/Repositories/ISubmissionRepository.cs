﻿using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Shared.Abstractions.Kernel.Types;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Domain.Submissions.Repositories
{
    public interface ISubmissionRepository
    {
        Task<Submission> GetAsync(AggregateId id);
        Task AddAsync(Submission submission);
        Task UpdateAsync(Submission submission);
    }
}