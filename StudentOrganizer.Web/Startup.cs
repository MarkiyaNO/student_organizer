using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using StudentOrganizer.BLL;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Services;
using StudentOrganizer.DAL;
using StudentOrganizer.DAL.Entities;
using StudentOrganizer.DAL.Interfaces;
using System.Security.Claims;

namespace StudentOrganizer.Web
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
            services.AddDbContext<SOrganizerDBContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("SOrganaizerDB")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<Student>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<SOrganizerDBContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<Student, SOrganizerDBContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.Configure<IdentityOptions>(
                options => options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier);

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IScheduleService, ScheduleService>();
            services.AddTransient<IAssignmentService, AssignmentService>();
            services.AddTransient<ILessonService, LessonService>();
            services.AddTransient<IScheduleLessonService, ScheduleLessonService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo()
                { Title = "My Student Organizer", Version = "v1" });
            });

            // var mpcfg = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            var mpcfg = new MapperConfiguration(c => {
                c.AddCollectionMappers();
                c.AddProfile(new AutomapperProfile());
            });

            services.AddSingleton(mpcfg.CreateMapper());

            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "My Student Organizer");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
