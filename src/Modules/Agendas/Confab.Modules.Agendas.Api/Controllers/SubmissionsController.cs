using Confab.Modules.Agendas.Application.Submissions.Commands;
using Confab.Shared.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Confab.Modules.Agendas.Api.Controllers
{
    internal class SubmissionsController : BaseController
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public SubmissionsController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateSubmission command)
        {
            await _commandDispatcher.SendAsync(command);
            return CreatedAtAction("Get", new { id = command.Id }, null);
        }

        [HttpPut("{id:guid}/approve")]
        public async Task<IActionResult> Approve(Guid id)
        {
            await _commandDispatcher.SendAsync(new ApproveSubmission(id));
            return NoContent();
        }

        [HttpPut("{id:guid}/reject")]
        public async Task<IActionResult> Reject(Guid id)
        {
            await _commandDispatcher.SendAsync(new RejectSubmission(id));
            return NoContent();
        }
    }
}