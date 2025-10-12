using System;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class PlayerInteraction : MonoBehaviour
    {
        public static PlayerInteraction Instance { get; private set; }

        public event Action<IInteractable> onChangeInteractable;

        private IInteractable _currentTarget;

        private void Awake()
        {
            Instance = this;
        }

        public void SetInteractable(IInteractable interactable)
        {
            _currentTarget = interactable;
            onChangeInteractable?.Invoke(interactable);
        }

        public void ClearInteractable()
        {
            _currentTarget = null;
            onChangeInteractable?.Invoke(null);
        }

        public void TryInteract()
        {
            _currentTarget?.Interact();
        }
    }
}
