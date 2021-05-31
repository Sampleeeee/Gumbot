using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Newtonsoft.Json;

namespace Gumbot
{
    class Program
    {
        public static Config Config { get; private set; }
        
        private static void Main( string[] args )
        {
            new Program().MainAsync().GetAwaiter().GetResult();
        }

        public async Task MainAsync()
        {
            Config = JsonConvert.DeserializeObject<Config>( await File.ReadAllTextAsync( "config.json" ) );
                
            var discord = new DiscordClient( new DiscordConfiguration
            {
                Token = Config.Token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            } );

            var commands = discord.UseCommandsNext( new CommandsNextConfiguration
            {
                StringPrefixes = new[] { "%" }
            } );

            commands.RegisterCommands<FunCommands>();
            commands.RegisterCommands<StaffCommands>();

            await discord.ConnectAsync();
            await Task.Delay( -1 );
        }
    }

    public struct Config
    {
        public string Token { get; set; }
        public ulong MutedRole { get; set; }
        public ulong StaffLogChannel { get; set; }
        public Dictionary<string, ulong> Colors { get; set; }
    }
}