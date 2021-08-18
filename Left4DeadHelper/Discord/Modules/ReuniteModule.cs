using Discord;
using Discord.Commands;
using Left4DeadHelper.Discord.Interfaces;
using Left4DeadHelper.Models;
using Left4DeadHelper.Services;
using Left4DeadHelper.Wrappers.DiscordNet;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Left4DeadHelper.Discord.Modules
{
    public class ReuniteModule : ModuleBase<SocketCommandContext>, ICommandModule
    {
        private const string Command = "reunite";
        private const string CommandAlias = "remarry";

        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ReuniteModule> _logger;

        public ReuniteModule(ILogger<ReuniteModule> logger, IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        private static readonly object MoveLock = new object();
        private static bool _isMoving;
        private static bool IsMoving
        {
            get { lock (MoveLock) { return _isMoving; } }
            set { lock (MoveLock) { _isMoving = true; } }
        }

        [Command(Command)]
        [Alias(CommandAlias)]
        [Summary("Moves users from the configured secondary channel into the primary channel.")]
        [RequireUserPermission(GuildPermission.MoveMembers)]
        public async Task HandleVoiceChatAsync()
        {
            if (Context.Message == null) return;
            if (Context.Guild == null) return;

            try
            {
                if (IsMoving)
                {
                    _logger.LogInformation("A move lock is already set; skipping.");
                    return;
                }
                IsMoving = true;

                var settings = _serviceProvider.GetRequiredService<Settings>();
                var guildSettings = settings.DiscordSettings.GuildSettings.FirstOrDefault(g => g.Id == Context.Guild.Id);

                var mover = _serviceProvider.GetRequiredService<IDiscordChatMover>();

                var moveResult = await mover.RenuitePlayersAsync(
                    new DiscordSocketClientWrapper(Context.Client),
                    new SocketGuildWrapper(Context.Guild),
                    CancellationToken.None);

                string replyMessage;

                if (moveResult.MoveCount == 0)
                {
                    replyMessage = "Nobody was in the channel to move.";
                }
                else if (moveResult.MoveCount == 1)
                {
                    replyMessage = "1 person moved.";
                }
                else
                {
                    replyMessage = $"{moveResult.MoveCount} people moved.";
                }

                await ReplyAsync(replyMessage);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error trying to reuninte users :(");
            }
            finally
            {
                IsMoving = false;
            }
        }

        public string GetGeneralHelpMessage(HelpContext helpContext) =>
            $"  - `{helpContext.GenericCommandExample}`:\n" +
            $"    Moves players from the second channel to the first one.\n" +
            $"    Aliases: {helpContext.GetCommandAliasesString()}.";
    }
}
