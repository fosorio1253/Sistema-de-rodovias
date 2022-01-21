using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using DER.WebApp.Domain.Models;
using Hangfire;
using System.Configuration;
using DER.WebApp.Controllers;

[assembly: OwinStartup(typeof(DER.WebApp.Startup))]

namespace DER.WebApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                    .UseSqlServerStorage(ConfigurationManager.ConnectionStrings["DerContext"].ConnectionString);

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            var job = new JobController();
            RecurringJob.AddOrUpdate("ExecutarAPIS",        () => job.ExecutaTodasAPIs(),   Cron.Monthly);
            RecurringJob.AddOrUpdate("RemuneracaoJob",      () => job.RemuneracaoJob(),     Cron.Monthly);
            RecurringJob.AddOrUpdate("InadimplentesJob",    () => job.InadimplentesJob(),   Cron.Daily);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login/Index"),
                ExpireTimeSpan = TimeSpan.FromMinutes(20)
            });
        }
    }
}
