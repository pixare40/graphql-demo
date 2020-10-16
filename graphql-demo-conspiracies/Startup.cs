using graphql_demo_conspiracies.Interface;
using graphql_demo_conspiracies.Services;
using graphql_demo_conspiracies.Types;
using HotChocolate;
using HotChocolate.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace graphql_demo_conspiracies
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConspiraciesService, ConsipraciesService>();
            services.AddGraphQL(s => SchemaBuilder.New().AddServices(s)
                .AddServices(s)
                .AddQueryType<QueryType>()
                .Create());
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
                await context.Response.WriteAsync("Consipracies Endpoint");
            });
        }
    }
}
