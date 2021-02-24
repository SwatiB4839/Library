using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryWebApp.Database;
using LibraryWebApp.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using LibraryWebApp.DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApp
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
           
            services.Configure<LibraryDatabaseSettings>(
      Configuration.GetSection(nameof(LibraryDatabaseSettings)));
            services.AddSingleton<ILibraryDatabaseSettings>(provider =>
                provider.GetRequiredService<IOptions<LibraryDatabaseSettings>>().Value);
            services.AddScoped<AuthorService>();
            services.AddScoped<BookService>();
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<UserContext>(opts =>
            opts.UseSqlServer("server=LAPTOP-U7U5RVD0\\SQLEXPRESS;database=UserDB;Integrated Security=True"));
            services.AddTransient<ITokenService, TokenService>();
            services
             .AddCors(options =>
             {
                 options.AddPolicy("CorsPolicy",
                     builder => builder
                     .AllowAnyOrigin()
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     );

                 options.AddPolicy("signalr",
                     builder => builder
                     .AllowAnyMethod()
                     .AllowAnyHeader()

                     .AllowCredentials()
                     .SetIsOriginAllowed(hostName => true));
             });
            services.AddAuthentication(opt => {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "http://localhost:5001",
            ValidAudience = "http://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });

            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
