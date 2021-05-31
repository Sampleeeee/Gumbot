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
        private async Task MuteCommand( CommandContext ctx, DiscordMember member, string reason = "No reason given" )
        {
            await ctx.TriggerTypingAsync();

            await member.GrantRoleAsync( ctx.Guild.GetRole( Program.Config.MutedRole ) );
            await ctx.RespondAsync( $"{member.Mention} has been muted by {ctx.Message.Author.Mention} for reason: {reason}." );
        }

        [Command( "unmute" )]
        [Description( "Opossum is no longer drunk 0.o" )]
        [RequirePermissions( Permissions.MuteMembers )]
        private async Task UnmuteCommand( CommandContext ctx, DiscordMember member = null )
        {
            
        }
    }
}