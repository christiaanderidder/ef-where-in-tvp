using Microsoft.EntityFrameworkCore;

namespace WhereInTvp.Console;

public class Application
{
    private readonly BloggingContext _dbContext;

    public Application(BloggingContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task RunAsync()
    {
        var ids = new[] {1, 2};

        var blogs = await _dbContext.Blogs
            .Where(b => ids.Contains(b.BlogId))
            .ToListAsync();

        foreach (var blog in blogs)
        {
            System.Console.WriteLine(blog.Url);
        }
    }
}