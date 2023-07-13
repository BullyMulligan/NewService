namespace NewService.Application.Model;

public class GetListCardsRequest
{
    public int dateFrom { get; set; }
    public int dateTo { get; set; }
    public string status { get; set; }
    public string userId { get; set; }
    public string id { get; set; }
    public string branchId { get; set; }
    public string phone { get; set; }
    public string client { get; set; }
    public string owner { get; set; }
    public string delivery { get; set; }
    public string cardProductId { get; set; }
}