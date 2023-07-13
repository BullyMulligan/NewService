using MediatR;
using NewService.Application.Core;
using NewService.Application.UsesCases.Query;

namespace NewService.Application.UsesCases.Command;

public class StartProcessCommand
{
    public class Command:IRequest<Result<string>>
    {
        
    }

    public class StartProcessHandler : IRequestHandler<Command, Result<string>>
    {
        private readonly IMediator _mediator;

        public StartProcessHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<Result<string>> Handle(Command command,CancellationToken cancellationToken)
        {
            try
            {
                var cards = await _mediator.Send(new GetFakeCardsQuery.Query());
            
                var cardsReadyToDelivery = await _mediator.Send(new CheckElmaAndAsgardiaCardsQuery.Query{ Cards = cards });
                Console.WriteLine($"Number of cards ready for delivery at a given time({DateTime.Now}): {cardsReadyToDelivery.Count}");
                return Result<string>.Success("Все окейси");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Result<string>.Failure(e.ToString());
            }
        }
    }
}