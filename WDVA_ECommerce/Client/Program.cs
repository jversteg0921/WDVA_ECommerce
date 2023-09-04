global using WDVA_ECommerce.Shared;
global using System.Net.Http.Json;
global using WDVA_ECommerce.Client.Services.ProductService;
global using WDVA_ECommerce.Client.Services.CategoryService;
global using WDVA_ECommerce.Client.Services.CartService;
global using WDVA_ECommerce.Shared.DTOs;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WDVA_ECommerce.Client;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

await builder.Build().RunAsync();
