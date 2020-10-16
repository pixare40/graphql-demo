using graphql_demo.Interface;
using graphql_demo.Resolvers;
using graphql_demo.Services;
using graphql_demo.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using HotChocolate.AspNetCore.Subscriptions;
using HotChocolate.Stitching;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace graphql_demo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IPresidentService, PresidentService>();
            services.AddDataLoaderRegistry();

            var schema1 = SchemaBuilder.New()
                .AddDocumentFromFile("schema.sdl")
                .BindComplexType<Query>(c => c.To("Query"))
                .BindResolver<QueryResolver>(c => c
                   .To("Query")
                   .Resolve("president")
                   .With(t => t.President(default)))
                .BindResolver<PresidentResolver>(c => c
                    .To("President"))
                .Create();

            //services.AddGraphQL(schema1);

            services.AddGraphQLSubscriptions();

            services.AddHttpClient("conspiracies", (sp, client) =>
            {
                client.BaseAddress = new Uri("https://localhost:44323/");
            });

            services.AddStitchedSchema(builder =>
                builder
                .AddSchemaFromHttp("conspiracies")
                .AddSchema("schema1", schema1)
                .AddSchemaConfiguration(c =>
                {
                    c.RegisterExtendedScalarTypes();
                }));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseGraphQL();
            app.UsePlayground();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Presidents Endpoint");
            });
        }
    }
}
