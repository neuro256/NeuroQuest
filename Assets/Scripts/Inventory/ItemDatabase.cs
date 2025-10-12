using NeuroQuest.Infrastructure;
using NeuroQuest.InteractableObjects;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.Inventory
{
    [CreateAssetMenu(menuName = "NeuroQuest/Inventory/ItemDatabase", fileName = "ItemDatabase")]
    public class ItemDatabase : ScriptableObject
    {
        [SerializeField]
        private List<ItemData> _allItems = new();

        private Dictionary<KeyType, KeyItemData> _keysData = new();

        public void Init()
        {
            _keysData.Clear();

            foreach (var item in _allItems)
            {
                if (item is KeyItemData keyItemData)
                    _keysData[keyItemData.KeyType] = keyItemData;
            }
        }

        public ItemData GetItemData(InventoryItem item)
        {
            switch (item)
            {
                case KeyItem keyItem: 
                    return _keysData.TryGetValue(keyItem.KeyType, out var data) ? data : null;
                default:
                    return _allItems.Find(i => i.Type == item.Type);
            }
        }

        public void LoadItemSprite(InventoryItem item, Action<Sprite> onLoaded)
        {
            var data = GetItemData(item);
            
            if (data == null)
            {
                Debug.LogError($"[ItemDatabase] No ItemData found for {item}");
                onLoaded?.Invoke(null);
                return;
            }

            AddressablesLoader.LoadAsync(data.SpritePath, onLoaded);
        }
    }
}

