using Bogus;
using NewService.Application.Model;

namespace NewService.Infostructure.Bogus;
//Реализация фейковых карт через БОГУС, пока нет доступа к Асгардиа
public class FakeCardRepository
{
    //указываем количество карт и id, с которого будет начинаться бд
    public readonly IEnumerable<FakeCard> _cards;
    private int _count = 11;
    private int _idCounter = 0;

    public FakeCardRepository()
    {
        //Заполняем карты
        var fullNameFaker = new Faker<FakeCard.FullName>().
            RuleFor(t => t.Name, t => "Ваня").
            RuleFor(t => t.Middlename, t => "Геннадьевич").
            RuleFor(t => t.Lastname, t => "Попов");
        var cardFaker = new Faker<FakeCard>().
            RuleFor(t => t.Status, c => c.Random.Number(1, 3)).
            RuleFor(t => t.CreateDate, c => DateTime.Now).
            RuleFor(t => t.Pinfl, c => "12345678").
            RuleFor(t => t.DocumentType, c => "passport").
            RuleFor(t => t.PhoneNumber, c => "+998940937094").
            RuleFor(t => t.Branch, c => "COO").
            RuleFor(t => t.Fullname, f => fullNameFaker).
            RuleFor(t => t.Id, c => GetNextId().ToString());
        _cards = cardFaker.Generate(_count);
    }
    

    //метод меняющий id карты, нарастающий с каждым разом на 1
    private int GetNextId()
    {
        var nextId = Interlocked.Increment(ref _idCounter);
        return nextId;
    }

    //метод получения листа карт
    public IEnumerable<FakeCard> GetAll()
    {
        return _cards;
    }
}