using System.Reflection;
using Breadboard.Infra.PostgreSQLDapper.Abstractions;
using Breadboard.Shared.Entities;

namespace Breadboard.Infra.PostgreSQLDapper.Extensions;

public static class DIscover
{
    /// <summary>
    /// When we create multiples dependency injections, .NET considers only the last one as the current.
    /// If:
    /// services.AddScoped(InterfaceA, ClasseA);
    /// services.AddScoped(IInterfaceA, ClassB);
    /// the real implementations is going to be ClassB, ignoring the first assignment.
    ///
    /// BUT IF YOU INTEND TO DECLARE MANY REPOSITORIES IN CERTAIN INTERFACE, YOU CAN USE IT BY REQUESTING
    /// IEnumerable<IInterfaceType> AT ANY CONSTRUCTORS, AND IT REALLY WORKS!
    ///
    /// You can iterate over this list and call its methods like so. It has no real usability in real scenarios.
    /// It also breaks DRY principle because you cannot any of that injections except for the last one,
    /// you would need to create another interface to use it. 
    /// </summary>
    /// <param name="assembly"></param>
    /// <returns></returns>
    public static IEnumerable<QueryRepositoryInfo> GetQueryRepositories(this Assembly assembly)
    {
        //search for all classes with marker interface
        var classes = assembly
            .GetTypes()
            .Where(t => t is { IsClass: true, IsAbstract: false } &&
                        typeof(IQueryRepository).IsAssignableFrom(t));

        return classes.SelectMany(classType =>
        {
            return classType
                .GetInterfaces()
                .Where(x => x != typeof(IQueryRepository)).Select(x =>
                    new QueryRepositoryInfo(x, classType));
        });
    }
}

//IsAssignableFrom: type A can be assigned as T?
// so typeof(int).IsAssignableFrom(typeof(string)) returns false
// and typeof(IUserRepository).IsAssignableFrom(typeof(UserRepository)) returns true
// considering UserRepository is concrete e& implements IUserRepository

//get interfaces besides the marker

//single injection?
//var interfaceType = classType.GetInterfaces().FirstOrDefault(x => x != typeof(IQueryRepository));
//or MULTIPLE injections? DI lets us decide

// if (interfaceType == null)
//     throw
//         new InvalidOperationException(
//             @"Query repositories must implement an Interface besides IQueryRepository.");

// return new QueryRepositoryInfo(interfaceType, classType);