using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.OpenApi.Models;
using ShopList.DataAccess;
using ShopList.DataAccess.DataContexts;
using ShopList.Server.Helpers;
using ShopList.Server.ServerHelpers;
using ShopList.Shared.DataModels.Authentication;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using ShopList.Shared.Interfaces;
using ShopList.DataAccess.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddShopListDbContexts(connectionString);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddIdentity<IdentityUserModel, IdentityRole>(o =>
{
  o.Password.RequireDigit = false;
  o.Password.RequireNonAlphanumeric = false;
  o.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAutoMapper(typeof(ShopList.Shared.Helpers.MapperProfile).GetTypeInfo().Assembly);
builder.Services.AddScoped<IDataAccessHelper, DataAccessHelper>();

var app = builder.Build();

app.RegisterAllAPI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseWebAssemblyDebugging();
  app.UseSwagger();
  app.UseSwaggerUI();
}
else
{
  app.UseExceptionHandler("/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.MigrateDatabase();

app.Run();
