using Newtonsoft.Json;

namespace NewService.Application.Model;

public class GetListCardsResponses
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    
    public bool success { get; set; }
    public string error { get; set; }
    [JsonProperty("result")]
    public Result result { get; set; }
    
    public class Instance
    {
        public string __id { get; set; }
        public string code { get; set; }
        public string __name { get; set; }
        public string @namespace { get; set; }
    }

    public class Item
    {
        public string id { get; set; }
        public string code { get; set; }
        public string @namespace { get; set; }
    }

    public class Result
    {
        public List<Result> result { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
        public string __id { get; set; }
        public object pinfl { get; set; }
        public string __name { get; set; }
        public List<object> filial { get; set; }
        public object ssylka { get; set; }
        public bool __debug { get; set; }
        public int __index { get; set; }
        public List<Task> __tasks { get; set; }
        
        [JsonProperty("__status")]
        public Status Status { get; set; }
        [JsonProperty("id_karty")]
        public string CardId { get; set; }
        public int __version { get; set; }
        public string __createdAt { get; set; }
        public string __createdBy { get; set; }
        public string __updatedAt { get; set; }
        public string __updatedBy { get; set; }
        public object fio_klienta { get; set; }
        public object __externalId { get; set; }
        public object data_vydachi { get; set; }
        public List<string> __subscribers { get; set; }
        public string data_otpravki { get; set; }
        public object nomer_klienta { get; set; }
        public object tip_dokumenta { get; set; }
        public List<object> filial_vydachi { get; set; }
        public object nomer_telefona { get; set; }
        public object ssylki_na_faily { get; set; }
        public object data_polucheniya { get; set; }
        public object skany_dokumentov { get; set; }
        public object karta_kapitalbank { get; set; }
        public List<string> __tasks_performers { get; set; }
        public object karta_kapital_bank { get; set; }
        public object __externalProcessMeta { get; set; }
        public object __tasks_earliest_duedate { get; set; }
        public object skany_podpisannykh_dokumentov { get; set; }
    }

    public class Status
    {
        public int order { get; set; }
        [JsonProperty("status")]
        public int status { get; set; }
    }

    public class Task
    {
        [JsonProperty("__id")]
        public string Id { get; set; }
        public string path { get; set; }
        public string state { get; set; }
        [JsonProperty("__item")]
        public Item Item { get; set; }
        [JsonProperty("__name")]
        public string Name { get; set; }
        public string branch { get; set; }
        public object dueDate { get; set; }
        public bool openRef { get; set; }
        public object planEnd { get; set; }
        public string timerId { get; set; }
        public string __target { get; set; }
        public Instance instance { get; set; }
        public string template { get; set; }
        public List<object> __context { get; set; }
        public int __percent { get; set; }
        public object companies { get; set; }
        public object planStart { get; set; }
        public List<string> performers { get; set; }
        public object reassignes { get; set; }
        public string __createdAt { get; set; }
        public string __createdBy { get; set; }
        public object __deletedAt { get; set; }
        public string __updatedAt { get; set; }
        public string __updatedBy { get; set; }
        public object __targetData { get; set; }
        public object detachedInfo { get; set; }
        public bool allowReassign { get; set; }
        public string templateNsAndCode { get; set; }
        public List<string> originalPerformers { get; set; }
    }

}