using Confab.Modules.Speakers.Core.DAL.Repositories;
using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Exceptions;
using Confab.Modules.Speakers.Core.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Core.Services
{
    internal class SpeakerService : ISpeakerService
    {
        private readonly ISpeakerRepository _repository;

        public SpeakerService(ISpeakerRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(SpeakerDto speaker)
        {
            var alreadyExists = await _repository.ExistsAsync(speaker.Id);
            
            if (alreadyExists)
            {
                throw new SpeakerAlreadyExistsException(speaker.Id);
            }

            await _repository.AddAsync(speaker.AsEntity());
        }

        public async Task<IReadOnlyList<SpeakerDto>> BrowseAsync()
        {
            var entities = await _repository.BrowseAsync();

            return (IReadOnlyList<SpeakerDto>)(entities?.Select(e => e.AsDto()));
        }

        public async Task DeleteAsync(Guid id)
        {
            var speaker = await _repository.GetAsync(id);

            if(speaker != null)
            {
                await _repository.DeleteAsync(speaker);
            }
        }

        public async Task<SpeakerDto> GetAsync(Guid speakerId)
        {
            var entity = await _repository.GetAsync(speakerId);

            if (entity is null)
            {
                throw new SpeakerNotFoundException(speakerId);
            }

            return entity.AsDto();
        } 

        public async Task UpdateAsync(SpeakerDto speaker)
        {
            var exists = await _repository.ExistsAsync(speaker.Id);

            if (!exists)
            {
                throw new SpeakerNotFoundException(speaker.Id);
            }

            await _repository.UpdateAsync(speaker.AsEntity());
        }
    }
}