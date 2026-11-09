using Microsoft.AspNetCore.Authentication.Cookies;
using ReShareBlazorApp.Web.ApiServices;
using ReShareBlazorApp.Web.Components;
using ReShareBlazorApp.Web.Endpoints;
using ReShareBlazorApp.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddHttpClient("API", client =>
{
    client.BaseAddress =
    new Uri(builder.Configuration["ApiSettings:BaseAddress"]!);
});
builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("API");
});
builder.Services.AddScoped<AuthApiService>();
builder.Services.AddSingleton<ListingStore>();   // ogłoszenia trzymane w pamięci (do czasu podpięcia bazy)
builder.Services.AddSingleton<CartStore>();      // koszyki w pamięci (klucz = ciasteczko)
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ReShare.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/access-denied";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = false;
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAntiforgery();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

// Zdjęcia wgrywane przez użytkowników lądują w wwwroot/uploads i muszą być serwowane w trakcie działania aplikacji
Directory.CreateDirectory(Path.Combine(app.Environment.WebRootPath, "uploads"));
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapAuthEndpoints();
app.MapCartEndpoints();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
