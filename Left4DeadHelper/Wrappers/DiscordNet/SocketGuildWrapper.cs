﻿using Discord;
using Discord.Audio;
using Discord.Rest;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Left4DeadHelper.Wrappers.DiscordNet
{
    public class SocketGuildWrapper : SocketEntityWrapper<ulong>, ISocketGuildWrapper
    {
        private readonly SocketGuild _socketGuild;

        public SocketGuildWrapper(SocketGuild socketGuild)
            : base(socketGuild)
        {
            _socketGuild = socketGuild ?? throw new ArgumentNullException(nameof(socketGuild));
        }

        public virtual SocketGuildUser Owner => _socketGuild.Owner;

        public virtual bool IsConnected => _socketGuild.IsConnected;

        public virtual int DownloadedMemberCount => _socketGuild.DownloadedMemberCount;

        public virtual int MemberCount => _socketGuild.MemberCount;

        public virtual IReadOnlyCollection<SocketGuildChannel> Channels => _socketGuild.Channels;

        public virtual SocketGuildUser CurrentUser => _socketGuild.CurrentUser;

        public virtual IReadOnlyCollection<SocketCategoryChannel> CategoryChannels => _socketGuild.CategoryChannels;

        public virtual IReadOnlyCollection<SocketVoiceChannel> VoiceChannels => _socketGuild.VoiceChannels;

        public virtual IReadOnlyCollection<SocketTextChannel> TextChannels => _socketGuild.TextChannels;

        public virtual SocketTextChannel SystemChannel => _socketGuild.SystemChannel;

        public virtual SocketVoiceChannel AFKChannel => _socketGuild.AFKChannel;

        public virtual SocketTextChannel DefaultChannel => _socketGuild.DefaultChannel;

        public virtual Task DownloaderPromise => _socketGuild.DownloaderPromise;

        public virtual Task SyncPromise => _socketGuild.SyncPromise;

        public virtual bool IsSynced => _socketGuild.IsSynced;

        public virtual bool HasAllMembers => _socketGuild.HasAllMembers;

        public virtual IReadOnlyCollection<ISocketGuildUserWrapper>? Users
        {
            get
            {
                var rawUsers = _socketGuild.Users;
                if (rawUsers != null)
                {
                    return _socketGuild.Users.Select(u => new SocketGuildUserWrapper(u)).ToList().AsReadOnly();
                }
                return null;
            }
        }

        public virtual string Name => _socketGuild.Name;

        public virtual int AFKTimeout => _socketGuild.AFKTimeout;

        public virtual DefaultMessageNotifications DefaultMessageNotifications => _socketGuild.DefaultMessageNotifications;

        public virtual MfaLevel MfaLevel => _socketGuild.MfaLevel;

        public virtual VerificationLevel VerificationLevel => _socketGuild.VerificationLevel;

        public virtual ExplicitContentFilterLevel ExplicitContentFilter => _socketGuild.ExplicitContentFilter;

        public virtual string IconId => _socketGuild.IconId;

        public virtual string IconUrl => _socketGuild.IconUrl;

        public virtual string SplashId => _socketGuild.SplashId;

        public virtual string SplashUrl => _socketGuild.SplashUrl;

        public virtual bool Available => ((IGuild)_socketGuild).Available;

        public virtual ulong? AFKChannelId => ((IGuild)_socketGuild).AFKChannelId;

        public virtual ulong? SystemChannelId => ((IGuild)_socketGuild).SystemChannelId;

        public virtual ulong OwnerId => _socketGuild.OwnerId;

        public virtual ulong? ApplicationId => _socketGuild.ApplicationId;

        public virtual string VoiceRegionId => _socketGuild.VoiceRegionId;

        public virtual IAudioClient AudioClient => _socketGuild.AudioClient;

        public virtual IRole EveryoneRole => _socketGuild.EveryoneRole;

        public virtual IReadOnlyCollection<GuildEmote> Emotes => _socketGuild.Emotes;

        public virtual IReadOnlyCollection<SocketRole> Roles => _socketGuild.Roles;

        IReadOnlyCollection<IRole> IGuild.Roles => ((IGuild)_socketGuild).Roles;

        public virtual PremiumTier PremiumTier => _socketGuild.PremiumTier;

        public virtual string BannerId => _socketGuild.BannerId;

        public virtual string BannerUrl => _socketGuild.BannerUrl;

        public virtual string VanityURLCode => _socketGuild.VanityURLCode;

        public virtual SystemChannelMessageDeny SystemChannelFlags => _socketGuild.SystemChannelFlags;

        public virtual string Description => _socketGuild.Description;

        public virtual int PremiumSubscriptionCount => _socketGuild.PremiumSubscriptionCount;

        public virtual string PreferredLocale => _socketGuild.PreferredLocale;

        public virtual CultureInfo PreferredCulture => _socketGuild.PreferredCulture;

        public virtual DateTimeOffset CreatedAt => _socketGuild.CreatedAt;

        public bool IsWidgetEnabled => _socketGuild.IsWidgetEnabled;

        public string DiscoverySplashId => _socketGuild.DiscoverySplashId;

        public string DiscoverySplashUrl => _socketGuild.DiscoverySplashUrl;

        public ulong? RulesChannelId => ((IGuild)_socketGuild).RulesChannelId;

        public ulong? PublicUpdatesChannelId => ((IGuild)_socketGuild).PublicUpdatesChannelId;

        public int? MaxPresences => ((IGuild)_socketGuild).MaxPresences;

        public int? MaxMembers => ((IGuild)_socketGuild).MaxMembers;

        public int? MaxVideoChannelUsers => ((IGuild)_socketGuild).MaxVideoChannelUsers;

        public int? ApproximateMemberCount => ((IGuild)_socketGuild).ApproximateMemberCount;

        public int? ApproximatePresenceCount => ((IGuild)_socketGuild).ApproximatePresenceCount;

        public IReadOnlyCollection<ICustomSticker> Stickers => _socketGuild.Stickers;

        GuildFeatures IGuild.Features => _socketGuild.Features;

        public int MaxBitrate => _socketGuild.MaxBitrate;

        public NsfwLevel NsfwLevel => _socketGuild.NsfwLevel;

        public bool IsBoostProgressBarEnabled => _socketGuild.IsBoostProgressBarEnabled;

        public ulong? WidgetChannelId => ((IGuild)_socketGuild).WidgetChannelId;

        public ulong MaxUploadLimit => ((IGuild)_socketGuild).MaxUploadLimit;
        public virtual Task AddBanAsync(IUser user, int pruneDays = 0, string? reason = null, RequestOptions? options = null) =>
            _socketGuild.AddBanAsync(user, pruneDays, reason, options);


        public virtual Task AddBanAsync(ulong userId, int pruneDays = 0, string? reason = null, RequestOptions? options = null) =>
            _socketGuild.AddBanAsync(userId, pruneDays, reason, options);

        public virtual Task<RestGuildUser> AddGuildUserAsync(ulong userId, string accessToken, Action<AddGuildUserProperties>? func = null, RequestOptions? options = null) =>
            _socketGuild.AddGuildUserAsync(userId, accessToken, func, options);

        Task<IGuildUser> IGuild.AddGuildUserAsync(ulong userId, string accessToken, Action<AddGuildUserProperties>? func, RequestOptions? options) =>
            ((IGuild)_socketGuild).AddGuildUserAsync(userId, accessToken, func, options);

        public virtual Task<ICategoryChannel> CreateCategoryAsync(string name, Action<GuildChannelProperties>? func = null, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateCategoryAsync(name, func, options);

        public virtual Task<RestCategoryChannel> CreateCategoryChannelAsync(string name, Action<GuildChannelProperties>? func = null, RequestOptions? options = null) =>
            _socketGuild.CreateCategoryChannelAsync(name, func, options);

        public virtual Task<GuildEmote> CreateEmoteAsync(string name, Image image, Optional<IEnumerable<IRole>> roles = default, RequestOptions? options = null) =>
            _socketGuild.CreateEmoteAsync(name, image, roles, options);

        public virtual Task<RestRole> CreateRoleAsync(string name, GuildPermissions? permissions = null, Color? color = null, bool isHoisted = false, bool isMentionable = false, RequestOptions? options = null) =>
            _socketGuild.CreateRoleAsync(name, permissions, color, isHoisted, isMentionable, options);

        Task<IRole> IGuild.CreateRoleAsync(string name, GuildPermissions? permissions, Color? color, bool isHoisted, RequestOptions? options) =>
            ((IGuild)_socketGuild).CreateRoleAsync(name, permissions, color, isHoisted, options);

        Task<IRole> IGuild.CreateRoleAsync(string name, GuildPermissions? permissions, Color? color, bool isHoisted, bool isMentionable, RequestOptions? options) =>
            ((IGuild)_socketGuild).CreateRoleAsync(name, permissions, color, isHoisted, isMentionable, options);

        public virtual Task<RestTextChannel> CreateTextChannelAsync(string name, Action<TextChannelProperties>? func = null, RequestOptions? options = null) =>
            _socketGuild.CreateTextChannelAsync(name, func, options);

        Task<ITextChannel> IGuild.CreateTextChannelAsync(string name, Action<TextChannelProperties>? func, RequestOptions? options) =>
            ((IGuild)_socketGuild).CreateTextChannelAsync(name, func, options);

        public virtual Task<RestVoiceChannel> CreateVoiceChannelAsync(string name, Action<VoiceChannelProperties>? func = null, RequestOptions? options = null) =>
            _socketGuild.CreateVoiceChannelAsync(name, func, options);

        Task<IVoiceChannel> IGuild.CreateVoiceChannelAsync(string name, Action<VoiceChannelProperties>? func, RequestOptions? options) =>
            ((IGuild)_socketGuild).CreateVoiceChannelAsync(name, func, options);

        public virtual Task DeleteAsync(RequestOptions? options = null) =>
            _socketGuild.DeleteAsync(options);

        public virtual Task DeleteEmoteAsync(GuildEmote emote, RequestOptions? options = null) =>
            _socketGuild.DeleteEmoteAsync(emote, options);

        public virtual void Dispose() =>
            ((IDisposable)_socketGuild).Dispose();

        public virtual Task DownloadUsersAsync() =>
            _socketGuild.DownloadUsersAsync();

        public virtual Task<IVoiceChannel> GetAFKChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetAFKChannelAsync(mode, options);

        public virtual IAsyncEnumerable<IReadOnlyCollection<RestAuditLogEntry>> GetAuditLogsAsync(int limit, RequestOptions? options = null, ulong? beforeId = null, ulong? userId = null, ActionType? actionType = null) =>
            _socketGuild.GetAuditLogsAsync(limit, options, beforeId, userId, actionType);

        Task<IReadOnlyCollection<IAuditLogEntry>> IGuild.GetAuditLogsAsync(int limit, CacheMode mode, RequestOptions? options, ulong? beforeId, ulong? userId, ActionType? actionType) =>
            ((IGuild)_socketGuild).GetAuditLogsAsync(limit, mode, options, beforeId, userId, actionType);

        public virtual Task<RestBan> GetBanAsync(IUser user, RequestOptions? options) =>
            _socketGuild.GetBanAsync(user, options);

        Task<IBan> IGuild.GetBanAsync(IUser user, RequestOptions? options) =>
            ((IGuild)_socketGuild).GetBanAsync(user, options);

        public virtual Task<RestBan> GetBanAsync(ulong userId, RequestOptions? options) =>
            _socketGuild.GetBanAsync(userId, options);

        Task<IBan> IGuild.GetBanAsync(ulong userId, RequestOptions? options) =>
            ((IGuild)_socketGuild).GetBanAsync(userId, options);

        public virtual IAsyncEnumerable<IReadOnlyCollection<RestBan>> GetBansAsync(int limit = 100, RequestOptions? options = null) =>
            _socketGuild.GetBansAsync(limit, options);

        IAsyncEnumerable<IReadOnlyCollection<IBan>> IGuild.GetBansAsync(int limit, RequestOptions? options) =>
            ((IGuild)_socketGuild).GetBansAsync(limit, options);

        public virtual Task<IReadOnlyCollection<ICategoryChannel>> GetCategoriesAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetCategoriesAsync(mode, options);

        public virtual SocketCategoryChannel GetCategoryChannel(ulong id) =>
            _socketGuild.GetCategoryChannel(id);

        public virtual ISocketGuildChannelWrapper GetChannel(ulong id) =>
            new SocketGuildChannelWrapper(_socketGuild.GetChannel(id));

        public virtual Task<IGuildChannel> GetChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetChannelAsync(id, mode, options);

        public virtual Task<IReadOnlyCollection<IGuildChannel>> GetChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetChannelsAsync(mode, options);

        public virtual Task<IGuildUser> GetCurrentUserAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetCurrentUserAsync(mode, options);

        public virtual Task<ITextChannel> GetDefaultChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetDefaultChannelAsync(mode, options);

        public virtual Task<GuildEmote> GetEmoteAsync(ulong id, RequestOptions? options = null) =>
            _socketGuild.GetEmoteAsync(id, options);

        public virtual Task<IReadOnlyCollection<GuildEmote>> GetEmotesAsync(RequestOptions? options = null) =>
            _socketGuild.GetEmotesAsync(options);

        public virtual Task<IReadOnlyCollection<RestInviteMetadata>> GetInvitesAsync(RequestOptions? options = null) =>
            _socketGuild.GetInvitesAsync(options);

        Task<IReadOnlyCollection<IInviteMetadata>> IGuild.GetInvitesAsync(RequestOptions? options) =>
            ((IGuild)_socketGuild).GetInvitesAsync(options);

        public virtual Task<IGuildUser> GetOwnerAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetOwnerAsync(mode, options);

        public virtual IRole GetRole(ulong id) =>
            _socketGuild.GetRole(id);

        public virtual Task<ITextChannel> GetSystemChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetSystemChannelAsync(mode, options);

        public virtual SocketTextChannel GetTextChannel(ulong id) =>
            _socketGuild.GetTextChannel(id);

        public virtual Task<ITextChannel> GetTextChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetTextChannelAsync(id, mode, options);

        public virtual Task<IReadOnlyCollection<ITextChannel>> GetTextChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetTextChannelsAsync(mode, options);

        public virtual SocketGuildUser GetUser(ulong id) =>
            _socketGuild.GetUser(id);

        public virtual Task<IGuildUser> GetUserAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetUserAsync(id, mode, options);

        public virtual Task<IReadOnlyCollection<IGuildUser>> GetUsersAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetUsersAsync(mode, options);

        public virtual Task<RestInviteMetadata> GetVanityInviteAsync(RequestOptions? options = null) =>
            _socketGuild.GetVanityInviteAsync(options);

        Task<IInviteMetadata> IGuild.GetVanityInviteAsync(RequestOptions? options) =>
            ((IGuild)_socketGuild).GetVanityInviteAsync(options);

        public virtual ISocketVoiceChannelWrapper? GetVoiceChannel(ulong id)
        {
            var rawChannel = _socketGuild.GetVoiceChannel(id);
            return rawChannel != null ? new SocketVoiceChannelWrapper(rawChannel) : null;
        }

        public virtual Task<IVoiceChannel> GetVoiceChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetVoiceChannelAsync(id, mode, options);

        public virtual Task<IReadOnlyCollection<IVoiceChannel>> GetVoiceChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetVoiceChannelsAsync(mode, options);

        public virtual Task<IReadOnlyCollection<RestVoiceRegion>> GetVoiceRegionsAsync(RequestOptions? options = null) =>
            _socketGuild.GetVoiceRegionsAsync(options);

        Task<IReadOnlyCollection<IVoiceRegion>> IGuild.GetVoiceRegionsAsync(RequestOptions? options) =>
            ((IGuild)_socketGuild).GetVoiceRegionsAsync(options);

        public virtual Task<RestWebhook> GetWebhookAsync(ulong id, RequestOptions? options = null) =>
            _socketGuild.GetWebhookAsync(id, options);

        Task<IWebhook> IGuild.GetWebhookAsync(ulong id, RequestOptions? options) =>
            ((IGuild)_socketGuild).GetWebhookAsync(id, options);

        public virtual Task<IReadOnlyCollection<RestWebhook>> GetWebhooksAsync(RequestOptions? options = null) =>
            _socketGuild.GetWebhooksAsync(options);

        Task<IReadOnlyCollection<IWebhook>> IGuild.GetWebhooksAsync(RequestOptions? options) =>
            ((IGuild)_socketGuild).GetWebhooksAsync(options);

        public virtual Task LeaveAsync(RequestOptions? options = null) =>
            _socketGuild.LeaveAsync(options);

        public virtual Task ModifyAsync(Action<GuildProperties> func, RequestOptions? options = null) =>
            _socketGuild.ModifyAsync(func, options);

        public virtual Task<GuildEmote> ModifyEmoteAsync(GuildEmote emote, Action<EmoteProperties> func, RequestOptions? options = null) =>
            _socketGuild.ModifyEmoteAsync(emote, func, options);

        public virtual Task<int> PruneUsersAsync(int days = 30, bool simulate = false, RequestOptions? options = null) =>
            _socketGuild.PruneUsersAsync(days, simulate, options);

        public virtual Task RemoveBanAsync(IUser user, RequestOptions? options = null) =>
            _socketGuild.RemoveBanAsync(user, options);

        public virtual Task RemoveBanAsync(ulong userId, RequestOptions? options = null) =>
            _socketGuild.RemoveBanAsync(userId, options);

        public virtual Task ReorderChannelsAsync(IEnumerable<ReorderChannelProperties> args, RequestOptions? options = null) =>
            _socketGuild.ReorderChannelsAsync(args, options);

        public virtual Task ReorderRolesAsync(IEnumerable<ReorderRoleProperties> args, RequestOptions? options = null) =>
            _socketGuild.ReorderRolesAsync(args, options);

        public virtual Task ModifyWidgetAsync(Action<GuildWidgetProperties> func, RequestOptions? options = null) =>
            _socketGuild.ModifyWidgetAsync(func, options);

        public virtual Task<IGuildChannel> GetWidgetChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetWidgetChannelAsync(mode, options);

        public virtual Task<ITextChannel> GetRulesChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetRulesChannelAsync(mode, options);

        public virtual Task<ITextChannel> GetPublicUpdatesChannelAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetPublicUpdatesChannelAsync(mode, options);

        public virtual Task<int> PruneUsersAsync(int days = 30, bool simulate = false, RequestOptions? options = null, IEnumerable<ulong>? includeRoleIds = null) =>
            _socketGuild.PruneUsersAsync(days, simulate, options, includeRoleIds);

        public virtual Task<IReadOnlyCollection<IGuildUser>> SearchUsersAsync(string query, int limit = 1000, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).SearchUsersAsync(query, limit, mode, options);

        public Task<IStageChannel> GetStageChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetStageChannelAsync(id, mode, options);

        public Task<IReadOnlyCollection<IStageChannel>> GetStageChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetStageChannelsAsync(mode, options);

        public Task<IThreadChannel> GetThreadChannelAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetThreadChannelAsync(id, mode, options);

        public Task<IReadOnlyCollection<IThreadChannel>> GetThreadChannelsAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetThreadChannelsAsync(mode, options);

        public Task<IStageChannel> CreateStageChannelAsync(string name, Action<VoiceChannelProperties>? func = null, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateStageChannelAsync(name, func, options);

        public Task DisconnectAsync(IGuildUser user) =>
            ((IGuild)_socketGuild).DisconnectAsync(user);

        public Task MoveAsync(IGuildUser user, IVoiceChannel targetChannel) =>
            ((IGuild)_socketGuild).MoveAsync(user, targetChannel);

        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, Image image, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateStickerAsync(name, description, tags, image, options);

        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, string path, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateStickerAsync(name, description, tags, path, options);

        public Task<ICustomSticker> CreateStickerAsync(string name, string description, IEnumerable<string> tags, Stream stream, string filename, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateStickerAsync(name, description, tags, stream, filename, options);

        public Task<ICustomSticker> GetStickerAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetStickerAsync(id, mode, options);

        public Task<IReadOnlyCollection<ICustomSticker>> GetStickersAsync(CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetStickersAsync(mode, options);

        public Task DeleteStickerAsync(ICustomSticker sticker, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).DeleteStickerAsync(sticker, options);

        public Task<IGuildScheduledEvent> GetEventAsync(ulong id, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetEventAsync(id, options);

        public Task<IReadOnlyCollection<IGuildScheduledEvent>> GetEventsAsync(RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetEventsAsync(options);

        public Task<IGuildScheduledEvent> CreateEventAsync(string name, DateTimeOffset startTime, GuildScheduledEventType type, GuildScheduledEventPrivacyLevel privacyLevel = GuildScheduledEventPrivacyLevel.Private, string? description = null, DateTimeOffset? endTime = null, ulong? channelId = null, string? location = null, Image? coverImage = null, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateEventAsync(name, startTime, type, privacyLevel, description, endTime, channelId, location, coverImage, options);

        public Task<IReadOnlyCollection<IApplicationCommand>> GetApplicationCommandsAsync(bool withLocalizations = false, string? locale = null, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetApplicationCommandsAsync(withLocalizations, locale, options);

        public Task<IApplicationCommand> GetApplicationCommandAsync(ulong id, CacheMode mode = CacheMode.AllowDownload, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).GetApplicationCommandAsync(id, mode, options);

        public Task<IApplicationCommand> CreateApplicationCommandAsync(ApplicationCommandProperties properties, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).CreateApplicationCommandAsync(properties, options);

        public Task<IReadOnlyCollection<IApplicationCommand>> BulkOverwriteApplicationCommandsAsync(ApplicationCommandProperties[] properties, RequestOptions? options = null) =>
            ((IGuild)_socketGuild).BulkOverwriteApplicationCommandsAsync(properties, options);

        public IAsyncEnumerable<IReadOnlyCollection<IBan>> GetBansAsync(ulong fromUserId, Direction dir, int limit = 1000, RequestOptions? options = null) =>
            _socketGuild.GetBansAsync(fromUserId, dir, limit, options);

        public IAsyncEnumerable<IReadOnlyCollection<IBan>> GetBansAsync(IUser fromUser, Direction dir, int limit = 1000, RequestOptions? options = null) =>
            GetBansAsync(fromUser, dir, limit, options);

        public Task<IReadOnlyCollection<IIntegration>> GetIntegrationsAsync(RequestOptions? options = null) =>
            GetIntegrationsAsync(options);

        public Task DeleteIntegrationAsync(ulong id, RequestOptions? options = null) =>
            DeleteIntegrationAsync(id, options);
    }
}
