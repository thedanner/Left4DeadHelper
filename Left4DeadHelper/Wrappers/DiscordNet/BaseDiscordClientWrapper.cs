﻿using Discord;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Left4DeadHelper.Wrappers.DiscordNet
{
    public class BaseDiscordClientWrapper : IBaseDiscordClientWrapper
    {
        private readonly BaseDiscordClient _baseDiscordClient;

        public BaseDiscordClientWrapper(BaseDiscordClient baseDiscordClient)
        {
            _baseDiscordClient = baseDiscordClient ?? throw new ArgumentNullException(nameof(baseDiscordClient));
        }

        public virtual LoginState LoginState => _baseDiscordClient.LoginState;

        public virtual ConnectionState ConnectionState => ((IDiscordClient)_baseDiscordClient).ConnectionState;

        public virtual ISelfUser CurrentUser => _baseDiscordClient.CurrentUser;

        public virtual TokenType TokenType => _baseDiscordClient.TokenType;

        public virtual event Func<LogMessage, Task> Log
        {
            add { _baseDiscordClient.Log += value; }
            remove { _baseDiscordClient.Log += value; }
        }

        public virtual event Func<Task> LoggedIn
        {
            add { _baseDiscordClient.LoggedIn += value; }
            remove { _baseDiscordClient.LoggedIn += value; }
        }

        public virtual event Func<Task> LoggedOut
        {
            add { _baseDiscordClient.LoggedOut += value; }
            remove { _baseDiscordClient.LoggedOut += value; }
        }

        public Task<IReadOnlyCollection<IApplicationCommand>> BulkOverwriteGlobalApplicationCommand(ApplicationCommandProperties[] properties, RequestOptions? options = null) =>
            BulkOverwriteGlobalApplicationCommand(properties, options);


        public Task<IApplicationCommand> CreateGlobalApplicationCommand(ApplicationCommandProperties properties, RequestOptions? options = null) =>
            CreateGlobalApplicationCommand(properties, options);


        public virtual Task<IGuild> CreateGuildAsync(string name, IVoiceRegion region, Stream? jpegIcon = null, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).CreateGuildAsync(name, region, jpegIcon, options);


        public virtual void Dispose() =>
            _baseDiscordClient.Dispose();


        public ValueTask DisposeAsync() =>
            _baseDiscordClient.DisposeAsync();


        public virtual Task<IApplication> GetApplicationInfoAsync(RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetApplicationInfoAsync(options);


        public virtual Task<BotGateway> GetBotGatewayAsync(RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetBotGatewayAsync(options);


        public virtual Task<IChannel> GetChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetChannelAsync(id, mode, options);


        public virtual Task<IReadOnlyCollection<IConnection>> GetConnectionsAsync(RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetConnectionsAsync(options);


        public virtual Task<IReadOnlyCollection<IDMChannel>> GetDMChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetDMChannelsAsync(mode, options);


        public Task<IApplicationCommand> GetGlobalApplicationCommandAsync(ulong id, RequestOptions? options = null) =>
            GetGlobalApplicationCommandAsync(id, options);


        public Task<IReadOnlyCollection<IApplicationCommand>> GetGlobalApplicationCommandsAsync(RequestOptions? options = null) =>
            GetGlobalApplicationCommandsAsync(options);


        public Task<IReadOnlyCollection<IApplicationCommand>> GetGlobalApplicationCommandsAsync(bool withLocalizations = false, string? locale = null, RequestOptions? options = null) =>
            GetGlobalApplicationCommandsAsync(withLocalizations, locale, options);


        public virtual Task<IReadOnlyCollection<IGroupChannel>> GetGroupChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetGroupChannelsAsync(mode, options);


        public virtual Task<IGuild> GetGuildAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetGuildAsync(id, mode, options);


        public virtual Task<IReadOnlyCollection<IGuild>> GetGuildsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetGuildsAsync(mode, options);


        public virtual Task<IInvite> GetInviteAsync(string inviteId, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetInviteAsync(inviteId, options);


        public virtual Task<IReadOnlyCollection<IPrivateChannel>> GetPrivateChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetPrivateChannelsAsync(mode, options);


        public virtual Task<int> GetRecommendedShardCountAsync(RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetRecommendedShardCountAsync(options);


        public virtual Task<IUser> GetUserAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetUserAsync(id, mode, options);


        public virtual Task<IUser> GetUserAsync(string username, string discriminator, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetUserAsync(username, discriminator, options);


        public virtual Task<IVoiceRegion> GetVoiceRegionAsync(string id, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetVoiceRegionAsync(id, options);


        public virtual Task<IReadOnlyCollection<IVoiceRegion>> GetVoiceRegionsAsync(RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetVoiceRegionsAsync(options);


        public virtual Task<IWebhook> GetWebhookAsync(ulong id, RequestOptions? options = null) =>
            ((IDiscordClient)_baseDiscordClient).GetWebhookAsync(id, options);


        public virtual Task LoginAsync(TokenType tokenType, string token, bool validateToken = true) =>
            _baseDiscordClient.LoginAsync(tokenType, token, validateToken);


        public virtual Task LogoutAsync() =>
            _baseDiscordClient.LogoutAsync();


        public virtual Task StartAsync() =>
            ((IDiscordClient)_baseDiscordClient).StartAsync();


        public virtual Task StopAsync() =>
            ((IDiscordClient)_baseDiscordClient).StopAsync();
    }
}
