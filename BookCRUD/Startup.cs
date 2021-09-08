using BookCRUD.Attributes;
using Core.Services;
using Core.Services.Contracts;
using Database;
using Database.Repositories;
using Database.Repositories.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace BookCRUD
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
            services.AddDbContext<BookContext>(opt =>
                opt.UseInMemoryDatabase("Book"));

            services.AddControllers(opt => opt.Filters.Add(new NotFoundResultFilterAttribute()));
            services.AddApiVersioning(opt => opt.AssumeDefaultVersionWhenUnspecified = true);

            services.AddSwaggerGen(
                options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore", Version = "v1" })
            );

            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger()
                .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Book Store V1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
