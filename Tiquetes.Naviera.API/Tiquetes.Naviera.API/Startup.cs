using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tiquetes.Naviera.Data;
using Tiquetes.Naviera.Repository;
using Tiquetes.Naviera.Services;

namespace Tiquetes.Naviera.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Este método se llama por el tiempo de ejecución. Usa este método para agregar servicios al contenedor.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API de Tiquetes Naviera", Version = "v1" });
            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "issuer",
                        ValidAudience = "audience",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["SecretKey"]))
                    };
                });
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            var connection = Configuration["ConnectionStrings:MySqlConnection"];
            ////services.AddScoped<DbContext>(sp => sp.GetRequiredService<ApplicationDbContext>());
            ////services.AddDbContext<ApplicationDbContext>(
            ////    dbContextOptions => dbContextOptions
            ////        .UseMySql(connection, serverVersion)
            ////        .LogTo(Console.WriteLine, LogLevel.Information)
            ////        .EnableSensitiveDataLogging()
            ////        .EnableDetailedErrors()
            ////);
            services.AddTransient<ITiquetesNavieraService, TiquetesNavieraService>();
            services.AddTransient<ITiquetesNavieraServiceRepository, TiquetesNavieraServiceRepository>();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(connection, serverVersion));
            services.AddControllers();
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Tiquetes Naviera v1");
            });
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
