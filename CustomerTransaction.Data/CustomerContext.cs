using System;
using System.ComponentModel.DataAnnotations;
using CustomerTransaction.SharedEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerTransaction.Data
{
    public class CustomerContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public CustomerContext(DbContextOptions<CustomerContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customer>().HasKey(k => k.CustomerId);
            builder.Entity<Customer>().Property(i => i.CustomerId).IsRequired();
            builder.Entity<Customer>().Property(n => n.Name).HasMaxLength(30);
            builder.Entity<Customer>().Property(e => e.Email).HasMaxLength(25);


            builder.Entity<Transaction>().HasKey(k => k.Id);
            builder.Entity<Transaction>().Property(i => i.Id).IsRequired();
        }
    }
}
