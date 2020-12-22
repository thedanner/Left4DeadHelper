﻿using Discord;
using Discord.Commands;
using Left4DeadHelper.Helpers;
using Left4DeadHelper.Wrappers.Rcon;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Left4DeadHelper.Discord.Modules
{
    [Group(Constants.GroupL4d)]
    [Alias(Constants.GroupL4d2)]
    public class MoveChannelsModule : ModuleBase<SocketCommandContext>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<MoveChannelsModule> _logger;

        public MoveChannelsModule(ILogger<MoveChannelsModule> logger, IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [Command]
        [Alias("vc")]
        [Summary("Moves users into respective voice channels based on game team.")]
        [RequireUserPermission(GuildPermission.MoveMembers)]
        public async Task HandleCommandAsync()
        {
            try
            {
                var message = Context.Message;
                if (message == null) return;

                using (var rcon = _serviceProvider.GetRequiredService<IRCONWrapper>())
                {
                    await rcon.ConnectAsync();

                    var mover = _serviceProvider.GetRequiredService<IDiscordChatMover>();

                    var moveCount = await mover.MovePlayersToCorrectChannelsAsync(rcon, CancellationToken.None);

                    if (moveCount == -1)
                    {
                        await ReplyAsync("Nobody was playing.");
                    }
                    else if (moveCount == 1)
                    {
                        await ReplyAsync("1 player moved.");
                    }
                    else
                    {
                        await ReplyAsync($"{moveCount} players moved.");
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error in {0}.{1}().", nameof(MoveChannelsModule), nameof(HandleCommandAsync));
            }
        }
    }
}
