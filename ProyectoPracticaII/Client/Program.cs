using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using ProyectoPracticaII.Client;
using ProyectoPracticaII.Client.Models;
using ProyectoPracticaII.Client.Servicios;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using ProyectoPracticaII.Client.extensiones; 

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore(); 


builder.Services.AddScoped<IHttpService, HttpService>();



await builder.Build().RunAsync();

