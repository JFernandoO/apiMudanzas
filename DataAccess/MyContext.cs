
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class MyContext : DbContext
    {
        public DbSet<Register> Registers { get; set; }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
            
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(SingletonDataContainer.strConnect);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Register>(b =>
            {
                b.HasKey(e => e.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
            });
        }
    }
}
