namespace FinalBotVersion;

public static class Boot
{
    public static void Main(string[] args)
    {
        var bot = new Bot();
        bot.RunAsync().ConfigureAwait(false);
    }
}