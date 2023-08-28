using Fleet_Management_Service.Data;
using Fleet_Management_Service.Models;  // Add this if your DbContext is in a different namespace
using Fleet_Management_Service.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore; // Add this for Entity Framework
using Microsoft.Extensions.Configuration; // Add this for Configuration

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

//Database Configuration
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseSqlServer(connectionString);
});

//Register Vessel Service
builder.Services.AddScoped<VesselService>();
//Register Containers Service
builder.Services.AddScoped<ContainerService>();
//Register Containers Service
builder.Services.AddScoped<FleetService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
