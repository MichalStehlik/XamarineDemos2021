using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Db.Services
{
    class ItemStore : IDataStore<Item>
    {
        private AppDbContext _db;

        public ItemStore()
        {
            _db = DependencyService.Get<AppDbContext>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                await _db.Items.AddAsync(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == id);
                if (item != null)
                {
                    _db.Items.Remove(item);
                    await _db.SaveChangesAsync();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Item> GetItemAsync(string id)
        {
            try
            {
                var item = await _db.Items.FirstOrDefaultAsync(i => i.Id == id);
                return item;
            }
            catch
            {
                return default;
            }
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            try
            {
                var items = await _db.Items.ToListAsync();
                return items;
            }
            catch
            {
                return default;
            }
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                _db.Items.Update(item);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
