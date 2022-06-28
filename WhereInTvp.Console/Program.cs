using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WhereInTvp.Console;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services
            .AddScoped<Application>()
            .AddDbContext<BloggingContext>();
    })
    .Build();

var app = host.Services.GetRequiredService<Application>();
await app.RunAsync();