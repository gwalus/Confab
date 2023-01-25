﻿using Confab.Shared.Abstractions.Events;
using System;

namespace Confab.Modules.Conferences.Core.Events
{
    public record ConferenceCreated(Guid Id, string Name, int? ParticipantsLimit, DateTime From, DateTime To) : IEvent;
}
