using MediatR;
using NewService.Application.Model;

namespace NewService.Application.UsesCases.Query;

public class CheckElmaAndAsgardiaCardsQuery
{
    public class Query:IRequest<List<string>>
    {
        public List<FakeCard> Cards { get; set; }
    }

    public class CheckElmaAndAsgardiaCardsHandler : IRequestHandler<Query, List<string>>
    {
        private readonly IMediator _mediator;

        public CheckElmaAndAsgardiaCardsHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<List<string>> Handle(Query query, CancellationToken cancellationToken)
        {
            List<string> cardsForChange = new List<string>();
            for (int i = 0; i < query.Cards.Count; i++)
            {
                if (query.Cards[i].Status == 1)
                {
                    Console.WriteLine($"ID карты:{query.Cards[i].Id}, ее статус:{query.Cards[i].Status}, ");
                    cardsForChange.Add(await _mediator.Send(new CheckStatusInElmaQuery.Query{FakeCard = query.Cards[i]}));
                }
            }
            return cardsForChange;
        }
    }
}