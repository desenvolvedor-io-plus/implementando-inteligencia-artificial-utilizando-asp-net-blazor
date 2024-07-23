using AssistenteDeEnsino.Components;
using AssistenteDeEnsino.Components.Player.Data;
using AssistenteDeEnsino.Configurations;
using AssistenteDeEnsino.Data;
using AssistenteDeEnsino.Services.Markdown;
using AssistenteDeEnsino.Services.OpenAI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<OpenAIOptions>(builder.Configuration.GetSection("OpenAI"));

builder.Services.AddScoped<IVideoRepository, VideoRepository>();
builder.Services.AddScoped<IGptService, GptService>();
builder.Services.AddScoped<IMarkdownService, MarkdownService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(AssistenteDeEnsino.Client._Imports).Assembly);

app.UseDbMigrationHelper();
app.Run();