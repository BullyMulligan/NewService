using Microsoft.AspNetCore.Mvc;
using NewService.Application.UsesCases.Query;
using Swashbuckle.AspNetCore.Annotations;
using NewService.API.Controller;
using NewService.Application.UsesCases.Command;

namespace NewService.API.Controllers
{
    public class StartProcessController : BaseController
    {
        [HttpGet]
        [SwaggerOperation(Summary = "Запускает процесс проверки карт на Асгардии", Tags = new[] { "Тег" })]
        [SwaggerResponse(200, "Успешный ответ")]
        public async Task<IActionResult> GetCards()
        {
            
            var item = await Mediator.Send(new StartProcessCommand.Command());
            
            Console.WriteLine("Check function started remotely manually");
            
            return Ok(item);
        }
    }
}