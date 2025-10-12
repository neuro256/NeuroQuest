using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NeuroQuest.Inventory
{
    public class PlayerInventory : MonoBehaviour
    {
        public event Action<List<IInventoryItem>> onInventoryChanged;

        private List<IInventoryItem> _items;

        public void Init()
        {
            _items = new();
        }

        public void Add(IInventoryItem item)
        {
            _items.Add(item);
            onInventoryChanged?.Invoke(_items);
        }

        public void Remove(IInventoryItem item)
        {
            _items.Remove(item);
            onInventoryChanged?.Invoke(_items);
        }

        public bool HasItem(IInventoryItem item)
        {
            return _items.Any(i => i.Equals(item));
        }
    }
}

