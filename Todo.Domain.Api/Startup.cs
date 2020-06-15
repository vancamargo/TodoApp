using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Todo.Domain.Handlers;
using Todo.Domain.Infra;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Resitories;
using Todo.Domain.Repositories;

namespace Todo.Domaim.Api
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
            // services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
            services.AddDbContext<DataContexts>(opt => opt.UseSqlServer(Configuration.GetConnectionString("UCASAppDatabase")));
            services.AddTransient<ITodoRepository, TodoRepository>();
            services.AddTransient<TodoHandler, TodoHandler>();

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.Authority = "https://securetoken.google.com/project-2422259968811979227";
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidIssuer = "https://securetoken.google.com/project-2422259968811979227",
                       ValidateAudience = true,
                       ValidAudience = "project-2422259968811979227",
                       ValidateLifetime = true
                   };
               });
        }
        //    var firebaseConfig = {
        //apiKey: "AIzaSyCqdOo1BHHP74tSO1Eq7zdVt_B2lpRNpwI",
        //authDomain: "project-2422259968811979227.firebaseapp.com",
        //databaseURL: "https://project-2422259968811979227.firebaseio.com",
        //projectId: "project-2422259968811979227",
        //storageBucket: "project-2422259968811979227.appspot.com",
        //messagingSenderId: "1092973353456",
        //appId: "1:1092973353456:web:ade093d41eafdb46d8e535"

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}



