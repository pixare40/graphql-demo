using graphql_demo.Interface;
using graphql_demo.Resolvers;
using graphql_demo.Services;
using graphql_demo.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
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
            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddDocumentFromFile("schema.sdl")
                .BindComplexType<Query>(c=> c.To("Query"))
                .BindResolver<QueryResolver>( c=> c
                    .To("Query")
                    .Resolve("president")
                    .With(t=> t.President(default)))
                .BindResolver<PresidentResolver>(c=> c
                    .To("President"))
                .Create());

            //services.AddHttpClient("conspiracies", (sp, client) =>
            //{
            //    client.BaseAddress = new Uri("http://127.0.0.1:44323");
            //});

            //services.AddStitchedSchema(builder =>
            //    builder.AddSchemaFromHttp("conspiracies"));
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
