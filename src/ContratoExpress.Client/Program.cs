using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using ContratoExpress.Client;
using ContratoExpress.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// API base address (point to server)
var apiBase = builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001";
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBase) });

// Auth
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<AuthStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<AuthStateProvider>());
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthorizationCore();

// App services
builder.Services.AddScoped<ContractService>();
builder.Services.AddScoped<BillingService>();

var host = builder.Build();

// Try to restore session on startup
var auth = host.Services.GetRequiredService<AuthService>();
await auth.TryRestoreSessionAsync();

await host.RunAsync();
