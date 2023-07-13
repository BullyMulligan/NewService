using System.Net.Http.Headers;
using MediatR;
using NewService.Application.Model;
using NewService.Application.Service.Interface;
using NewService.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NewService.Application.UsesCases.Query;

public class ChangeStatusCardsInAsgardiaCommand
{
    public class Command : IRequest<SetStatusReadyResponce>
    {
        public List<string> idCards { get; set; }
    }

    public class ChangeStatusCardsInAsgardiaHandler : IRequestHandler<Command,SetStatusReadyResponce>
    {
        private readonly IConfiguration _config;

        public ChangeStatusCardsInAsgardiaHandler(IConfiguration config)
        {
            _config = config;
        }


        public async Task<SetStatusReadyResponce> Handle(Command command,CancellationToken cancellationToken)
        {
            var uri = _config.GetSection("Elma Service")["ElmaUrl"];
            var httpClient = new HttpClient { BaseAddress = new Uri(uri) };

            var bearer = _config.GetSection("Elma Service")["Bearer"];
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",bearer );

            var settings = new RefitSnakeSetting().SetSnakeSetting();

            var api = RestService.For<IAsgardiaApi>(httpClient, settings);
            
            var list = new List<SetStatusReadyRequest.Item>();

            foreach (var cardId in command.idCards)
            {
                var item = new SetStatusReadyRequest.Item { Id = cardId };
                list.Add(item);
            }
            
            var body = new SetStatusReadyRequest
            {
                Date = list
            };

            var response = await api.SendData(body);
            return response;
        }
    }

}