using _0_Framework.Application;
using BlogManagment.Infrastucure.Configuration;
using DiscountManagment.Infrastucure.Configuration;
using InventoryManagment.Infrasctucure.Configuration;
using Microsoft.AspNetCore.Builder;
using ServiceHost;
using ShopManagment.Infrastucure.Configoration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("BookCity");


ShopManagmentBootsrapper.Configure(builder.Services, connectionString);
DiscountManagmentBootsrapper.Configure(builder.Services, connectionString);
InventoryManagmentBootsrapper.Configure(builder.Services, connectionString);
BlogManagmentBootsrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllers();
});

app.Run();
