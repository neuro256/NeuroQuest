using NeuroQuest.Inventory;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.UI.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventorySlot _slotPrefab;
        [SerializeField, Range(1, 10)] private int _slotCount = 5;
        [SerializeField] private ItemDatabase _itemDatabase;

        //private List<InventorySlot> _slots = new();
        private Stack<InventorySlot> _slots;
        private PlayerInventory _playerInventory;

        private void Awake()
        {
            _slots = new Stack<InventorySlot>();

            _itemDatabase.Init();

            _playerInventory = FindFirstObjectByType<PlayerInventory>();
            _playerInventory.onInventoryAdded += AddItem;
            _playerInventory.onInventoryRemoved += RemoveItem;
        }

        private void OnDestroy()
        {
            if (_playerInventory != null)
            {
                _playerInventory.onInventoryAdded -= AddItem;
                _playerInventory.onInventoryRemoved -= RemoveItem;
            }
        }

        private void AddItem(IInventoryItem item)
        {
            if(_slots.Count <  _slotCount)
            {
                var slot = Instantiate(_slotPrefab, transform);
                slot.Clear();
                _slots.Push(slot);

                _itemDatabase.LoadItemSprite(item as InventoryItem, sprite => {
                    if (slot != null)
                        slot.SetSprite(sprite);
                });
            }
        }

        private void RemoveItem()
        {
            var slot = _slots.Pop();
            slot.Clear();
            Destroy(slot);
        }
    }
}

