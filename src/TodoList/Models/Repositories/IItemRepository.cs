using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Models
{
    public class IItemRepository
    {
        public IQueryable<Item> Items { get; }
        public Item Save(Item item) { return item; }
        public Item Edit(Item item) { return item; }
        public void Remove(Item item) { }
     }
 }
    
    

