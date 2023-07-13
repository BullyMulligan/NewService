using System.Net.Http.Headers;
using MediatR;
using NewService.Application.Model;
using NewService.Application.Service.Interface;
using NewService.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NewService.Application.UsesCases.Query;

public class CheckStatusInElmaQuery
{
    public class Query : IRequest<string>
    {
        public FakeCard FakeCard { get; set; }
    }

    public class CheckStatusInElmaHandler : IRequestHandler<Query, string>
    {
        
        private readonly IMediator _mediator;
        private readonly IConfiguration _config;

        public CheckStatusInElmaHandler(IMediator mediator)
        {
            _mediator = mediator;
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public async Task<string> Handle(Query query, CancellationToken cancellationToken)
        {
            try
            {
                var uri = _config.GetSection("Elma Service")["ElmaUrl"];
                
                var httpClient = new HttpClient { BaseAddress = new Uri(uri!) };

                var bearer = _config.GetSection("Elma Service")["Bearer"];
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",bearer );

                var settings = new RefitSnakeSetting().SetSnakeSetting();
                
                var apiGetCard = RestService.For<IElma365Api>(httpClient,settings);
            
                var request = new GetItemFromElma365
                {
                    Active = true,
                    filter = new GetItemFromElma365.Filter
                    {
                        Tf = new GetItemFromElma365.Tf
                        {
                            CardId = query.FakeCard.Id
                        }
                    },
                    Size = 1
                };
            
                var item = await apiGetCard.GetCardList(request);
            
                if (item.result.Total == 0)
                {
                
                    var cardNull = new CreateItemInElma365Request
                    {
                        context = new CreateItemInElma365Request.Context
                        {
                            Fullname = new CreateItemInElma365Request.FioKlienta
                            {
                                Firstname = query.FakeCard.Fullname.Name,
                                Middlename = query.FakeCard.Fullname.Middlename,
                                Lastname = query.FakeCard.Fullname.Lastname
                            },
                            CardId = query.FakeCard.Id,
                            DocumentType = query.FakeCard.DocumentType,
                            SendDate = query.FakeCard.CreateDate,
                            FilialLink = query.FakeCard.FileUrl,
                            PhoneNumber = new List<CreateItemInElma365Request.NomerTelefona>
                            { 
                                new()
                                {
                                    Type = "home",
                                    PhoneNumber = query.FakeCard.PhoneNumber
                                }
                            },
                            Pinfl = query.FakeCard.Pinfl,
                            CardIsKapitalbank = query.FakeCard.CardIsKapitalbank
                        }
                    };
                    var id = await _mediator.Send(new CreateTicketQuery.Query{ Card = cardNull });
                    return id;
                }
                if (item.result.result[0].Status.status == 1)
                {
                    return item.result.result[0].CardId;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nВозникло исключение!");
                Console.WriteLine("Сообщение: {0}", e.Message);
            }
            return null;
        }
    }
}