using UnityEngine;

namespace NeuroQuest.UI.Presentation
{
    public abstract class BaseWindowView : MonoBehaviour, IWindowView
    {
        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Show()
        {
            gameObject.SetActive(true);
        }
    }
}

