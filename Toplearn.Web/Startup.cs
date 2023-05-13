using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TopLearn.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TopLearn.Core.Services;
using TopLearn.Core.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using TopLearn.Core.Convertors;
using System.Security.Claims;

namespace TopLearn.web
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            //services.AddMvc();
            services.AddRazorPages();

            //services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = 6000000; });

            #region Database Context

            services.AddDbContext<TopLearnContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("TopLearnConnection"));
            }
            );

            #endregion

            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options => 
            {
                options.LoginPath = "/Login";
                options.LogoutPath = "/Logout";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);
            });
            #endregion


            #region IOC

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IViewRenderService, RenderViewToString>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<ICourseService, CourseService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IForumService, ForumService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Use(async (context, next) =>
            {
                await next();
                if (context.Response.StatusCode == 404)
                {
                    context.Response.Redirect("/Home/Error404");
                }
            });

            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value.ToString().ToLower().StartsWith("/coursefilesonline"))
                {
                    var callingUrl = context.Request.Headers["Referer"].ToString();
                    if (callingUrl != ""  && (callingUrl.StartsWith("https://localhost:44356") || callingUrl.StartsWith("http://localhost:37644")))
                    {
                        await next.Invoke();
                    }
                    else
                    {
                        context.Response.Redirect("/Login");
                    }
                }
                else
                {
                    await next.Invoke();
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseCors();
            app.UseAuthorization();

            //app.Use(async (context, next) =>
            //{
            //    // Do work that doesn't write to the Response.
            //    if (context.Request.Path.StartsWithSegments("/Admin"))
            //    {
            //        if (!context.User.Identity.IsAuthenticated)
            //        {
            //            context.Response.Redirect("/Account/Login");
            //        }
            //        else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
            //        {
            //            context.Response.Redirect("/Account/Login");
            //        }
            //    }
            //    await next.Invoke();
            //    // Do logging or other work that doesn't write to the Response.
            //});

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        "default", "{controller=Home}/{action=Index}"
            //        );

            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapControllerRoute(
            //          name: "areas",
            //          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            //        );
            //    });

            //    app.UseEndpoints(endpoints =>
            //    {
            //        endpoints.MapRazorPages();
            //        endpoints.MapControllerRoute(
            //            name: "default",
            //            pattern: "{controller=Home}/{action=Index}/{id?}");
            //    });
            //});

          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(

                    name: "MyAreas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(

                    name: "Default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                app.UseEndpoints(endpoints =>
                {
                    endpoints.MapRazorPages();
                    endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
                });
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

        }
    }
}
