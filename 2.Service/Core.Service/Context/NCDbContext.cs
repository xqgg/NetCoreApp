using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Service.Context
{
    public class NCDbContext : DbContext
    {
        public NCDbContext(DbContextOptions<NCDbContext> options)
         : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }







    }
}
