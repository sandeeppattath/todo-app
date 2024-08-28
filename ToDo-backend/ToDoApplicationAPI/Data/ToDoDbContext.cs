using Microsoft.EntityFrameworkCore;
using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        { }
        public DbSet<ToDo> ToDos { get; set; }
    }
}
