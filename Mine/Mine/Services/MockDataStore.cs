using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Seattle", Description="The best city in the world.", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Istanbul", Description="Also the best city of the world.", Value=10 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "San Francisco", Description="Not bad, reasonably fun city.", Value=8 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "New Haven", Description="Youldn't want to stay there for too long.", Value=5 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "New York City", Description="Almost the best city in the world.", Value=9 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Chicago", Description="I was always cold when I visited.", Value=7 }
            };
        }
        
        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}