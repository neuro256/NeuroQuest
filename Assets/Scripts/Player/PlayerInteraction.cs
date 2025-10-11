using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class PlayerInteraction : MonoBehaviour
    {
        public static PlayerInteraction Instance { get; private set; }

        private IInteractable _currentTarget;

        private void Awake()
        {
            Instance = this;
        }

        public void SetInteractable(IInteractable interactable)
        {
            _currentTarget = interactable;
        }

        public void ClearInteractable()
        {
            _currentTarget = null;
        }

        public void TryInteract()
        {
            _currentTarget?.Interact();
        }
    }
}
