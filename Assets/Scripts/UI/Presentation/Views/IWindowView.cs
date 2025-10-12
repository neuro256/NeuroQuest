using System;

namespace NeuroQuest.UI.Presentation
{
    public interface IWindowView
    {
        event Action onWindowClose;
        bool IsActive { get; }
        void Show();
        void Hide();
    }
}

