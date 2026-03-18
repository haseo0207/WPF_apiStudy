using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class ItemModel
    {
        [JsonPropertyName("file_download_url")]
        public string File_DownLoad_url { get; set; } = string.Empty;
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("title")]
        public string Title { get; set; } = string.Empty;
        [JsonPropertyName("txt_origin_cn")]
        public string Txt_Origin_cn { get; set; } = string.Empty;
        [JsonPropertyName("written_dt")]
        public DateTime Written_Dt { get; set; }
    }
}
