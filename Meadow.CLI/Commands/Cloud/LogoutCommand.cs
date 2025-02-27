﻿using System.Threading.Tasks;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using Meadow.CLI.Core.Identity;
using Microsoft.Extensions.Logging;

namespace Meadow.CLI.Commands.Cloud
{
    [Command("cloud logout", Description = "Logout of the Meadow Service")]
    public class LogoutCommand : ICommand
    {
        private readonly ILogger<LogoutCommand> _logger;

        public LogoutCommand(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<LogoutCommand>();
        }

        public async ValueTask ExecuteAsync(IConsole console)
        {
            var cancellationToken = console.RegisterCancellationHandler();

            await Task.Yield();
            var identityManager = new IdentityManager(_logger);
            identityManager.Logout();

            _logger.LogInformation($"Signed out of Meadow Service");
        }
    }
}