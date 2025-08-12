using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Depot.API.Configuration.Swagger;

public static class SwaggerConfiguration
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerExamplesFromAssemblies(Assembly.GetExecutingAssembly());
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Depot API",
                Version = "v1",
                Description = "API for Depot Management"
            });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT on header. Ex: Bearer {seu_token}",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT"
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });

            var xmls = Directory.GetFiles(AppContext.BaseDirectory, "*.xml");
            foreach (var xml in xmls) c.IncludeXmlComments(xml, includeControllerXmlComments: true);

            c.EnableAnnotations(enableAnnotationsForInheritance: true, enableAnnotationsForPolymorphism: true);
            c.ExampleFilters();

            c.SchemaGeneratorOptions.SchemaIdSelector = t => t.FullName!;

            c.UseAllOfToExtendReferenceSchemas();
            c.SupportNonNullableReferenceTypes();

            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date"
            });

            c.MapType<TimeOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "time"
            });

            c.TagActionsBy(api =>
            {
                if (api.ActionDescriptor is ControllerActionDescriptor cad)
                {
                    var ns = cad.ControllerTypeInfo?.Namespace;
                    var feature = ns?.Split('.').LastOrDefault();

                    if (!string.IsNullOrWhiteSpace(feature) && !string.Equals(feature, "Controllers", StringComparison.OrdinalIgnoreCase))
                        return [feature!];
                }

                var controller = api.GroupName ?? api.ActionDescriptor.RouteValues["controller"];

                return [controller ?? "Endpoints"];
            });

            c.OperationFilter<SecurityRequirementsOperationFilter>();
            c.OperationFilter<DefaultResponsesOperationFilter>();
        });
    }

    private class DefaultResponsesOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var needsAuth =
                context.MethodInfo.DeclaringType?.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any() == true ||
                context.MethodInfo.GetCustomAttributes(true).OfType<AuthorizeAttribute>().Any();

            if (needsAuth)
            {
                operation.Responses.TryAdd("401", new OpenApiResponse { Description = "Unauthorized" });
                operation.Responses.TryAdd("403", new OpenApiResponse { Description = "Forbidden" });
            }

            operation.Responses.TryAdd("400", new OpenApiResponse { Description = "Bad Request" });
            operation.Responses.TryAdd("500", new OpenApiResponse { Description = "Internal Server Error" });
        }
    }
}
