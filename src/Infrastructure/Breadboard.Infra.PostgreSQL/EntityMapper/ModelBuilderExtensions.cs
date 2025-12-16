using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace Breadboard.Infra.PostgreSQL.EntityMapper;

public static class ModelBuilderExtensions
{
    private static IEnumerable<Type> GetMappedClasses(this ModelBuilder builder)
    {
        return typeof(AppDbContext).Assembly
            .GetTypes()
            .Where(x => x.IsSubclassOf(typeof(BaseMapper<>)) &&
                        x.IsAssignableFrom(typeof(IBaseMapper)));
    }

    public static ModelBuilder RegisterAllMaps(this ModelBuilder builder)
    {
        var types = builder.GetMappedClasses();

        foreach (var type in types)
        {
            var mapper = (IBaseMapper)Activator.CreateInstance(type)!;
            mapper.Apply(builder);
        }

        return builder;
    }
}