using Microsoft.EntityFrameworkCore;
using ServerManagement.Components;
using ServerManagement.Components.Database;
using ServerManagement.Components.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add Database Context
builder.Services.AddDbContextFactory<ServerManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorServerManagement")));
builder.Services.AddHttpClient("ServersApi", client =>
{
    client.BaseAddress = new Uri("https://testdb-c6320-default-rtdb.asia-southeast1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServerEFRepository, ServerEFRepository>();
builder.Services.AddTransient<IServerAPIRepository, ServerAPIRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
