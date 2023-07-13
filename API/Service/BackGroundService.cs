using MediatR;
using NewService.Application.UsesCases.Command;
using NewService.Application.UsesCases.Query;

namespace NewService.API.Service;

public class BackGroundService:BackgroundService
{
    private IMediator _mediator;
    private readonly int _interval = 1800;
    
    
    public BackGroundService(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            //прописываем логику
            // var cards = await _mediator.Send(new GetFakeCardsQuery.Query());
            //
            // var cardsReadyToDelivery = await _mediator.Send(new CheckElmaAndAsgardiaCardsQuery.Query{ Cards = cards });
            // Console.WriteLine($"Количество карт готовых к доставке: {cardsReadyToDelivery.Count}");
            
            await _mediator.Send(new StartProcessCommand.Command());
            
            await Task.Delay(TimeSpan.FromSeconds(_interval), stoppingToken);
        }
    }
}