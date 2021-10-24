using System;
using JsonDemoTwo.Contracts;
using JsonDemoTwo.Models;
using JsonDemoTwo.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace JsonDemoTwo
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
            
            /* EF Core DbContext */
            var connectionString = Configuration["MSSQLServer:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connectionString));
            
            // Redis Cache
            
            
            /* AutoMapper for mapping Entities to Dtos */
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            /* CORS */
            services.AddCors();
            
            //API versioning
            //Open API documentation
            //Hangfire-  a timer or chron jobs or scheduled jobs
            //Auth
            
            //Health Checks 
            services.AddHealthChecks();
            
            //This can be put on a separate folder and file 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "JsonDemoTwo.WebApi", Version = "v1" });
            });
            
            
            /* scrutor */
            services.Scan(scan =>
                scan.FromCallingAssembly()
                    .AddClasses()
                    .AsMatchingInterface());

            //Scrutor maps automatically from interface to service. So as a result,  e.g. 
            //services.AddScoped<IPerson, Person>  => services.AddScoped<> 
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "JsonDemoTwo.WebApi v1"));
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = (context) =>
                {
                    //Retrieve cache configuration from appsettings json
                    context.Context.Response.Headers["Cache-Control"] =
                        Configuration["StaticFiles: Headers: Cache-Control"];
                }
            });
            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}