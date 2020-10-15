using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace graphql_demo_conspiracies
{
    public class Conspiracy
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PresidentId { get; set; }

        public string Description { get; set; }
    }

    public interface IConspiraciesService
    {
        IQueryable<Conspiracy> GetAll();
    }

    public class ConsipraciesService : IConspiraciesService
    {
        private List<Conspiracy> conspiracies;

        public ConsipraciesService()
        {
            conspiracies = new List<Conspiracy>
            {
                new Conspiracy{Id=1, Name="Libya", PresidentId=44, Description=""},
                new Conspiracy{Id=2, Name="Watergate", PresidentId=37},
                new Conspiracy{Id=3, Name="Monica Lewinski Scandal", PresidentId=42}
            };
        }

        public IQueryable<Conspiracy> GetAll()
        {
            throw new NotImplementedException();
        }
    }

    public class Query
    {
        private readonly IConspiraciesService _conspiracyService;
        public Query(IConspiraciesService conspiracyService)
        {
            _conspiracyService = conspiracyService;
        }

        [UseFiltering]
        public IQueryable<Conspiracy> Conspiracies => _conspiracyService.GetAll();
    }

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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
