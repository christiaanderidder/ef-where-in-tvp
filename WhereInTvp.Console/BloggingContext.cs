using Microsoft.EntityFrameworkCore;

namespace WhereInTvp.Console;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public BloggingContext()
    {
        
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer($"Server=tcp:localhost,11433;Database=Blogging;Uid=sa;Password=s0mEStr0ngPwd!!");
}