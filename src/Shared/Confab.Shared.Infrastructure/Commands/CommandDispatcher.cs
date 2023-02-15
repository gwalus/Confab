﻿using Confab.Shared.Abstractions.Commands;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Confab.Shared.Infrastructure.Commands
{
    internal sealed class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SendAsync<TCommand>(TCommand command) where TCommand : class, ICommand
        {
            if(command is null)
            {
                return;
            }

            using var scope = _serviceProvider.CreateScope();
            var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<ICommand>>();
            await handler.HandlerAsync(command);
        }
    }
}
