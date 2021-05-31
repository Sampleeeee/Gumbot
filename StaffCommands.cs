using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging.Abstractions;

namespace Gumbot
{
    public class StaffCommands : BaseCommandModule
    {
        [Command( "mute" )]
        [Description( "Mute Someone!" )]
        [RequirePermissions( Permissions.MuteMembers )]
        private async Task MuteCommand( CommandContext ctx, DiscordMember member = null, string reason = "No reason given" )
        {
            await ctx.TriggerTypingAsync();

            DiscordUser[] mentioned = ctx.Message.MentionedUsers.ToArray();
            if ( member is null && mentioned.Length != 1 )
            {
                await ctx.RespondAsync( "You must mention a user to mute." );
                return;
            }

            DiscordMember target;

            if ( member is null ) target = ( DiscordMember ) mentioned[0];
            else target = member;

            await target.GrantRoleAsync( ctx.Guild.GetRole( Program.Config.MutedRole ) );
            await ctx.RespondAsync(
                $"{target.Mention} has been muted by {ctx.Message.Author.Mention} for reason: {reason}." );
        }
    }
}