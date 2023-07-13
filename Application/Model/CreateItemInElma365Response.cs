namespace NewService.Application.Model;

using Newtonsoft.Json;

public class CreateItemInElma365Response
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class FioKlienta
    {
        [JsonProperty("lastname")]
        public string Lastname { get; set; }
        [JsonProperty("middlename")]
        public string Middlename { get; set; }
        [JsonProperty("firstname")]
        public string Firstname { get; set; }
    }

    public class Item
    {
        public DateTime __createdAt { get; set; }
        public string __createdBy { get; set; }
        public bool __debug { get; set; }
        public string __id { get; set; }
        public int __index { get; set; }
        public string __name { get; set; }
        [JsonProperty("__status")]
        public Status? Status { get; set; }
        public List<string> __subscribers { get; set; }
        public DateTime __updatedAt { get; set; }
        public string __updatedBy { get; set; }
        public int __version { get; set; }
        public string data_otpravki { get; set; }
        [JsonProperty("fio_klienta")]
        public FioKlienta Fullname { get; set; }
        [JsonProperty("id_karty")]
        public string CardId { get; set; }
        public bool karta_kapitalbank { get; set; }
    }
    
    public bool success { get; set; }
    public string error { get; set; }
    public Item item { get; set; }

    public class Status
    {
        public int status { get; set; }
        public int order { get; set; }
    }


}