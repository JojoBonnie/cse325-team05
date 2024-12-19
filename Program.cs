using Microsoft.AspNetCore.Identity;
using team_project_v2.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register HttpClient for TaskService
builder.Services.AddHttpClient<TaskService>();

// Register MongoDbContext
builder.Services.AddSingleton<MongoDbContext>();

// Register UserService
builder.Services.AddScoped<UserService>();

// Register PasswordHasher
builder.Services.AddScoped<IPasswordHasher<UserModel>, PasswordHasher<UserModel>>();



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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
