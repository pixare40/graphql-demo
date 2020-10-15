using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using HotChocolate.AspNetCore;
using HotChocolate;
using Microsoft.AspNetCore.Http;
using HotChocolate.Types;

namespace graphql_demo
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }

    public interface IAuthorService
    {
        IQueryable<Author> GetAll();
    }

    public class AuthorService : IAuthorService
    {
        private List<Author> authors;
        public AuthorService()
        {
            authors = new List<Author>()
            {
                new Author{ Id = 37, Name = "Richard", Surname="Nixon"},
                new Author{Id= 38, Name= "Gerald", Surname = "Ford"},
                new Author{Id=39, Name="Jimmy", Surname="Carter"},
                new Author{Id= 40, Name="Ronald", Surname="Reagan"},
                new Author{Id= 41, Name="George", Surname="Bush Sr"},
                new Author{Id= 42, Name="Bill", Surname="Clinton"},
                new Author{Id= 43, Name="George", Surname="Bush"},
                new Author{Id= 44, Name="Barrack", Surname="Obama"},
                new Author{Id= 45, Name="Donald", Surname="Trump"},
            };
        }

        public IQueryable<Author> GetAll()
        {
            return authors.AsQueryable();
        }
    }

    public class Query
    {
        private readonly IAuthorService _authorService;
        public Query(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [UseFiltering]
        public IQueryable<Author> Authors => _authorService.GetAll();
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
            services.AddSingleton<IAuthorService, AuthorService>();
            services.AddGraphQL(s => SchemaBuilder.New()
                .AddServices(s)
                .AddType<Author>()
                .AddType<Book>()
                .AddQueryType<Query>()
                .Create());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseHttpsRedirection();

            //app.UseRouting();

            //app.UseAuthorization();

            app.UseGraphQL();
            app.UsePlayground();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
