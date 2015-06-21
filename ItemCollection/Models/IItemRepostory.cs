using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItemCollection.Models
{
    public class IItemRepostory : ItemRepository
    {
        private List<Item> items = new List<Item>();
        private int _nextId = 1;

        public IItemRepostory()
        {
            Add(new Item { Name = "Tomato", Category = "Vagitable", Price = 100 });
            Add(new Item { Name = "Apple", Category = "Fruit", Price = 150 });
            Add(new Item { Name = "Suit", Category = "Cloth", Price = 200 });
        }

        public IEnumerable<Item> GetAll()
        {
            return items;
        }

        public Item Get(int id)
        {
            return items.Find(p => p.Id == id);
        }

        public Item Add(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            items.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            items.RemoveAll(p => p.Id == id);
        }

        public bool Update(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = items.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            items.RemoveAt(index);
            items.Add(item);
            return true;
        }
    }
}