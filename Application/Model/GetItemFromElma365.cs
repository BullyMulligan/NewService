using Newtonsoft.Json;

namespace NewService.Application.Model;

public class GetItemFromElma365
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Filter
    {
        [JsonProperty("tf")]
        public Tf Tf { get; set; }
    }

    [JsonProperty("active")]
    public bool Active { get; set; }
    [JsonProperty("filter")]
    public Filter filter { get; set; }
    [JsonProperty("size")]
    public int Size { get; set; }
    
    public class Tf
    {
        [JsonProperty("id_karty")]
        public string CardId { get; set; }
    }
    
}