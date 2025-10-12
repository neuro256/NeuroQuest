using System;
using UnityEngine;

namespace NeuroQuest.UI.Presentation
{
    public abstract class BaseWindowView : MonoBehaviour, IWindowView
    {
        public event Action onWindowClose;

        public bool IsActive => gameObject.activeSelf;

        public virtual void Hide()
        {
            gameObject.SetActive(false);
            onWindowClose?.Invoke();
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    }
}

