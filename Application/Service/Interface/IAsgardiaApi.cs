using NewService.Application.Model;
using Refit;

namespace NewService.Application.Service.Interface;

public interface IAsgardiaApi
{
    [Post("/api/v2/card-product-order")]
    Task<GetListCardsResponses> SendData([Query("page")] int page, [Query("size")]int size, GetListCardsRequest body);
    
    [Post("/api/v3/proposal/card-order/ready-for-delivery")]
    Task<SetStatusReadyResponce> SendData([Body] SetStatusReadyRequest body);

    [Post("/api/v3/proposal/card-order/delivered")]
    Task<SetStatusReadyResponce> SendData([Body] SetStatusReadyResponce body);
}