using System;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;

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
            var config = JsonConvert.DeserializeObject<Config>( File.ReadAllText( "config.json" ) );
                
            var discord = new DiscordClient( new DiscordConfiguration
            {
                Token = config.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            } );

            await discord.ConnectAsync();
            await Task.Delay( -1 );
        }

        public struct Config
        {
            public string Token { get; set; }
        }
    }
}