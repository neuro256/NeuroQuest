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

        private List<InventorySlot> _slots = new();
        private PlayerInventory _playerInventory;

        private void Awake()
        {
            for (int i = 0; i < _slotCount; i++)
            {
                var slot = Instantiate(_slotPrefab, transform);
                slot.Clear();
                _slots.Add(slot);
            }

            _itemDatabase.Init();

            _playerInventory = FindFirstObjectByType<PlayerInventory>();
            _playerInventory.onInventoryChanged += UpdateSlots;
        }

        private void OnDestroy()
        {
            if (_playerInventory != null)
                _playerInventory.onInventoryChanged -= UpdateSlots;
        }

        private void UpdateSlots(List<IInventoryItem> items)
        {
            if (items == null) items = new List<IInventoryItem>();

            for (int i = 0; i < _slots.Count; i++)
            {
                if(i < items.Count)
                {
                    var item = items[i] as InventoryItem;
                    var slot = _slots[i];

                    _itemDatabase.LoadItemSprite(item, sprite => {
                        if (slot != null)
                            slot.SetSprite(sprite);
                     });
                }
                else
                {
                    _slots[i].Clear();
                }
            }
        }
    }
}

