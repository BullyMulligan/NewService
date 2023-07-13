using System.Windows.Input;
using MediatR;
using NewService.Application.Model;
using NewService.Infostructure.Bogus;

namespace NewService.Application.UsesCases.Query;

public class GetFakeCardsQuery
{
    public class Query : IRequest<List<FakeCard>>
    {
    }

    public class CheckStatusCardHandler : IRequestHandler<Query, List<FakeCard>>
    {
            
        public async Task<List<FakeCard>> Handle(Query query, CancellationToken cancellationToken)
        {
            var fakeCardRepository = new FakeCardRepository();
            var cards = fakeCardRepository.GetAll().ToList();
            foreach (var card in cards)
            {
                Console.WriteLine($"Card ID: {card.Id} Status:{card.Status}, " +
                                  $"Full Name:{card.Fullname.Lastname} {card.Fullname.Name} " +
                                  $"{card.Fullname.Middlename}"); 
            }
            return cards;
        }

    }
}