using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Door : MonoBehaviour, IInteractable
    {
        private bool _isOpen;

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
            if (_isOpen)
                return;

            gameObject.SetActive(false);

            _isOpen = true;
        }
    }
}

