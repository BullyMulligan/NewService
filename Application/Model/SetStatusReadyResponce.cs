namespace NewService.Application.Model;

public class SetStatusReadyResponce
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    
    public List<Datum> data { get; set; }
    public string errorMessage { get; set; }
    public long timestamp { get; set; }

    public class Datum
    {
        public string id { get; set; }
        public string status { get; set; }
        public string statusName { get; set; }
        public string errorCode { get; set; }
        public string errorDescription { get; set; }
    }
    
}