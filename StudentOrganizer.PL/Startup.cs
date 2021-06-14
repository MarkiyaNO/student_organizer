using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentOrganizer.BLL;
using StudentOrganizer.BLL.Interfaces;
using StudentOrganizer.BLL.Services;
using StudentOrganizer.DAL;
using StudentOrganizer.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace StudentOrganizer.PL
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
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            

            services.AddDbContext<SOrganizerDBContext>(c => c.UseSqlServer(Configuration.GetConnectionString("SOrganaizerDB")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<ILessonService, LessonService>();
            services.AddScoped<IScheduleLessonService, ScheduleLessonService>();
            services.AddScoped<IStudentService, StudentService>();

            // var mpcfg = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            var mpcfg = new MapperConfiguration(c => {
                c.AddCollectionMappers();
                c.AddProfile(new AutomapperProfile());
            });

            services.AddSingleton(mpcfg.CreateMapper());

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
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
