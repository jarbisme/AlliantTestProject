using AlliantTestProject.Data.Models;
using AlliantTestProject.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace AlliantTestProject.Data.Services
{
    public class ItemsService
    {
        public List<Item> Items { get; private set; }

        private readonly ApplicationDbContext _db;
        private readonly NavigationManager _navigationManager;

        public ItemsService(ApplicationDbContext db, NavigationManager navigationManager)
        {
            _db = db;
            _navigationManager = navigationManager;
        }


        public async Task LoadItems()
        {
            Items = await GetAllItems();
        }

        public async Task<List<Item>> GetAllItems()
        {
            var items = await _db.Items.ToListAsync();
            return items;
        }

        public async Task<Item> GetItem(int id)
        {
            var item = await _db.Items.FindAsync(id);
            if (item == null)
            {
                throw new Exception("No item found.");
            }
            return item;
        }

        public async Task CreateItem(Item item)
        {
            try
            {
                item.ItemCategory = item.ItemCategory.ToUpper();
                _db.Items.Add(item);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo("items");
        }

        public async Task UpdateItem(int id, Item item)
        {
            var dbItem = await _db.Items.FindAsync(id);
            if (dbItem == null)
                throw new Exception("No customer here.");

            dbItem.ItemNumber = item.ItemNumber;
            dbItem.Description = item.Description;
            dbItem.DefaultPrice = item.DefaultPrice;
            dbItem.ItemCategory = item.ItemCategory.ToUpper();
            dbItem.IsActive = item.IsActive;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }

            _navigationManager.NavigateTo("items");
        }

        public async Task DeleteItem(int id)
        {
            var dbItem = await _db.Items.FindAsync(id);
            if (dbItem == null)
            {
                throw new Exception("No item found.");
            }
            _db.Items.Remove(dbItem);
            await _db.SaveChangesAsync();
            _navigationManager.NavigateTo("items");
        }
    }
}
