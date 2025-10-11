using NeuroQuest.Inventory;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public abstract class ItemData : ScriptableObject
    {
        [SerializeField]
        private ItemType _itemType;

        [SerializeField]
        private string _spritePath;

        public ItemType Type => _itemType;

        public abstract InventoryItem CreateItem();
    }
}

