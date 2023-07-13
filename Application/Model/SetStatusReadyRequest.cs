namespace NewService.Application.Model;

public class SetStatusReadyRequest
{
    public List<Item> Date { get; set; }
    public class Item
    {
        public string Id { get; set; }
    }
}