﻿using Confab.Modules.Conferences.Core.DTO;
using Confab.Modules.Conferences.Core.Entities;
using Confab.Modules.Conferences.Core.Events;
using Confab.Modules.Conferences.Core.Exceptions;
using Confab.Modules.Conferences.Core.Policies;
using Confab.Modules.Conferences.Core.Repositories;
using Confab.Shared.Abstractions.Messaging;
//using Confab.Modules.Conferences.Messages.Events;
//using Confab.Shared.Abstractions.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Confab.Modules.Conferences.Core.Services
{
    internal class ConferenceService : IConferenceService
    {
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IHostRepository _hostRepository;
        private readonly IConferenceDeletionPolicy _conferenceDeletionPolicy;
        //private readonly IEventDispatcher _eventDispatcher; // 1
        //private readonly IModuleClient _moduleClient; // 2
        private readonly IMessageBroker _messageBroker; // 3

        public ConferenceService(IConferenceRepository conferenceRepository, IHostRepository hostRepository, IConferenceDeletionPolicy conferenceDeletionPolicy,
            IMessageBroker messageBroker)
        {
            _conferenceRepository = conferenceRepository;
            _hostRepository = hostRepository;
            _conferenceDeletionPolicy = conferenceDeletionPolicy;
            _messageBroker = messageBroker;
            //_eventDispatcher = eventDispatcher;
            //_moduleClient = moduleClient;
        }

        public async Task AddAsync(ConferenceDetailsDto dto)
        {
            if(await _hostRepository.GetAsync(dto.HostId) is null)
            {
                throw new HostNotFoundException(dto.HostId);
            }

            dto.Id = Guid.NewGuid();
            var conference = new Conference
            {
                Id = dto.Id,
                HostId = dto.HostId,
                HostName = dto.HostName,
                Name = dto.Name,
                Description = dto.Description,
                From = dto.From,
                To = dto.To,
                Location = dto.Location,
                LogoUrl = dto.LogoUrl,
                ParticipantsLimit = dto.ParticipantsLimit
            };
            await _conferenceRepository.AddAsync(conference);

            //await _eventDispatcher.PublishAsync(new ConferenceCreated(conference.Id, conference.Name, 
            //    conference.ParticipantsLimit, conference.From, conference.To));

            // Fire and forget if we using BackgroundDispatcher
            await _messageBroker.PublishAsync(new ConferenceCreated(conference.Id, conference.Name,
                conference.ParticipantsLimit, conference.From, conference.To));
        }

        public async Task<IReadOnlyList<ConferenceDto>> BrowseAsync()
        {
            var conference = await _conferenceRepository.BrowseAsync();

            return conference
                .Select(Map<ConferenceDto>)
                .ToList();
        }

        public async Task DeleteAsync(Guid id)
        {
            var conference = await _conferenceRepository.GetAsync(id);

            if (conference is null)
            {
                throw new ConferenceNotFoundException(id);
            }

            if(await _conferenceDeletionPolicy.CanDeleteAsync(conference))
            {
                throw new CannotDeleteConferenceException(id);
            }

            await _conferenceRepository.DeleteAsync(conference);
        }

        public async Task<ConferenceDetailsDto> GetAsync(Guid id)
        {
            var conference = await _conferenceRepository.GetAsync(id);

            if (conference is null)
            {
                return null;
            }

            var dto = Map<ConferenceDetailsDto>(conference);
            return dto;
        }

        public async Task UpdateAsync(ConferenceDetailsDto dto)
        {
            var conference = await _conferenceRepository.GetAsync(dto.Id);

            if (conference is null)
            {
                throw new ConferenceNotFoundException(dto.Id);
            }

            conference.Name = dto.Name;
            conference.Description = dto.Description;
            conference.Location = dto.Location;
            conference.LogoUrl = dto.LogoUrl;
            conference.From  = dto.From;
            conference.To = dto.To;
            conference.ParticipantsLimit = dto.ParticipantsLimit;            

            await _conferenceRepository.UpdateAsync(conference);
        }

        private static T Map<T>(Conference conference) where T : ConferenceDto, new() => new T
        {
            Id = conference.Id,
            HostId = conference.HostId,
            HostName = conference.HostName,
            Name = conference.Name,
            Location = conference.Location,
            From = conference.From,
            To = conference.To,
            LogoUrl = conference.LogoUrl,
            ParticipantsLimit = conference.ParticipantsLimit
        };
    }
}
