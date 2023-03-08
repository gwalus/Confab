using Confab.Modules.Agendas.Application.Submissions.DTO;
using Confab.Modules.Agendas.Application.Submissions.Queries;
using Confab.Modules.Agendas.Domain.Submissions.Entities;
using Confab.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Infrastructure.EF.Queries.Handlers
{
    internal sealed class GetSubmissionHandler : IQueryHandler<GetSubmission, SubmissionDto>
    {
        private readonly AgendasDbContext _dbContext;
        private DbSet<Submission> _submissions { get; set; }

        public GetSubmissionHandler(AgendasDbContext dbContext)
            => _submissions = dbContext.Submissions;

        public async Task<SubmissionDto> HandleAsync(GetSubmission query)
            => await _submissions
                .AsNoTracking()
                .Where(x => x.Id.Equals(query.Id))
                .Include(x => x.Speakers)
                .Select(x => new SubmissionDto
                {
                    Id = x.Id,
                    ConferenceId = x.ConferenceId,
                    Description = x.Description,
                    Title = x.Title,
                    Level = x.Level,
                    Status = x.Status,
                    Tags = x.Tags,
                    Speakers = x.Speakers.Select(s => new SpeakerDto
                    {
                        Id = s.Id,
                        FullName = s.FullName,
                    })
                })
                .SingleOrDefaultAsync();

    }
}
