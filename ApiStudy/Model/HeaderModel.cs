using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class HeaderModel
    {
        [JsonPropertyName("resultCode")]
        public string ResultCode { get; set; } = string.Empty;

        [JsonPropertyName("resultMsg")]
        public string ResultMsg { get; set; } = string.Empty;
    }
}
