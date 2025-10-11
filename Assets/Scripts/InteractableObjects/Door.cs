using NeuroQuest.Inventory;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private KeyType _keyType;

        private bool _isOpen;
        private KeyItem _neededKey;

        private void Awake()
        {
            var interactiveZone = GetComponentInChildren<InteractiveZone>();
            if (interactiveZone != null)
            {
                interactiveZone.Init(this);
            }

            _neededKey = new KeyItem(_keyType);
        }

        public void Interact()
        {
            if (_isOpen)
                return;

            var playerInventory = FindFirstObjectByType<PlayerInventory>();
            
            if(playerInventory.HasItem(_neededKey))
            {
                Debug.Log($"Дверь {_keyType} открыта!");
                _isOpen = true;
                gameObject.SetActive(false);
            }
            else
            {
                Debug.Log("Закрыто. Нужен ключ " + _keyType);
            }
        }
    }
}

