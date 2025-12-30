using Breadboard.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Presentation.TransformCase;

public class RoutePrefixConvention : IApplicationModelConvention
{
    private readonly string _routePrefix;

    /// <summary>
    /// such a mess, it  just duplicates everything and that's it
    /// </summary>
    /// <param name="application"></param>
    [Obsolete("Use KebabCaseTransformer")]
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var controllerNameKebab = controller.ControllerName.ToKebabCase();

            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    selector.AttributeRouteModel = AttributeRouteModel.CombineAttributeRouteModel(
                        new AttributeRouteModel(new RouteAttribute($"{_routePrefix}/{controllerNameKebab}")),
                        selector.AttributeRouteModel
                    );
                }
                else
                {
                    selector.AttributeRouteModel = new AttributeRouteModel(
                        new RouteAttribute($"{_routePrefix}/{controllerNameKebab}")
                    );
                }
            }

            foreach (var action in controller.Actions)
            {
                action.ActionName = action.ActionName.ToKebabCase();
            }
        }
    }
}