using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Extensions.Swagger;

namespace WebApi.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>()
                    .AddSwaggerGen();

            return services;
        }

        public static IApplicationBuilder UseVersionedSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
        {
            app.UseSwagger(AddPreSerializeFilters());
            app.UseSwaggerUI
                (
                    options =>
                    {
                        foreach (var description in provider.ApiVersionDescriptions)
                        {
                            options.SwaggerEndpoint($"{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
                        }
                        options.DocumentTitle = "Documentation";
                        options.DocExpansion(DocExpansion.None);
                    }
                );

            return app;
        }

        private static Action<SwaggerOptions> AddPreSerializeFilters()
        {
            return options =>
            {
                options.PreSerializeFilters.Add
                (
                    (document, request) => document.Servers = GetServers(request)
                );
            };
        }

        private static string GetUrl(HttpRequest request)
        {
            if (request.Headers.ContainsKey("X-Original-URI"))
            {
                return request.Headers["X-Original-URI"]
                    .FirstOrDefault()
                    .Split(new[] { "/swagger" }, StringSplitOptions.RemoveEmptyEntries)
                    .FirstOrDefault();
            }

            return $"{request.Scheme}://{request.Host.Value}";
        }

        private static IList<OpenApiServer> GetServers(HttpRequest request)
        {
            var url = GetUrl(request);

            return new List<OpenApiServer>
            {
                new OpenApiServer
                {
                    Url = url
                }
            };
        }
    }
}
