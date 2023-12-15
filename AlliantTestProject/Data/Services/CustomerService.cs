using AlliantTestProject.Data.Models;
using AlliantTestProject.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlliantTestProject.Data.Services
{
    public class CustomerService
    {
        public List<Customer> Customers { get; private set; }

        private readonly ApplicationDbContext _db;
        private readonly NavigationManager _navigationManager;

        public CustomerService(ApplicationDbContext db, NavigationManager navigationManager)
        {
            _db = db;
            _navigationManager = navigationManager;
        }

        public async Task LoadCustomer()
        {
            Customers = await GetAllCustomers();
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer = await _db.Customers.FindAsync(id);
            if (customer == null)
            {
                throw new Exception("No customer here.");
            }
            return customer;
        }

        public async Task CreateCustomer(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo("customers");
        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            var dbCustomer = await _db.Customers.FindAsync(id);
            if (dbCustomer == null)
                throw new Exception("No customer here.");

            dbCustomer.CustomerNumber = customer.CustomerNumber;
            dbCustomer.CustomerName = customer.CustomerName;
            dbCustomer.Email = customer.Email;
            dbCustomer.Phone = customer.Phone;
            dbCustomer.IsActive = customer.IsActive;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo("customers");
        }

        public async Task DeleteCustomer(int id)
        {
            var dbCustomer = await _db.Customers.FindAsync(id);
            if (dbCustomer == null)
            {
                throw new Exception("No customer here.");
            }
            _db.Customers.Remove(dbCustomer);
            await _db.SaveChangesAsync();
            _navigationManager.NavigateTo("customers");
        }

        public async Task<List<Customer>> GetCustomersWithExpensiveItems()
        {
            var customers = await _db.Customers
                .Include(c => c.CustomerItems)
                .ThenInclude(ct => ct.Item)
                .ToListAsync();

            foreach (var customer in customers)
            {
                customer.CustomerItems = customer.CustomerItems.OrderByDescending(ct => ct.Price).ToList();
            }

            return customers;
        }
    }
}
