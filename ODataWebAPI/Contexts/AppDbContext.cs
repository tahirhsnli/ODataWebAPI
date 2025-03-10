using Microsoft.EntityFrameworkCore;
using ODataWebAPI.Models;

namespace ODataWebAPI.Contexts
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
    }
}
