using NeuroQuest.Inventory;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Chest : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private ChestData _chestData;

        private bool _isOpened;

        private void Awake()
        {
            var interactiveZone = GetComponentInChildren<InteractiveZone>();
            if (interactiveZone != null)
            {
                interactiveZone.Init(this);
            }
        }

        public void Interact()
        {
            if (_isOpened)
                return;

            _isOpened = true;
            var playerInventory = FindFirstObjectByType<PlayerInventory>();

            foreach (var itemData in _chestData.Items)
            {
                var item = itemData.CreateItem();
                playerInventory.Add(item);
                Debug.Log($"Игрок получил {itemData.Type} ({item})");
            }

            Debug.Log("Сундук открыт!");
        }
    }
}