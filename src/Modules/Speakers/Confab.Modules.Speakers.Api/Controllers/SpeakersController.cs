using Confab.Modules.Speakers.Core.DTO;
using Confab.Modules.Speakers.Core.Services;
using Confab.Shared.Abstractions.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Confab.Modules.Speakers.Api.Controllers
{
    [Authorize(Policy = Policy)]
    internal class SpeakersController : BaseController
    {
        private const string Policy = "speakers";

        private readonly ISpeakerService _speakerService;
        private readonly IContext _context;

        public SpeakersController(ISpeakerService speakerService, IContext context)
        {
            _speakerService = speakerService;
            _context = context;
        }

        [HttpGet("{id:guid}")]
        [AllowAnonymous]
        public async Task<ActionResult<SpeakerDto>> Get(Guid id) => OkOrNotFound(await _speakerService.GetAsync(id));

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IReadOnlyList<SpeakerDto>>> Get() => Ok(await _speakerService.BrowseAsync());

        
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Post(SpeakerDto speaker)
        {
            speaker.Id = _context.Identity.Id;
            await _speakerService.AddAsync(speaker);

            return CreatedAtAction(nameof(Get), new { Id = speaker.Id }, null);
        }

        // Update only current logged user ??
        [HttpPut("{id:guid}")]
        [Authorize]
        public async Task<ActionResult> Put(Guid id, [FromBody]SpeakerDto speaker)
        {
            speaker.Id = _context.Identity.Id;
            await _speakerService.UpdateAsync(speaker);
            return NoContent();
        }
    }
}