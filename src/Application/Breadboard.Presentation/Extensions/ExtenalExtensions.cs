using System.Text.Json;
using System.Text.Json.Serialization;

namespace Breadboard.Presentation.Extensions
{
 public static class ExtenalExtensions
    {
        public static IServiceCollection ConfigureJsonConvention(this IMvcBuilder builder)
        {
            builder.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                opt.JsonSerializerOptions.MaxDepth = 64;
                opt.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip; // ignore comments
                opt.JsonSerializerOptions.WriteIndented = true;
                opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // camelCase
                opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase; // dictionaries
                opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            });
            return builder.Services;
        }
    }
}