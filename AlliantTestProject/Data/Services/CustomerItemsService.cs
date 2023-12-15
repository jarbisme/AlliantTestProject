using AlliantTestProject.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace AlliantTestProject.Data.Services
{
    public class CustomerItemsService
    {
        public List<CustomerItem> CustomerItems { get; private set; }

        private readonly ApplicationDbContext _db;
        private readonly NavigationManager _navigationManager;

        public CustomerItemsService(ApplicationDbContext db, NavigationManager navigationManager)
        {
            _db = db;
            _navigationManager = navigationManager;
        }

        //public async Task LoadCustomerItems()
        //{
        //    CustomerItems = await GetAllCustomerItems();
        //}

        public async Task<List<CustomerItem>> GetCustomerItems(int customerId)
        {
            var customerItems = await _db.CustomerItems
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Item)
                .Include(c => c.Customer)
                .ToListAsync();
            return customerItems;
        }

        public async Task<CustomerItem> GetCustomerItem(int customerItemId)
        {
            var customerItem = await _db.CustomerItems
                .Where(c => c.CustomerItemId == customerItemId)
                .Include(c => c.Item)
                .Include(c => c.Customer)
                .FirstOrDefaultAsync();
            if (customerItem == null)
            {
                throw new Exception("No customer item here.");
            }
            return customerItem;
        }

        public async Task CreateCustomerItem(CustomerItem customerItem)
        {
            try
            {
                customerItem.Item = null;
                customerItem.Customer = null;

                _db.CustomerItems.Add(customerItem);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo($"customeritems/{customerItem.CustomerId}");
        }

        public async Task UpdateCustomerItem(int id, CustomerItem customerItem)
        {
            var dbCustomerItem = await _db.CustomerItems.FindAsync(id);
            if (dbCustomerItem == null)
                throw new Exception("No customer item here.");

            dbCustomerItem.CustomerId = customerItem.CustomerId;
            dbCustomerItem.ItemId = customerItem.ItemId;
            dbCustomerItem.Quantity = customerItem.Quantity;
            dbCustomerItem.Price = customerItem.Price;
            dbCustomerItem.IsActive = customerItem.IsActive;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo($"customeritems/{customerItem.CustomerId}");
        }

        public async Task DeleteCustomerItem(int id)
        {
            var dbCustomerItem = await _db.CustomerItems.FindAsync(id);
            if (dbCustomerItem == null)
            {
                throw new Exception("No customer item here.");
            }
            _db.CustomerItems.Remove(dbCustomerItem);
            await _db.SaveChangesAsync();
            _navigationManager.NavigateTo($"customeritems/{dbCustomerItem.CustomerId}");
        }

        public async Task<List<CustomerItem>> GetCustomerItemsRange(int startItemId, int endItemId)
        {
            var customerItems = await _db.CustomerItems
                .Where(c => c.Item.ItemNumber >= startItemId && c.Item.ItemNumber <= endItemId)
                .Include(c => c.Item)
                .Include(c => c.Customer)
                .OrderBy(c => c.ItemId)
                .ToListAsync();
            return customerItems;
        }
    }
}
