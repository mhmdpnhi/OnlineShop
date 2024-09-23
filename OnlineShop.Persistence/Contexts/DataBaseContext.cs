using Microsoft.EntityFrameworkCore;
using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Common.Consts.User;
using OnlineShop.Domain.Entities.Users;

namespace OnlineShop.Persistence.Contexts
{
    public class DataBaseContext : DbContext, IDataBaseContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = nameof(UserRoles.Admin)
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = nameof(UserRoles.Author)
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = nameof(UserRoles.Customer)
            });

            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 4,
                Name = nameof(UserRoles.Operator)
            });
        }

    }
}
