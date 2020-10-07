using System.Text.Json.Serialization;

namespace Q2
{
    public class BattleResult
    {
        [JsonPropertyName("winner")]
        public string Winner { get; set; }

        [JsonPropertyName("loser")]
        public string Loser { get; set; }
    }
}
