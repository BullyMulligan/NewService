using NewService.Application.Model;
using Refit;

namespace NewService.Application.Service.Interface;

public interface IElma365Api
{
    //Получаем список карт(в теле указываем фильтрацию)
    [Post("/pub/v1/app/vydacha_kart/karty/list")]
    Task<GetListCardsResponses> GetCardList([Body] GetItemFromElma365 body);

    
    [Post("/pub/v1/app/vydacha_kart/karty/create")]
    Task<CreateItemInElma365Response> SendData([Body] CreateItemInElma365Request body);
}