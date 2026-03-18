using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class BodyModel
    {
        [JsonPropertyName("dataType")]
        public string DataType { get; set; } = string.Empty;
        [JsonPropertyName("items")]
        public ItemsModel Items { get; set; } = new ();
        [JsonPropertyName("numOfRows")]
        public int NumOfRows { get; set; }
        [JsonPropertyName("pageNo")]
        public int PageNo { get; set; }
        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
}
