using MahalaxmiFuniture.Context;
using MahalaxmiFuniture.Models;
using MahalaxmiFuniture.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahalaxmiFuniture.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;
        public CustomerRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task CreateAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public void DeleteAsync(Customer customer)
        {
            context.Customers.Remove(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await context.Customers.FindAsync(id);
        }

        public void UpdateAsync(Customer customer)
        {
            context.Customers.Update(customer);
        }
    }
}
