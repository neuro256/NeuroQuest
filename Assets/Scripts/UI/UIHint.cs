using NeuroQuest.InteractableObjects;
using System;
using UnityEngine;

namespace NeuroQuest.UI
{
    public class UIHint : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Start()
        {
            PlayerInteraction.Instance.onChangeInteractable += OnChangeInteractable;
        }

        private void OnDestroy()
        {
            if(PlayerInteraction.Instance != null) 
                PlayerInteraction.Instance.onChangeInteractable += OnChangeInteractable;
        }

        private void OnChangeInteractable(IInteractable interactable)
        {
            SetVisible(interactable != null);
        }

        private void SetVisible(bool state)
        {
            _canvasGroup.alpha = state ? 1 : 0;
        }
    }
}

