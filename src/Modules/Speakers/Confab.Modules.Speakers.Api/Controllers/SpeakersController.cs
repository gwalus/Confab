using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Entities;
using Confab.Modules.Speakers.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Api.Controllers
{
    internal class SpeakersController : BaseController
    {
        private readonly ISpeakerService _speakerService;

        public SpeakersController(ISpeakerService speakerService)
        {
            _speakerService = speakerService;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SpeakerDto>> Get(Guid id) => OkOrNotFound(await _speakerService.GetAsync(id));

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> Get() => Ok(await _speakerService.BrowseAsync());

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put(Guid id, SpeakerDto speaker)
        {
            speaker.Id = id;
            await _speakerService.UpdateAsync(speaker);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult> Post(SpeakerDto speaker)
        {
            await _speakerService.AddAsync(speaker);

            return CreatedAtAction(nameof(Get), new { Id = speaker.Id }, null);
        }
    }
}