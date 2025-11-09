using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Breadboard.Application.Extensions
{
 public static class JsonExtensions
    {
        public static IServiceCollection ConfigureJsonOptions(this IServiceCollection services)
        {
            services.AddControllers().AddJsonOptions(opt =>
                {
                    opt.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    // opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                    opt.JsonSerializerOptions.MaxDepth = 64;
                    opt.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip; // ignora comentários
                    opt.JsonSerializerOptions.WriteIndented = true;

                    opt.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; // camelCase
                    opt.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase; // dicionários
                    //aceita maiusculas, minusculas, etc
                    opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                }
            );
            return services;
        }
    }
}