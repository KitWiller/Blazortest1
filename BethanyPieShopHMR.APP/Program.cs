using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BethanyPieShopHMR.APP
{
    public class Program //come sempre è l'entrypoint dell'applicazione
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args); // questo hosta la nostra webassembly app (clientside)
            builder.RootComponents.Add<App>("#app"); //il component root 'app' sarà app.razor, ed è collegato a riga 15 di index.html

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //dependency injection che sta iniettando httpclient

            await builder.Build().RunAsync();
        }
    }
}
