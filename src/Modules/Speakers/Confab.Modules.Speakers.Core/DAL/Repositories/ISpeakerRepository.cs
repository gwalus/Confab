using Confab.Modules.Speakers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.DAL.Repositories
{
    internal interface ISpeakerRepository
    {
        Task<Speaker> GetAsync(Guid id);
        Task<IReadOnlyList<Speaker>> BrowseAsync();
        Task AddAsync(Speaker speaker);
        Task UpdateAsync(Speaker speaker);
        Task DeleteAsync(Speaker speaker);
        Task<bool> ExistsAsync(Guid speakerId);
    }
}