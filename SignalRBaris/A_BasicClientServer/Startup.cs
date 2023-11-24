using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace A_BasicClientServer.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //NOTE: configure signalR services
            services.AddSignalR().AddHubOptions<ProductViewersHub>(options => options.EnableDetailedErrors = true);
            services.AddLogging(logging => logging.SetMinimumLevel(LogLevel.Trace));
            /*SignalR emits diagnostic events that can be captured for more detailed information.
            services.AddSignalR()
            .AddHubOptions<ProductViewersHub>(options =>
            {
                options.EnableDetailedErrors = true;
                options.KeepAliveInterval = TimeSpan.FromMinutes(1);
            }).AddAzureSignalR(Configuration.GetConnectionString("AzureSignalRConnection"));*/
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseDefaultFiles(); //index.html
            app.UseStaticFiles();

            app.UseEndpoints(configure => {
                //NOTE: Map Hub is a generic, so we need to tell it what type of hub we're mapping.
                //Setting our path that it doesn't conflict with any other routes
                configure.MapHub<ProductViewersHub>("/hub/productViewers");
                configure.MapHub<StringParametersHub>("/hub/stringParameters");
                configure.MapHub<MusicPlayCountHub>("/hub/musicPlayers");
                configure.MapHub<GroupsHub>("/hub/groups");
            });
        }
    }
}
