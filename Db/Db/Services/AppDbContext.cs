using Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Db.Services
{
    public class AppDbContext: DbContext//, IDataStore<Item>
    {
        private string _dbPath;
        public DbSet<Item> Items { get; set; }

        public AppDbContext(/*string dbPath*/)
        {
            //_dbPath = dbPath;
            _dbPath = Path.Combine(FileSystem.AppDataDirectory, "items.sqlite");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseSqlite($"Data Source={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." }
            };
            foreach(var i in items)
            {
                modelBuilder.Entity<Item>().HasData(i);
            }
        }

        /*
        public async Task<bool> AddItemAsync(Item item)
        {
            try
            {
                await Items.AddAsync(item);
                await SaveChangesAsync();
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
                var item = await Items.FirstOrDefaultAsync(i => i.Id == id);
                if (item != null)
                {
                    Items.Remove(item);
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
                var item = await Items.FirstOrDefaultAsync(i => i.Id == id);
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
                var items = await Items.ToListAsync();
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
                Items.Update(item);
                await SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        */
    }
}
