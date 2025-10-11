using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NeuroQuest.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        private List<IInventoryItem> _items;

        public void Init()
        {
            _items = new();
        }

        public void Add(IInventoryItem item)
        {
            _items.Add(item);
        }

        public void Remove(IInventoryItem item)
        {
            _items.Remove(item);
        }

        public bool HasItem(IInventoryItem item)
        {
            return _items.Any(i => i.Equals(item));
        }
    }
}

