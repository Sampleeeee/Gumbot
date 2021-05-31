using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;

namespace Gumbot
{
    class Program
    {
        private static void Main( string[] args )
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            var discord = new DiscordClient( new DiscordConfiguration
            {
                Token = "ODQ4NzIxNTU5NzQwNjEyNjE4.YLQvjA.OMHuuKU6cR3ZGv3h0EQKkyU-jd4",
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            } );

            await discord.ConnectAsync();
            await Task.Delay( -1 );
        }
    }
}