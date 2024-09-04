using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.BusinessLayer.ValidationRules;
using FitSalon.DataAccessLayer.Abstract;
using FitSalon.DataAccessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.DtoLayer.DTOs.AnnouncementDTOs;
using FitSalon.EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using FitSalon.EntityLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider).AddEntityFrameworkStores<Context>();
builder.Services.AddDbContext<Context>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
// Register your service here
builder.Services.AddMvc();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
