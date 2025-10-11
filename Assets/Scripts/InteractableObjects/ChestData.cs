using System.Collections.Generic;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    [CreateAssetMenu(menuName = "NeuroQuest/Inventory/ChestData", fileName = "NewChestData")]
    public class ChestData : ScriptableObject
    {
        [SerializeField]
        private List<ItemData> _items;

        public List<ItemData> Items => _items ??= new List<ItemData>();
    }
}

