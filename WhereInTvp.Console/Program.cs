using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using WhereInTvp.Console;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services
            .AddScoped<Application>()
            .AddDbContext<BloggingContext>(options =>
            {
                options.UseSqlServer($"Server=tcp:localhost,11433;Database=Blogging;Uid=sa;Password=s0mEStr0ngPwd!!");
                options.ReplaceService<IQuerySqlGeneratorFactory, CustomSqlServerQuerySqlGeneratorFactory>();
            });
    })
    .Build();

var app = host.Services.GetRequiredService<Application>();
await app.RunAsync();