using Microsoft.Data.Entity;

namespace TodoList.Models
{
    public class TodoListContext : DbContext
    {
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=TodoList;integrated security = True");
        }
    }
}
