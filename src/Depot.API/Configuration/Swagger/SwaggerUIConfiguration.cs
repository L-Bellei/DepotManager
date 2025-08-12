namespace Depot.API.Configuration.Swagger;

public static class SwaggerUIConfiguration
{
    public static void UseSwaggerWithNiceUI(this IApplicationBuilder app, string routePrefix = "swagger")
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Depot API v1");
            c.RoutePrefix = routePrefix;
            c.DisplayRequestDuration();
            c.DocumentTitle = "Depot API Docs";
            c.DefaultModelsExpandDepth(-1);
            c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            c.EnableFilter();
            c.EnableTryItOutByDefault();
            c.ConfigObject.AdditionalItems["persistAuthorization"] = true;
        });
    }
}
