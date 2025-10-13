using NeuroQuest.UI.Presentation;
using UnityEngine;

namespace NeuroQuest.InteractableObjects
{
    public class Bed : MonoBehaviour, IInteractable
    {
        [SerializeField]
        [TextArea]
        private string _message;
        [SerializeField]
        private float _duration;

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
            var windowManager = FindFirstObjectByType<WindowManager>();
            windowManager.ShowNotification(_message, _duration);
        }
    }
}

