using System.Text.Json.Serialization;

namespace ApiStudy.Model
{
    public class ItemsModel
    {
        [JsonPropertyName("item")]
        public List<ItemModel> Item { get; set; } = new ();
    }
}
