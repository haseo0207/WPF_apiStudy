using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class JsonResponseModel
    {
        [JsonPropertyName("response")]
        public ResponseModel Response { get; set; } = new();
    }
}
