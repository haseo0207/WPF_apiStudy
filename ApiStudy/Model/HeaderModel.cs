using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class HeaderModel
    {
        [JsonPropertyName("resultCode")]
        public int ResultCode { get; set; }

        [JsonPropertyName("resultMsg")]
        public string ResultMsg { get; set; } = string.Empty;
    }
}
