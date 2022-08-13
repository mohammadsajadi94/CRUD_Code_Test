using CRUD_Code_Test.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Code_Test.Application.Interfaces
{
    public interface ICustomerContext
    {
        DbSet<Customer> customers { get; set; }

        Task<int> SaveChanges();
    }
}