using graphql_demo.Interface;
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
                .AddQueryType<QueryType>()
                .Create());

            services.AddHttpClient("conspiracies", (sp, client) =>
            {
                client.BaseAddress = new Uri("http://127.0.0.1:44323");
            });

            services.AddStitchedSchema(builder =>
                builder.AddSchemaFromHttp("conspiracies"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
