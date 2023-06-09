using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopList.Client;
using ShopList.Client.Helpers;
using ShopList.Client.Interfaces;
using ShopList.Client.Services;
using System.Reflection;
using AutoMapper;
using Blazored.Toast;
using Blazored.Modal;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAutoMapper(typeof(ShopList.Shared.Helpers.MapperProfile).GetTypeInfo().Assembly);
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredToast();

builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IShopBrandsService, ShopBrandsService>();
builder.Services.AddSingleton<IShopsService, ShopsService>();
builder.Services.AddSingleton<IProductsService, ProductsService>();
builder.Services.AddSingleton<IShopItemsToBuyService, ShopItemsToBuyService>();
builder.Services.AddSingleton<IProductsPricingService, ProductsPricingService>();
builder.Services.AddSingleton<IAPIHelper, APIHelper>();

await builder.Build().RunAsync();
