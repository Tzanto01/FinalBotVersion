using Newtonsoft.Json;
namespace FinalBotVersion;

public record TokenJson([JsonProperty("token")] string Token);
public record PrefixJson([JsonProperty("prefixes")] IEnumerable<string> Prefix);