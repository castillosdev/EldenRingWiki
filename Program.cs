using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using EldenRingWiki;
using EldenRingWiki.Services;
using System;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://eldenring.fanapis.com/") });
builder.Services.AddScoped<NpcService>();
builder.Services.AddScoped<BossService>();
builder.Services.AddScoped<CreatureService>();
builder.Services.AddScoped<LocationService>();
await builder.Build().RunAsync();
