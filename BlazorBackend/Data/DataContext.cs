using Blazor.Modals;
using Microsoft.EntityFrameworkCore;

namespace BlazorBackend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> USers { get; set; }
        public DbSet<Comic> Comics { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Comic>().HasData(
                new Comic { Id = 1, Name = "Checking" },
                new Comic { Id = 2, Name = "Controller" }
            );

            model.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     FirstName = "Checking",
                     LastName = "Controller",
                     Email = "email@gmail.com",
                     ComicId = 1,

                 },
            new User
            {
                Id = 2,
                FirstName = "Design",
                LastName = "Maintain",
                Email = "checking@gmail.com",
                ComicId = 2,

            }
                );
            
    }
}
}
