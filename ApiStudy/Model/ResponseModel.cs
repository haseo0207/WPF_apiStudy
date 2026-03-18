using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class ResponseModel
    {
        [JsonPropertyName("body")]
        public BodyModel BodyItem { get; set; } = new();

        [JsonPropertyName("header")]
        public HeaderModel Header { get; set; } = new();
    }
}
