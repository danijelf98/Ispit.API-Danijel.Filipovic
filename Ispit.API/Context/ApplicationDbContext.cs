using Ispit.API.Model.Dbo;
using Microsoft.EntityFrameworkCore;

namespace Ispit.API.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) 
        {
        }

        public DbSet<ToDoList> ToDoLists { get; set; }
    }
}
