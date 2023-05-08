using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.EntityFrameworkCore;
using Bank.API.Data;
using Bank.API.Repository;
using Bank.API.Services;

namespace Bank.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));  
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllersWithViews()
                    .AddNewtonsoftJson();

            var connectionString = _configuration["connectionStrings:accountInfoDBConnectionString"];
            services.AddDbContext<AccountInfoContext>(o =>
            {
                o.UseSqlServer(connectionString);
            }) ;

            services.AddScoped<IAccountInfoRepository,AccountInfoRepository>();

            services.AddScoped<IServiceModel, ServiceModel>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddCors(p => p.AddPolicy("corspolicy", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));
        }

        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("corspolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
