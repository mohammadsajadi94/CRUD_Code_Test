using CRUD_Code_Test.Application.Interfaces;
using CRUD_Code_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Code_Test.Persistence.Context
{
    public class CustomerContext : DbContext, ICustomerContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        { }
        public DbSet<Customer> customers { get; set; }
        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasIndex(c => c.Firstname).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Lastname).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.DateOfBirth).IsUnique();
            modelBuilder.Entity<Customer>().HasIndex(c => c.Email).IsUnique();
        }
    }
}
