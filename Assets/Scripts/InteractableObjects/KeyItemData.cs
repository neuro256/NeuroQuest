using NeuroQuest.Inventory;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    [CreateAssetMenu(menuName = "NeuroQuest/Inventory/KeyItemData", fileName = "NewKeyItemData")]
    public class KeyItemData : ItemData
    {
        [SerializeField]
        private KeyType _keyType;

        public KeyType KeyType => _keyType;

        public override InventoryItem CreateItem()
        {
            return new KeyItem(_keyType);
        }
    }
}

