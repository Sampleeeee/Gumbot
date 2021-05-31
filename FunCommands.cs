using System.Security.Cryptography;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Gumbot
{
    public class FunCommands : BaseCommandModule
    {
        [Command( "color" )]
        [Description( "set your color" )]
        public async Task ColorCommand( CommandContext ctx, string color )
        {
            await ctx.TriggerTypingAsync();

            if ( Program.Config.Colors.ContainsKey( color ) )
            {
                foreach ( var role in ctx.Member.Roles )
                    if ( Program.Config.Colors.ContainsValue( role.Id ) )
                        await ctx.Member.RevokeRoleAsync( role );

                await ctx.Member.GrantRoleAsync( ctx.Guild.GetRole( Program.Config.Colors[color] ) );
            }
            else
            {
                var colors = "";
                foreach ( ( string name, ulong id ) in Program.Config.Colors )
                    colors += name + ", ";

                await ctx.RespondAsync( $"That color does not exist! Valid colors: {colors.TrimEnd( ',' )}" );
            }
        }
    }
}