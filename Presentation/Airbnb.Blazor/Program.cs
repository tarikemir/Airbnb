using Airbnb.Blazor.Data;
using Airbnb.Blazor.Interfaces;
using Airbnb.Blazor.Services;
using Airbnb.BlazorApp.Interfaces;
using Airbnb.BlazorApp.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOriginPolicy",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7279/") });
builder.Services.AddScoped<IAdminApiService, AdminApiService>();
builder.Services.AddScoped<IOwnerApiService, OwnerApiService>();
builder.Services.AddScoped<IPaymentApiService, PaymentApiService>();
builder.Services.AddScoped<IRenterApiService, RenterApiService>();
builder.Services.AddScoped<IReservationApiService, ReservationApiService>();
builder.Services.AddScoped<IReviewApiService, ReviewApiService>();
builder.Services.AddScoped<IRoomApiService, RoomApiService>();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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
//app.MapFallbackToPage("/admins/update/{adminId}", "/_Host");

app.Run();
