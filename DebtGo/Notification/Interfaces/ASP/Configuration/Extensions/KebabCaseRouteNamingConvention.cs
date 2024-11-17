using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace NotificationsBC.Infrastructure.Routing
{
    public class KebabCaseRouteNamingConvention : IRouteTokenTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value == null)
                return null;

            var input = value.ToString();
            if (string.IsNullOrEmpty(input))
                return null;

            // Convierte CamelCase o PascalCase a kebab-case
            return Regex.Replace(input, "([a-z])([A-Z])", "$1-$2").ToLowerInvariant();
        }
    }
}
