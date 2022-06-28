// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using WhereInTvp.Console;

await using var db = new BloggingContext();

var ids = new[] {1, 2};

var blogs = await db.Blogs
    .Where(b => ids.Contains(b.BlogId))
    .ToListAsync();

foreach (var blog in blogs)
{
    Console.WriteLine(blog.Url);
}

Console.ReadKey();