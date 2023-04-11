using Microsoft.EntityFrameworkCore;
using POC_1.Models;

namespace POC_1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }
        public DbSet<MyModel> myModels { get; set; }
    }
}
