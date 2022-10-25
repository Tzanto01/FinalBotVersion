using System.Runtime.CompilerServices;
using System.Text;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FinalBotVersion;

public class Bot
{
    public DiscordClient _client { get; private set; }
    public CommandsNextExtension _commands { get; private set; }
    
    public async Task RunAsync()
    {
        string json;

        await using (var fs = File.OpenRead("Configs/token.json"))
        using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
            json = await sr.ReadToEndAsync().ConfigureAwait(false);

        var tokenJson = JsonConvert.DeserializeObject<TokenJson>(json);
        
        var config = new DiscordConfiguration()
        {
            Token = tokenJson?.Token,
            TokenType = TokenType.Bot,
            AutoReconnect = true,
            MinimumLogLevel = LogLevel.Debug,
            LogUnknownEvents = true
        };
        
        _client = new DiscordClient(config);
        _client.Ready += ClientOnReady;

        var commandsConfig = new CommandsNextConfiguration()
        {
            StringPrefixes = Prefixes
        };
        _commands = _client.UseCommandsNext(commandsConfig);
        
        await _client.ConnectAsync();
        await Task.Delay(-1);
    }

    private Task ClientOnReady(DiscordClient sender, ReadyEventArgs e)
    {
        return Task.CompletedTask;
    }
}