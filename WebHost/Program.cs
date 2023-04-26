using _0_Framework.Application;
using AccountManagment.Infrastucure.Configuration;
using BlogManagment.Infrastucure.Configuration;
using CommentManagment.Infrastucure.Configuration;
using DiscountManagment.Infrastucure.Configuration;
using InventoryManagment.Infrasctucure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;

using ServiceHost;
using ShopManagment.Infrastucure.Configoration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddHttpContextAccessor();

builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("BookCity");


ShopManagmentBootsrapper.Configure(builder.Services, connectionString);
DiscountManagmentBootsrapper.Configure(builder.Services, connectionString);
InventoryManagmentBootsrapper.Configure(builder.Services, connectionString);
BlogManagmentBootsrapper.Configure(builder.Services, connectionString);
CommentManagmentBootsrapper.Configure(builder.Services, connectionString);
AccountManagmnetBootsrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();
builder.Services.AddTransient<IAuthHelper, AuthHelper>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCookiePolicy();
app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();
