using Business.IOC;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FbProje.PersonalUl
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
            /*giri� yapm��*/
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                opt =>
                {
                    opt.Cookie.HttpOnly = true;//Cookie g�r�n�rl�g� kapatma(js cekme)
                    opt.Cookie.Name = "PersonalWeb";//Cookinin g�z�kecegi ad
                    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;//Diger sayfalar�n kullan�m�n� kapatma .lax dersek acar�z
                    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;//.always dersek sadice https de cal���r.sameasrequest dersek https se https http se http
                    opt.ExpireTimeSpan = TimeSpan.FromDays(20);//Cookinin ne kadar s�re kalacag�
                    opt.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Auth/Login");//giri� yapmam�� ki�inin nereye y�nlendirilecegi
                }
                );
            services.AddCustomDependencies(Configuration);
            services.AddControllersWithViews().AddFluentValidation();
            services.AddAutoMapper(typeof(Startup));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area}/{controller=AdminHome}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
