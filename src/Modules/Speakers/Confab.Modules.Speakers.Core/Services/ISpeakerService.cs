using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.Services
{
    internal interface ISpeakerService
    {
        Task AddAsync(SpeakerDto dto);
        Task<SpeakerDto> GetAsync(Guid speakerId);
        Task<IReadOnlyList<SpeakerDto>> BrowseAsync();
        Task UpdateAsync(SpeakerDto dto);
        Task DeleteAsync(Guid id);
    }
}