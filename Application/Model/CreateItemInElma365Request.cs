using Newtonsoft.Json;

namespace NewService.Application.Model;

public class CreateItemInElma365Request
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    
    [JsonProperty("context")]
    public Context context { get; set; }
    public class Context
    {
        [JsonProperty("fio_klienta")]
        public FioKlienta Fullname { get; set; }
        [JsonProperty("id_karty")]
        public string CardId { get; set; }
        [JsonProperty("data_otpravki")]
        public DateTime SendDate { get; set; }
        public List<string> filial_vydachi { get; set; }
        public string ssylka { get; set; }
        [JsonProperty("ssylki_na_faily")]
        public string FilialLink { get; set; }
        [JsonProperty("nomer_telefona")]
        public List<NomerTelefona> PhoneNumber { get; set; }
        
        public string Pinfl { get; set; }
        [JsonProperty("tip_dokumenta")]
        public string DocumentType { get; set; }
        [JsonProperty("karta_kapitalbank")]
        public bool CardIsKapitalbank { get; set; }
    }

    public class FioKlienta
    {
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public string Firstname { get; set; }
    }

    public class NomerTelefona
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("tel")]
        public string PhoneNumber { get; set; }
    }
    
}