using System.Text;
using Newtonsoft.Json;

namespace FinalBotVersion.Globals;

public static class GlobalMethods
{
    public static IEnumerable<string> LoadPrefixes(string filePath)
    {
        using var fs = File.OpenRead(filePath);
        using var sr = new StreamReader(fs, new UTF8Encoding(false));
        return JsonConvert.DeserializeObject<PrefixJson>(sr.ReadToEnd())?.Prefix ?? throw new InvalidOperationException();
    }
}