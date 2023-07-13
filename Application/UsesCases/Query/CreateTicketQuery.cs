using System.Net.Http.Headers;
using MediatR;
using NewService.Application.Model;
using NewService.Application.Service.Interface;
using NewService.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NewService.Application.UsesCases.Query;

public class CreateTicketQuery
{
    public class Query : IRequest<string>
    { 
        public CreateItemInElma365Request Card { get; set; }
    }

    public class CreateTicketHandler : IRequestHandler<Query, string>
    {
        
        public async Task<string> Handle(Query query, CancellationToken cancellationToken)
        {
            var word = "";
        
            try
            {
                var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var uri = config.GetSection("Elma Service")["ElmaUrl"];
                
                var httpClient = new HttpClient { BaseAddress = new Uri(uri!) };

                var bearer = config.GetSection("Elma Service")["Bearer"];
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",bearer );

                var settings = new RefitSnakeSetting().SetSnakeSetting();
                var apiCreateCard = RestService.For<IElma365Api>(httpClient,settings);

                var body = query.Card;
                
                var item = await apiCreateCard.SendData(body);
                Console.WriteLine($"Card with ID: {item.item.CardId} is created");
                Console.WriteLine($"Info about card: id: {item.item.CardId}, " +
                                  $"status: {item.item.Status.status}, " +
                                  $"fullname: {item.item.Fullname.Lastname} {item.item.Fullname.Firstname} {item.item.Fullname.Middlename}");
                word = item.item.CardId;
                return word;

            }
            catch(HttpRequestException e)
            {
                Console.WriteLine("\nВозникло исключение!");
                Console.WriteLine("Сообщение: {0}", e.Message);
            }
            return word;
        }
    }
}