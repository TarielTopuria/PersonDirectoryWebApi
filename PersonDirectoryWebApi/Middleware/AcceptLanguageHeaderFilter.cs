using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace PersonDirectoryWebApi.Middleware
{
    public class AcceptLanguageHeaderFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "accept-language",
                In = ParameterLocation.Header,
                Required = true,
                Description = "Accepted language",
                Schema = new OpenApiSchema
                {
                    Default = new OpenApiString("en-US"),
                    Type = "string"
                }
            });
        }
    }
}
