namespace NewService.Application.Model;

public class FakeCard
{
    public string Id { get; set; }
    public FullName? Fullname{ get; set; }
    public string Branch { get; set; }
    public DateTime CreateDate { get; set; }
    public string FileUrl { get; set; }
    public string PhoneNumber { get; set; }
    public string Pinfl { get; set; }
    public string DocumentType { get; set; }
    public readonly bool CardIsKapitalbank = false;
    public int Status { get; set; }

    public class FullName
    {
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
    }
}