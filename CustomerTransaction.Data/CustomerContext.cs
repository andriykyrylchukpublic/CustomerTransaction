using CustomerTransaction.SharedEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransaction.Data
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public CustomerContext(DbContextOptions options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(k => k.CustomerId);
            builder.Entity<Customer>().Property(i => i.CustomerId).IsRequired();
            builder.Entity<Customer>().Property(n => n.Name).HasMaxLength(30);
            builder.Entity<Customer>().Property(e => e.Email).HasMaxLength(25);


            builder.Entity<Transaction>().HasKey(t => t.Id);
            builder.Entity<Transaction>().Property(t => t.Id).IsRequired();
            builder.Entity<Transaction>().Property(t => t.Currency).IsRequired().HasMaxLength(3);
            builder.Entity<Transaction>().Property(t => t.Status).IsRequired();
            builder.Entity<Transaction>().Property(t => t.Amount).IsRequired().HasColumnType("decimal(10,2)");
        }
    }
}
