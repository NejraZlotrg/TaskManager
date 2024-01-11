using Microsoft.EntityFrameworkCore;

namespace TaskManager
{
    public class DBContext:DbContext

    {
   
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }


    }
}
