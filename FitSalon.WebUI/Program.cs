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
using FitSalon.BusinessLayer.Container;
using Microsoft.AspNetCore.Hosting;
using FitSalon.WebUI.Mapping.AutoMapperProfile;
using FitSalon.WebUI.CQRS.Handlers.ServiceHandlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.AddFile($"{Directory.GetCurrentDirectory()}\\LogFile\\log.txt", LogLevel.Error);
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

builder.Services.AddDbContext<Context>();
builder.Services.AddHttpClient();

builder.Services.AddScoped<GetAllServiceQueryHandler>();
builder.Services.AddScoped<GetServiceByIDQueryHandler>();
builder.Services.AddScoped<CreateServiceCommandHandler>();
builder.Services.AddScoped<DeleteServiceCommandHandler>();
builder.Services.AddScoped<UpdateServiceCommandHandler>();

builder.Services.AddMediatR(typeof(Program)); // MediatR'� kullanabilme parametresi.
Extensions.ContainerDependencies(builder.Services);
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);
Extensions.CustomValidator(builder.Services);

builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 3;
});

builder.Services.PostConfigure<CookieAuthenticationOptions>(IdentityConstants.ApplicationScheme, options =>
{
    options.LoginPath = "/Login/SignIn";
    options.LogoutPath = "/Login/Logout";
    options.AccessDeniedPath = "/Error/Error404";
});

var app = builder.Build();

app.Use(async (context, next) =>
{
    if (context.Request.Path.Equals("/Member", StringComparison.OrdinalIgnoreCase) ||
        context.Request.Path.Equals("/Member/", StringComparison.OrdinalIgnoreCase))
    {
        context.Response.Redirect("/Member/Dashboard");
    }
    else if (context.Request.Path.Equals("/Admin", StringComparison.OrdinalIgnoreCase) ||
        context.Request.Path.Equals("/Admin/", StringComparison.OrdinalIgnoreCase))
    {
        context.Response.Redirect("/Admin/Dashboard");
    }
    else
    {
        await next();
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // Ensure session is used before authentication and authorization
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePagesWithReExecute("/Error/Error404", "?code={0}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
