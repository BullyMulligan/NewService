using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;

namespace NewService.Properties;

public class RefitSnakeSetting
{
    //метод, который возвращает настройки рефита в стиле snake_case
    public RefitSettings SetSnakeSetting()
    {
        var settings = new RefitSettings
        {
            ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new SnakeCaseNamingStrategy() // Настройки наименования полей в стиле "snake_case"
                }
            })
        };
        return settings;
    }
}