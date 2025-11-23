using Breadboard.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Breadboard.Application.Extensions;

public class RoutePrefixConvention : IApplicationModelConvention
{
    private readonly string _routePrefix;

    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var controllerNameKebab = controller.ControllerName.ToKebabCase();

            foreach (var selector in controller.Selectors)
            {
                // Se já tiver uma rota na action, combina
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

            // Converte actions para kebab-case (opcional se usar [Http*] com template, mas garante consistência)
            foreach (var action in controller.Actions)
            {
                action.ActionName = action.ActionName.ToKebabCase();
            }
        }
    }
}